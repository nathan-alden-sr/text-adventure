using CommandLine;

namespace NathanAlden.TextAdventure.Engine.Game
{
    public class CommandLineOptions
    {
        [Option("WorldDirectory", Required = true)]
        public string WorldDirectory { get; set; }
    }
}