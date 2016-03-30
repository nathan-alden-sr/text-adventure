using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public interface IFormFactory
    {
        T Create<T>()
            where T : Form;
    }
}