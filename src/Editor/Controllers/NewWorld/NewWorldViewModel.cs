using System;
using System.ComponentModel.DataAnnotations;
using NathanAlden.TextAdventure.Common.Models;

namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    public class NewWorldViewModel : Model
    {
        private string _author;
        private string _id;
        private string _version;
        private string _worldName;

        [Required(AllowEmptyStrings = false, ErrorMessage = "ID required.")]
        [RegularExpression("^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$", ErrorMessage = "Invalid ID.")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value?.Trim();
                ValidateProperty();
                OnPropertyChanged();
            }
        }

        public Guid IdAsGuid
        {
            get { return Guid.Parse(Id); }
            set { Id = value.ToString("D"); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "World name required.")]
        public string WorldName
        {
            get { return _worldName; }
            set
            {
                _worldName = value?.Trim();
                ValidateProperty();
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value?.Trim();
                OnPropertyChanged();
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Version required.")]
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value?.Trim();
                ValidateProperty();
                OnPropertyChanged();
            }
        }
    }
}