using Escape_Mines.Common.Common;
using Escape_Mines.Services.MovePlayer;

namespace Escape_Mines.Services.Factory.Object
{
    public interface IObjectFactory
    {

        /// <summary>
        /// Create move based on player move type
        /// </summary>
        /// <param name="playerMove"></param>
        /// <returns></returns>
        IMovePlayerService CreateMove(PlayerMove playerMove);

    }
}
