using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using Escape_Mines.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Escape_Mines.Tests.Services.MovePlayer
{
    [TestClass]
    public class MovePlayerService : BaseTestInitalizer
    {
        [TestInitialize]
        public override void SetupTest()
        {

        }
        private readonly GameSetting gameSetting = new GameSetting()
        {
            boardData = new BoardData
            {
                Width = 5,
                Height = 4
            },
            mineCoordinates = new List<Coordinate>()  {
                new Coordinate() { X = 1, Y = 1 },
                new Coordinate() { X = 3, Y = 1 },
                new Coordinate() { X = 3, Y = 3 }
            },

            player = new PlayerData
            {
                startPosition = new Coordinate
                {
                    X = 0,
                    Y = 1
                },
                direction = Direction.N
            },
            exitBoard = new Coordinate
            {
                X = 4,
                Y = 2
            },
            playerMoves = new List<List<PlayerMove>>{
                new List<PlayerMove>() { PlayerMove.R, PlayerMove.M, PlayerMove.L, PlayerMove.M, PlayerMove.M },
                new List<PlayerMove>() { PlayerMove.M, PlayerMove.R, PlayerMove.M, PlayerMove.M, PlayerMove.M,
                    PlayerMove.R, PlayerMove.M, PlayerMove.M,PlayerMove.M,PlayerMove.R,PlayerMove.M },
            },
            IsValidSettings = false,
            InValidSettingsMessage = ""
        };

        [TestMethod]
        [DataRow(Direction.N, 0, 0)]
        [DataRow(Direction.W, 0, 1)]
        public void TryMovePlayerForwardTest(Direction direction, int startPosX, int startPosY)
        {
            gameSetting.player.direction = direction;

            _movePlayerForwardService.TryMovePlayer(gameSetting);

            startPosX.ShouldEqual(gameSetting.player.startPosition.X);
            startPosY.ShouldEqual(gameSetting.player.startPosition.Y);

        }

        [TestMethod]
        [DataRow(Direction.N, Direction.W)]
        [DataRow(Direction.W, Direction.S)]
        [DataRow(Direction.S, Direction.E)]
        [DataRow(Direction.E, Direction.N)]
        public void TryMovePlayerLeftTest(Direction startDirection, Direction exptDirection)
        {
            gameSetting.player.direction = startDirection;
            _movePlayerLeftService.TryMovePlayer(gameSetting);

            gameSetting.player.direction.ShouldEqual(exptDirection);

        }

        [TestMethod]
        [DataRow(Direction.W, Direction.N)]
        [DataRow(Direction.N, Direction.E)]
        [DataRow(Direction.E, Direction.S)]
        [DataRow(Direction.S, Direction.W)]
        public void TryMovePlayerRightTest(Direction startDirection, Direction exptDirection)
        {
            gameSetting.player.direction = startDirection;
            _movePlayerRightService.TryMovePlayer(gameSetting);

            gameSetting.player.direction.ShouldEqual(exptDirection);
        }
    }
}
