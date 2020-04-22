using Escape_Mines.Services.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape_Mines.Services.Base;
using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using Escape_Mines.Services.Player;
using Escape_Mines.Common.Exceptions;

namespace Escape_Mines.Services.GameSettings
{
    public class GameSettingsServices : BaseService, IGameSettingsServices
    {
        #region Fields

        private readonly IBoardServices _boardServices;
        private readonly IPlayerServices _playerServices;

        #endregion

        #region Constructor

        /// <summary>
        /// Ctor
        /// </summary>
        public GameSettingsServices(IPlayerServices playerServices) : base()
        {
            _boardServices = Factory.boardServices;
            _playerServices = playerServices;
        }

        #endregion


        #region Methods

        /// <inheritdoc />
        public IEnumerable<GameResult> StartGame(GameSetting gameSetting)
        {

            ValidateGameSettings(gameSetting);

            List<GameResult> gameResults = new List<GameResult>();

            StatusResult statusResult;

            Coordinate startPossition = new Coordinate() { X = gameSetting.player.startPosition.X, Y = gameSetting.player.startPosition.Y };

            Direction startDirection = gameSetting.player.direction;

            foreach (IEnumerable<PlayerMove> playerMoves in gameSetting.playerMoves)
            {
                statusResult = StatusResult.StillInDanger;
                gameSetting.player.startPosition = startPossition;
                gameSetting.player.direction = startDirection;

                foreach (PlayerMove playerMove in playerMoves)
                {
                    _playerServices.FindDirectionToMove(playerMove, gameSetting);

                    statusResult = GetStatusResult(gameSetting);

                    if (statusResult != StatusResult.StillInDanger)
                    {
                        break;
                    }
                }

                gameResults.Add(new GameResult() { playerMoves = playerMoves, statusResult = statusResult });
            }


            return gameResults;
        }


        /// <inheritdoc />
        public StatusResult GetStatusResult(GameSetting gameSetting)
        {
            StatusResult statusResult = StatusResult.StillInDanger;


            bool mineHit = gameSetting.mineCoordinates.Where(h => h.X == gameSetting.player.startPosition.X
                                && h.Y == gameSetting.player.startPosition.Y).Any();
            if (mineHit)
            {
                statusResult = StatusResult.MineHit;
            }
            else
            {
                bool isExitFound = gameSetting.player.startPosition.X == gameSetting.exitBoard.X
                                        && gameSetting.player.startPosition.Y == gameSetting.exitBoard.Y;
                if (isExitFound)
                {
                    statusResult = StatusResult.Success;
                }
            }

            return statusResult;
        }



        /// <inheritdoc />
        public GameSetting LoadGameSettings()
        {
            var gameSettings = new GameSetting
            {
                boardData = _boardServices.GetBoard(),
                playerMoves = _playerServices.GetPlayerMove(),
                mineCoordinates = _boardServices.GetBoardMines(),
                player = _playerServices.GetPlayerData(),
                exitBoard = _boardServices.GetExitBoard(),
            };
            return gameSettings;
        }

        /// <inheritdoc />
        public GameSetting ValidateGameSettings(GameSetting gameSetting)
        {

            var exitBoard = gameSetting.exitBoard;
            PlayerData player = gameSetting.player;
           var mineCordinates = gameSetting.mineCoordinates;

            if (exitBoard.X == player.startPosition.X && exitBoard.Y == player.startPosition.Y)
            {
                gameSetting.IsValidSettings = false;
                gameSetting.InValidSettingsMessage = Constants.StartPositionOnExit;
                return gameSetting;
            }
            bool IsStartPositionOnMine = mineCordinates.Any(i => i.X == player.startPosition.X && i.Y == player.startPosition.Y);

            if (IsStartPositionOnMine)
            {
                gameSetting.IsValidSettings = false;
                gameSetting.InValidSettingsMessage = Constants.StartPositionOnMine;
                return gameSetting;
            }

            bool invalidPosition = gameSetting.player.startPosition.X > gameSetting.boardData.Width
                || gameSetting.player.startPosition.Y > gameSetting.boardData.Height;

            if (invalidPosition)
            {
                gameSetting.IsValidSettings = false;
                gameSetting.InValidSettingsMessage = Constants.InvalidPosition;
                return gameSetting;
            }
            return gameSetting;
        }
        #endregion

    }
}
