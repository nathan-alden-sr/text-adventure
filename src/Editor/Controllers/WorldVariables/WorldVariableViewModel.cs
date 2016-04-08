using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using NathanAlden.TextAdventure.Common.Models;
using NathanAlden.TextAdventure.Editor.PairMappers;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public class WorldVariableViewModel : Model
    {
        private string _category;
        private string _name;
        private WorldVariableType _type;
        private string _value;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        [RegularExpression("^[A-Za-z_][0-9A-Za-z_]*$", ErrorMessage = "Invalid name.")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value?.Trim();
                ValidateProperty();
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value?.Trim();
                ValidateProperty();
                OnPropertyChanged();
            }
        }

        public WorldVariableType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                // ReSharper disable once ExplicitCallerInfoArgument
                ValidateProperty(nameof(Value));
                OnPropertyChanged();
            }
        }

        public string TypeDescription => WorldVariableTypePairMapper.Instance.Map(_type);

        [WorldVariableValue(BooleanErrorMessage = "Invalid value. Must be 'true' or 'false'.", CharacterErrorMessage = "Invalid value. Must be a single character.", FixedPointErrorMessage = "Invalid value. Must be a fixed-point number.", IntegerErrorMessage = "Invalid value. Must be an integer.")]
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                ValidateProperty();
                OnPropertyChanged();
            }
        }

        public object TypedValue
        {
            get
            {
                switch (_type)
                {
                    case WorldVariableType.Boolean:
                        return bool.Parse(_value);
                    case WorldVariableType.Character:
                        return char.Parse(_value);
                    case WorldVariableType.FixedPoint:
                        return decimal.Parse(_value, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint);
                    case WorldVariableType.Integer:
                        return int.Parse(_value);
                    case WorldVariableType.String:
                        return _value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public WorldVariableViewModel Clone()
        {
            return new WorldVariableViewModel
                   {
                       Category = _category, Name = _name, Type = _type, Value = _value
                   };
        }
    }
}