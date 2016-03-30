using System.Collections.Generic;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Validation
{
    public interface IToolTipDestination
    {
        IEnumerable<Control> AdditionalDestinations { get; }
    }
}