using Escape_Mines.Common.Common;
using System.Collections.Generic;

namespace Escape_Mines.Common.Objects
{  
    public class GameSetting
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public GameSetting()
        {
            boardData = new BoardData();
            mineCoordinates = new List<Coordinate>();
            exitBoard = new Coordinate();
            player = new PlayerData();
            playerMoves = new List<List<PlayerMove>>();
        }
        /// <summary>
        /// The first line should define the board size
        /// </summary>
        public BoardData boardData { get; set; }

        /// <summary>
        /// The second line should contain a list of mines(i.e.list of co-ordinates separated by a space)
        /// </summary>
        public IEnumerable<Coordinate> mineCoordinates { get; set; }

        /// <summary>
        /// The third line of the file should contain the exit point.
        /// </summary>
        public Coordinate exitBoard { get; set; }

        /// <summary>
        /// The fourth line of the file should contain the starting position of the turtle.
        /// </summary>
        public PlayerData player { get; set; }


        /// <summary>
        /// The fifth line to the end of the file should contain a series of moves.
        /// </summary>
        public IEnumerable<IEnumerable<PlayerMove>> playerMoves { get; set; }


        public bool IsValidSettings { get; set; } = true;


        public string InValidSettingsMessage { get; set; }
    }
}
