using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;

namespace Escape_Mines.Services.MovePlayer
{
    public interface IMovePlayerService
    {

        /// <summary>
        /// Check if moves is valid
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        bool IsMoveValid(PlayerMove move);


        /// <summary>
        /// Try to move player based on game settings
        /// </summary>
        /// <param name="gameSetting"></param>
        void TryMovePlayer(GameSetting gameSetting);
    }
}
