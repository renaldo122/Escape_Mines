using System.ComponentModel;

namespace Escape_Mines.Common.Common
{
    public enum StatusResult
    {
        [Description("If the turtle finds the exit point")]
        Success = 1,
        [Description("If the turtle hits a mine")]
        MineHit = 2,
        [Description("If the turtle has not yet found the exit or hit a mine")]
        StillInDanger = 3
    }
    public enum Direction
    {
        [Description("North direction")]
        N = 1,
        [Description("East  direction")]
        E = 2,
        [Description("South  direction")]
        S = 3,
        [Description("West  direction")]
        W = 4
    }

    public enum PlayerMove
    {
        [Description("Rotate 90 degrees to the right")]
        R = 1,
        [Description("Rotate 90 degrees to the left")]
        L = 2,
        [Description("Move next")]
        M = 3
    }
}
