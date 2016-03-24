using System.Collections.Generic;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IBoard : IObject
    {
        Coordinate<int> Coordinate { get; }
        Size<int> Size { get; }
        IEnumerable<IObject> Objects { get; }
        IBoardLayerCollection<IBoardLayer> BoardLayers { get; }

        void Prepare();
    }
}