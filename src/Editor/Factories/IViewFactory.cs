using NathanAlden.TextAdventure.Editor.Controllers;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public interface IViewFactory
    {
        TView Create<TView>()
            where TView : IView;
    }
}