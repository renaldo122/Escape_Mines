using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using System.Collections.Generic;

namespace Escape_Mines.Services.Player
{
    public interface IPlayerServices
    {


        /// <summary>
        /// Get all player moves for game
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEnumerable<PlayerMove>> GetPlayerMove();


        /// <summary>
        /// Get player data like direction and star position 
        /// </summary>
        /// <returns></returns>
        PlayerData GetPlayerData();


        /// <summary>
        /// Find direction based on factory methodology 
        /// </summary>
        /// <param name="playerMove"></param>
        /// <param name="gameSetting"></param>
        void FindDirectionToMove(PlayerMove playerMove, GameSetting gameSetting);
    }
}
