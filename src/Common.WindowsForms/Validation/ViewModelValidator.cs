using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.Models;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Validation
{
    public class ViewModelValidator
    {
        public static void AttachControlDecoratorsRecursive<TModel, TControl, TControlDecorator>(TModel model, Control control, TControlDecorator decorator)
            where TModel : Model
            where TControl : Control
            where TControlDecorator : IControlDecorator<TControl>
        {
            model.ThrowIfNull(nameof(model));
            control.ThrowIfNull(nameof(control));

            BoundControl<TControl>[] boundControls = GetControlsBoundToModel<TModel, TControl>(control, true).ToArray();

            model.ErrorsChanged += (sender, args) =>
                                   {
                                       IEnumerable<TControl> controls = boundControls.Where(x => x.PropertyName == args.PropertyName).Select(x => x.Control);

                                       decorator.Decorate(controls, !model.Errors.ContainsKey(args.PropertyName));
                                   };
        }

        public static void AttachControlDecoratorsRecursive<TModel, TControl, TControlDecorator>(TModel model, Control control)
            where TModel : Model
            where TControl : Control
            where TControlDecorator : IControlDecorator<TControl>, new()
        {
            AttachControlDecoratorsRecursive<TModel, TControl, TControlDecorator>(model, control, new TControlDecorator());
        }

        public static void AttachToolTipRecursive<TModel, TControl>(Model model, Control control, ToolTip toolTip)
            where TModel : Model
            where TControl : Control
        {
            model.ThrowIfNull(nameof(model));
            control.ThrowIfNull(nameof(control));
            toolTip.ThrowIfNull(nameof(toolTip));

            BoundControl<TControl>[] boundControls = GetControlsBoundToModel<TModel, TControl>(control, true).ToArray();

            model.ErrorsChanged +=
                (sender, args) =>
                {
                    IEnumerable<TControl> controls = boundControls.Where(x => x.PropertyName == args.PropertyName).Select(x => x.Control);

                    foreach (TControl destination in controls)
                    {
                        IEnumerable<string> errors;
                        string caption = model.Errors.TryGetValue(args.PropertyName, out errors) ? GetToolTipMessage(errors) : null;

                        toolTip.SetToolTip(destination, caption);

                        foreach (Control additionalDestination in (destination as IToolTipDestination)?.AdditionalDestinations ?? Enumerable.Empty<Control>())
                        {
                            toolTip.SetToolTip(additionalDestination, caption);
                        }
                    }
                };
        }

        public static void AttachToolTip(Model model, Control destination, ToolTip toolTip)
        {
            model.ThrowIfNull(nameof(model));
            destination.ThrowIfNull(nameof(destination));
            toolTip.ThrowIfNull(nameof(toolTip));

            model.ErrorsChanged += (sender, args) =>
                                   {
                                       string caption = model.HasErrors ? GetToolTipMessage(model.Errors.SelectMany(x => x.Value)) : null;

                                       toolTip.SetToolTip(destination, caption);
                                   };
        }

        private static IEnumerable<BoundControl<TControl>> GetControlsBoundToModel<TModel, TControl>(Control control, bool recursive)
            where TModel : Model
            where TControl : Control
        {
            var boundControls = new List<BoundControl<TControl>>();
            var convertedControl = control as TControl;

            if (convertedControl != null && control.DataBindings.Count > 0)
            {
                Binding binding = control.DataBindings[0];
                var dataSource = (BindingSource)binding.DataSource;
                var model = dataSource.DataSource as TModel;

                if (model != null)
                {
                    boundControls.Add(new BoundControl<TControl>(convertedControl, binding.BindingMemberInfo.BindingMember));
                }
            }

            if (recursive)
            {
                foreach (Control childControl in control.Controls)
                {
                    boundControls.AddRange(GetControlsBoundToModel<TModel, TControl>(childControl, true));
                }
            }

            return boundControls;
        }

        private static string GetToolTipMessage(IEnumerable<string> errors)
        {
            return string.Join(Environment.NewLine, errors);
        }

        private class BoundControl<TControl>
            where TControl : Control
        {
            public BoundControl(TControl control, string propertyName)
            {
                Control = control;
                PropertyName = propertyName;
            }

            public TControl Control { get; }
            public string PropertyName { get; }
        }
    }
}