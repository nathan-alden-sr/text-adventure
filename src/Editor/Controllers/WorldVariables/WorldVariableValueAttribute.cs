using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WorldVariableValueAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext => true;

        public string BooleanErrorMessage { get; set; }
        public string CharacterErrorMessage { get; set; }
        public string FixedPointErrorMessage { get; set; }
        public string IntegerErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = (WorldVariableViewModel)validationContext.ObjectInstance;
            var valueAsString = value as string;

            if (string.IsNullOrEmpty(valueAsString))
            {
                return ValidationResult.Success;
            }

            switch (viewModel.Type)
            {
                case WorldVariableType.Boolean:
                {
                    bool result;

                    ErrorMessage = BooleanErrorMessage;

                    return Validate(() => bool.TryParse(valueAsString, out result), validationContext.MemberName);
                }
                case WorldVariableType.Character:
                {
                    char result;

                    ErrorMessage = CharacterErrorMessage;

                    return Validate(() => char.TryParse(valueAsString, out result), validationContext.MemberName);
                }
                case WorldVariableType.FixedPoint:
                {
                    decimal result;

                    ErrorMessage = FixedPointErrorMessage;

                    return Validate(() => decimal.TryParse(valueAsString, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result), validationContext.MemberName);
                }
                case WorldVariableType.Integer:
                {
                    long result;

                    ErrorMessage = IntegerErrorMessage;

                    return Validate(() => long.TryParse(valueAsString, out result), validationContext.MemberName);
                }
                case WorldVariableType.String:
                    return ValidationResult.Success;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private ValidationResult Validate(Func<bool> @delegate, string memberName)
        {
            return @delegate() ? ValidationResult.Success : new ValidationResult(ErrorMessageString, new[] { memberName });
        }
    }
}