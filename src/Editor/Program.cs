using System;
using System.Windows.Forms;
using Autofac;
using NathanAlden.TextAdventure.Editor.Ioc;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var containerBuilder = new ContainerBuilder();

            AutofacRegistry.RegisterComponents(containerBuilder);

            IContainer container = containerBuilder.Build();
            var editor = container.Resolve<IEditor>();

            Application.Run(editor.WorldEditorForm);
        }
    }
}