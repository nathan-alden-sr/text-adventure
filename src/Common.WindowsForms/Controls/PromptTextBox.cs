using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Controls
{
    public class PromptTextBox : TextBox, IToolTipDestination
    {
        private static readonly Color _defaultPromptColor = SystemColors.ControlDark;

        private readonly Label _promptLabel = new Label
                                              {
                                                  AutoSize = false,
                                                  BackColor = Color.Transparent,
                                                  Cursor = Cursors.IBeam,
                                                  Visible = false
                                              };

        private Color _promptForeColor = _defaultPromptColor;
        private string _promptText = "";

        public PromptTextBox()
        {
            _promptLabel.MouseDown += (sender, args) =>
                                      {
                                          if (args.Button == MouseButtons.Left)
                                          {
                                              Focus();
                                          }
                                      };
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The prompt text.")]
        [DefaultValue("")]
        public string PromptText
        {
            get { return _promptText; }
            set
            {
                _promptText = value;
                _promptLabel.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The foreground color of the prompt text.")]
        public Color PromptForeColor
        {
            get { return _promptForeColor; }
            set
            {
                _promptForeColor = value;
                _promptLabel.ForeColor = _promptForeColor;
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                UpdatePrompt();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                UpdatePrompt();
            }
        }

        public IEnumerable<Control> AdditionalDestinations => new[] { _promptLabel };

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializePromptColor()
        {
            return PromptForeColor == _defaultPromptColor;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetPromptColor()
        {
            PromptForeColor = _defaultPromptColor;
        }

        protected override void OnCreateControl()
        {
            Controls.Add(_promptLabel);

            base.OnCreateControl();

            UpdatePrompt();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            UpdatePrompt();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            UpdatePrompt();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            UpdatePrompt();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdatePrompt();
        }

        private void UpdatePrompt()
        {
            _promptLabel.Font = new Font(Font, FontStyle.Italic);
            _promptLabel.Visible = !DesignMode && TextLength == 0 && !Focused;

            int offset = this.GetTextBaseline() - _promptLabel.GetTextBaseline() - (Height - ClientSize.Height) / 2;

            _promptLabel.SetBounds(0, offset, ClientSize.Width, ClientSize.Height - offset);
        }
    }
}