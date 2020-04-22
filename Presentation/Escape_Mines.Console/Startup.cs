using Autofac;
using Escape_Mines.Services.Board;
using Escape_Mines.Services.Factory.Object;
using Escape_Mines.Services.FileConfiguration;
using Escape_Mines.Services.GameSettings;
using Escape_Mines.Services.MovePlayer;
using Escape_Mines.Services.Player;

namespace Escape_Mines
{
    public static class Startup
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BoardServices>().As<IBoardServices>().InstancePerLifetimeScope();
            builder.RegisterType<FileConfigurationServices>().As<IFileConfigurationServices>().InstancePerLifetimeScope();
            builder.RegisterType<PlayerServices>().As<IPlayerServices>().InstancePerLifetimeScope();
            builder.RegisterType<GameSettingsServices>().As<IGameSettingsServices>().InstancePerLifetimeScope();
            builder.RegisterType<MovePlayerForwardService>().As<IMovePlayerService>().InstancePerLifetimeScope();
            builder.RegisterType<MovePlayerLeftService>().As<IMovePlayerService>().InstancePerLifetimeScope();
            builder.RegisterType<MovePlayerRightService>().As<IMovePlayerService>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectFactory>().AsImplementedInterfaces();
            return builder.Build();
        }

    }
}
