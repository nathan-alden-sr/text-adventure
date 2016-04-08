namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public class CategoryFilterViewModel
    {
        public CategoryFilterViewModel(string name, string category, CategoryFilterType type)
        {
            Name = name;
            Category = category;
            Type = type;
        }

        public string Name { get; }
        public string Category { get; }
        public CategoryFilterType Type { get; set; }
    }
}