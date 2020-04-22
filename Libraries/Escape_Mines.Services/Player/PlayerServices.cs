using Escape_Mines.Common.Common;
using Escape_Mines.Common.Extensions;
using Escape_Mines.Common.Objects;
using Escape_Mines.Services.Base;
using Escape_Mines.Services.Factory.Object;
using Escape_Mines.Services.FileConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escape_Mines.Services.Player
{
    public class PlayerServices : BaseService, IPlayerServices
    {

        #region Fields
        private readonly IObjectFactory _objectFactory;
        private readonly IFileConfigurationServices _fileConfigurationServices;
        #endregion

        #region Constructor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="objectFactory"></param>
        public PlayerServices(IObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
            _fileConfigurationServices = Factory.fileConfigurationServices;
        }

        #endregion

        #region Methods


        /// <inheritdoc />
        public IEnumerable<IEnumerable<PlayerMove>> GetPlayerMove()
        {
            List<List<PlayerMove>> allMoves = new List<List<PlayerMove>>();
            IEnumerable<string> playerMoves = _fileConfigurationServices.GetMultipleConfigurationDataFile(5);
            playerMoves.ToList().ForEach(playerLine =>
            {
                List<PlayerMove> movesList= new List<PlayerMove>();

                playerLine.Split(' ').ToList().ForEach(x =>
                {
                    if(!string.IsNullOrEmpty(x)) movesList.Add((PlayerMove)Enum.Parse(typeof(PlayerMove), x));
                });

                allMoves.Add(movesList);
            });

            return allMoves;
        }


        /// <inheritdoc />
        public PlayerData GetPlayerData()
        {
            string[] startPossition = _fileConfigurationServices.GetSingleConfigurationDataFile(4).Split(' ');

            Direction initialDirection = (Direction)Enum.Parse(typeof(Direction), startPossition[2]);

            return new PlayerData()
            {
                direction = initialDirection,
                startPosition = new Coordinate() { X = startPossition[0].ToInt32(), Y = startPossition[1].ToInt32() }
            };
        }


        /// <inheritdoc />
        public void FindDirectionToMove(PlayerMove playerMove, GameSetting gameSetting)
        {
            _objectFactory.CreateMove(playerMove).TryMovePlayer(gameSetting);
        }
        #endregion

    }
}
