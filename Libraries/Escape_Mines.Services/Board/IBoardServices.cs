using Escape_Mines.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Mines.Services.Board
{
    public interface IBoardServices
    {

        /// <summary>
        /// Get all mines cordinates in board
        /// </summary>
        /// <returns></returns>
        BoardData GetBoard();


        /// <summary>
        /// Get exit cordinate in board
        /// </summary>
        /// <returns></returns>
        Coordinate GetExitBoard();



        /// <summary>
        /// Get list of coordinates of all mines in board
        /// </summary>
        /// <returns></returns>
        IEnumerable<Coordinate> GetBoardMines();
    }
}
