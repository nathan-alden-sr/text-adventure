using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.Models
{
    public abstract class Model : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, IEnumerable<string>> _errorsByPropertyName = new Dictionary<string, IEnumerable<string>>();

        public IReadOnlyDictionary<string, IEnumerable<string>> Errors => new ReadOnlyDictionary<string, IEnumerable<string>>(_errorsByPropertyName);
        public bool IsValid { get; private set; }
        public bool HasErrors { get; private set; }

        public IEnumerable GetErrors(string propertyName)
        {
            IEnumerable<string> errors;

            _errorsByPropertyName.TryGetValue(propertyName, out errors);

            return errors;
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void ValidateProperty([CallerMemberName] string propertyName = null)
        {
            propertyName.ThrowIfNull(nameof(propertyName));

            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            validationContext.MemberName = propertyName;

            PropertyInfo propertyInfo = GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            Validator.TryValidateProperty(propertyInfo.GetValue(this), validationContext, validationResults);

            var changedProperties = new HashSet<string>();

            if (_errorsByPropertyName.Remove(propertyName))
            {
                changedProperties.Add(propertyName);
            }

            ProcessValidationResults(validationResults, changedProperties);
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            var changedProperties = new HashSet<string>(_errorsByPropertyName.Keys.Except(validationResults.SelectMany(x => x.MemberNames).Distinct()));

            _errorsByPropertyName.Clear();

            ProcessValidationResults(validationResults, changedProperties);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ProcessValidationResults(IEnumerable<ValidationResult> validationResults, ISet<string> changedProperties)
        {
            IEnumerable<IGrouping<string, ValidationResult>> validationResultsByMemberName = validationResults
                .SelectMany(x => x.MemberNames, (validationResult, memberName) => new { validationResult, memberName })
                .GroupBy(x => x.memberName, x => x.validationResult);

            foreach (IGrouping<string, ValidationResult> validationResultForMemberName in validationResultsByMemberName)
            {
                _errorsByPropertyName.Add(validationResultForMemberName.Key, validationResultForMemberName.Select(x => x.ErrorMessage).ToArray());

                changedProperties.Add(validationResultForMemberName.Key);
            }

            SetIsValid(!_errorsByPropertyName.Any());

            foreach (string changedProperty in changedProperties)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(changedProperty));
            }

            if (changedProperties.Any())
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Errors)));
            }
        }

        private void SetIsValid(bool isValid)
        {
            IsValid = isValid;
            HasErrors = !isValid;

            // ReSharper disable ExplicitCallerInfoArgument
            OnPropertyChanged(nameof(IsValid));
            OnPropertyChanged(nameof(HasErrors));
            // ReSharper restore ExplicitCallerInfoArgument
        }
    }
}