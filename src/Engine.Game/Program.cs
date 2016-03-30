using System;
using CommandLine;

namespace NathanAlden.TextAdventure.Engine.Game
{
#if WINDOWS || LINUX
    internal static class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {
            ParserResult<CommandLineOptions> commandLineOptions = Parser.Default.ParseArguments<CommandLineOptions>(args);

            return commandLineOptions.MapResult(
                options =>
                {
                    var worldDirectory = new WorldDirectory(options.WorldDirectory);

                    using (var game = new TextAdventureGame(worldDirectory))
                    {
                        game.Run();
                    }

                    return 0;
                },
                errors => 1);
        }
    }
#endif
}