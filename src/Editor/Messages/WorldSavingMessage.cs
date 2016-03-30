using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Editor.Messages
{
    public class WorldSavingMessage : Message
    {
        public WorldSavingMessage(bool savingAs)
        {
            SavingAs = savingAs;
        }

        public bool SavingAs { get; }
    }
}