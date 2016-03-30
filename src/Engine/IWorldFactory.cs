using Junior.Common.Net35;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IWorldFactory
    {
        IWorld Create(IGuidFactory guidFactory, JToken worldJsonObject);
    }
}