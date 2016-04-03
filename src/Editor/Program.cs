using System;
using System.Windows.Forms;
using Autofac;
using NathanAlden.TextAdventure.Editor.Controllers.World;
using NathanAlden.TextAdventure.Editor.Ioc;

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
            var worldController = container.Resolve<IWorldController>();

            worldController.ShowView();
        }
    }
}