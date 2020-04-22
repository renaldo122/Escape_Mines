using Escape_Mines.Common.Common;
using System.Collections.Generic;

namespace Escape_Mines.Common.Objects
{
    public class GameResult
    {

        /// <summary>
        /// Get all player moves to determine status of game
        /// </summary>
        public IEnumerable<PlayerMove> playerMoves { get; set; }

        /// <summary>
        /// Result status of game 
        /// </summary>
        public StatusResult statusResult { get; set; }

    }
}
