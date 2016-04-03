using System.IO;
using System.Reflection;
using Autofac;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Editor.Factories;

namespace NathanAlden.TextAdventure.Editor.Ioc
{
    public static class AutofacRegistry
    {
        private static readonly Assembly _programAssembly = typeof(Program).Assembly;

        public static void RegisterComponents(ContainerBuilder containerBuilder)
        {
            containerBuilder.ThrowIfNull(nameof(containerBuilder));

            RegisterCommon(containerBuilder);
            RegisterControllers(containerBuilder);
            RegisterViews(containerBuilder);
        }

        private static void RegisterCommon(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<GuidFactory>().As<IGuidFactory>().SingleInstance();
            containerBuilder.RegisterType<SystemClock>().As<ISystemClock>().SingleInstance();
            containerBuilder.RegisterInstance(new ConfigFile<Config>(Path.Combine(Constants.RootDirectory, "config.json"))).As<IConfigFile<Config>>().SingleInstance();
            containerBuilder.RegisterType<FileSystem>().As<IFileSystem>().SingleInstance();
            containerBuilder.RegisterType<MessageBus>().As<IMessageBus>().SingleInstance();
            containerBuilder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
        }

        private static void RegisterControllers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ControllerFactory>().As<IControllerFactory>().SingleInstance();
            RegisterSuffixInProgramAssembly(containerBuilder, "Controller");
        }

        private static void RegisterViews(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            RegisterSuffixInProgramAssembly(containerBuilder, "View");
        }

        private static void RegisterSuffixInProgramAssembly(ContainerBuilder containerBuilder, string suffix)
        {
            containerBuilder.RegisterAssemblyTypes(_programAssembly).Where(x => x.Name.EndsWith(suffix)).AsImplementedInterfaces();
        }
    }
}