using System.Reflection;
using System.Windows.Forms;
using Autofac;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.Commands;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Ioc
{
    public static class AutofacRegistry
    {
        private static readonly Assembly _programAssembly = typeof(Program).Assembly;

        public static void RegisterComponents(ContainerBuilder containerBuilder)
        {
            containerBuilder.ThrowIfNull(nameof(containerBuilder));

            RegisterCommands(containerBuilder);
            RegisterCommon(containerBuilder);
            RegisterEditor(containerBuilder);
            RegisterForms(containerBuilder);
        }

        private static void RegisterCommands(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(_programAssembly).Where(x => x.ImplementsInterface<ICommand>()).AsSelf().SingleInstance();
        }

        private static void RegisterCommon(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<GuidFactory>().As<IGuidFactory>().SingleInstance();
            containerBuilder.RegisterType<SystemClock>().As<ISystemClock>().SingleInstance();
        }

        private static void RegisterEditor(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Models.Editor.Editor>().As<IEditor>().SingleInstance();
        }

        private static void RegisterForms(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(_programAssembly).Where(x => x.IsSubclassOf(typeof(Form))).AsSelf();
        }
    }
}