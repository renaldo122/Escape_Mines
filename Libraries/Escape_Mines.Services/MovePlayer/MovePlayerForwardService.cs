using Escape_Mines.Common.Common;
using Escape_Mines.Common.Exceptions;
using Escape_Mines.Common.Objects;

namespace Escape_Mines.Services.MovePlayer
{
    public class MovePlayerForwardService : IMovePlayerService
    {
        #region Methods

        /// <inheritdoc />
        public bool IsMoveValid(PlayerMove move)
        {
            return move == PlayerMove.M;
        }

        /// <inheritdoc />
        public void TryMovePlayer(GameSetting gameSetting)
        {
            Coordinate newPossition = GetNextPositionToMove(gameSetting.player);

            bool isValid = newPossition.X >= 0 && newPossition.X <= gameSetting.boardData.Width
                && newPossition.Y >= 0 && newPossition.Y <= gameSetting.boardData.Height;

            if (isValid)
            {
                gameSetting.player.startPosition = newPossition;
            }
        }

        /// <summary>
        /// Get new position to move based on player possition
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private Coordinate GetNextPositionToMove(PlayerData player)
        {
            Coordinate nextCoordinate;

            switch (player.direction)
            {
                case (Direction.N):
                    nextCoordinate = new Coordinate() { X = player.startPosition.X, Y = player.startPosition.Y - 1 };
                    break;
                case (Direction.E):
                    nextCoordinate = new Coordinate() { X = player.startPosition.X + 1, Y = player.startPosition.Y };
                    break;
                case (Direction.S):
                    nextCoordinate = new Coordinate() { X = player.startPosition.X, Y = player.startPosition.Y + 1 };
                    break;
                case (Direction.W):
                    nextCoordinate = new Coordinate() { X = player.startPosition.X - 1, Y = player.startPosition.Y };
                    break;
                default:
                    throw new EscapeMinesException(Constants.DirectionNotFound);
            }

            return nextCoordinate;
        }
        #endregion

    }
}
