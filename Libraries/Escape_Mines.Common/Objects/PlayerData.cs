using Escape_Mines.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Mines.Common.Objects
{
    public class  PlayerData
    {
        /// <summary>
        /// Starting position of the turtle
        /// </summary>
        public Coordinate startPosition { get; set; }

        /// <summary>
        /// Direction of turtle that will move
        /// </summary>
        public Direction direction { get; set; }
    }
}
