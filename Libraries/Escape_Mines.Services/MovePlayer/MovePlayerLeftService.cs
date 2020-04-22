using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using System;

namespace Escape_Mines.Services.MovePlayer
{
    public class MovePlayerLeftService : IMovePlayerService
    {

        #region Methods
        /// <inheritdoc />
        public bool IsMoveValid(PlayerMove move)
        {
            return move == PlayerMove.L;
        }


        /// <inheritdoc />
        public void TryMovePlayer(GameSetting gameSetting)
        {
            Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));

            int index = Array.IndexOf(directions, gameSetting.player.direction) - 1;
            gameSetting.player.direction = (index == -1) ? directions[directions.Length - 1] : directions[index];

        }
        #endregion

    }
}
