using Escape_Mines.Common.Common;
using Escape_Mines.Services.Board;
using Escape_Mines.Services.Factory.Object;
using Escape_Mines.Services.FileConfiguration;
using Escape_Mines.Services.MovePlayer;
using Escape_Mines.Services.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Mines.Services.Factory.Service
{
    public class ServiceFactory : IServiceFactory
    {
        /// <inheritdoc />
        public IBoardServices boardServices { get => new BoardServices(); }

        /// <inheritdoc />
        public IFileConfigurationServices fileConfigurationServices { get => new FileConfigurationServices(); }


    }
}
