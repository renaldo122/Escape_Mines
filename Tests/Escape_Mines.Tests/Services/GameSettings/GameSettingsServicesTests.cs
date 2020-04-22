using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Escape_Mines.Tests.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Escape_Mines.Tests.Services.GameSettings
{
    [TestClass]
    public class GameSettingsServicesTests : BaseTestInitalizer
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
            IsValidSettings = true
        };


        private static void ChangeConfiguration()
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location);
            var appSettings = (AppSettingsSection)config.GetSection("appSettings");
            appSettings.Settings.Clear();
            appSettings.Settings.Add(Constants.AppSettingsKey, TestConfigs.AppSettingsValue);
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        [TestMethod]
        public void StartGameMineHitTest()
        {
            ChangeConfiguration();

            GameSetting mockGameSetting = GetGameSettingsMockUpDataTest();

            mockGameSetting.playerMoves = new List<List<PlayerMove>>
            {
                  new List<PlayerMove>() { PlayerMove.R, PlayerMove.M, PlayerMove.L, PlayerMove.M, PlayerMove.M },
            };

            IEnumerable<GameResult> gameResults = _gameSettingsServices.StartGame(mockGameSetting);

            gameResults.FirstOrDefault().statusResult.ShouldEqual(StatusResult.MineHit);

        }
        [TestMethod]
        public void StartGameSuccessTest()
        {
            ChangeConfiguration();

            GameSetting mockGameSetting = GetGameSettingsMockUpDataTest();

            mockGameSetting.playerMoves = new List<List<PlayerMove>>
            {
                  new List<PlayerMove>() { PlayerMove.M, PlayerMove.R, PlayerMove.M, PlayerMove.M, PlayerMove.R ,PlayerMove.M,PlayerMove.M,
                  PlayerMove.L,PlayerMove.M,PlayerMove.M},
            };
            IEnumerable<GameResult> gameResults = _gameSettingsServices.StartGame(mockGameSetting);

            gameResults.FirstOrDefault().statusResult.ShouldEqual(StatusResult.Success);

        }

        [TestMethod]
        public void StartGameStillInDangerTest()
        {
            ChangeConfiguration();

            GameSetting mockGameSetting = GetGameSettingsMockUpDataTest();

            mockGameSetting.playerMoves = new List<List<PlayerMove>>
            {
                  new List<PlayerMove>() { PlayerMove.M, PlayerMove.R, PlayerMove.M, PlayerMove.M, PlayerMove.R ,PlayerMove.M,PlayerMove.M,
                  PlayerMove.R,PlayerMove.M,PlayerMove.M},
            };
            IEnumerable<GameResult> gameResults = _gameSettingsServices.StartGame(mockGameSetting);

            gameResults.FirstOrDefault().statusResult.ShouldEqual(StatusResult.StillInDanger);

        }


        [TestMethod]
        public void LoadGameSettingsTest()
        {
            ChangeConfiguration();

            GameSetting mockGameSetting = GetGameSettingsMockUpDataTest();

            mockGameSetting.ShouldNotBeEqualObj(gameSetting);

        }

        [DataRow(0, 1, StatusResult.StillInDanger)]
        [DataRow(0, 3, StatusResult.StillInDanger)]
        [DataRow(3, 1, StatusResult.MineHit)]
        [DataRow(1, 1, StatusResult.MineHit)]
        [DataRow(3, 3, StatusResult.MineHit)]
        [DataRow(4, 2, StatusResult.Success)]
        [TestMethod]
        public void GetStatusResultTest(int playerStartPossitionX, int playerStartPositionY, StatusResult expStatus)
        {
            gameSetting.player.startPosition.X = playerStartPossitionX;
            gameSetting.player.startPosition.Y = playerStartPositionY;

            StatusResult statusResult = _gameSettingsServices.GetStatusResult(gameSetting);

            statusResult.ShouldEqual(expStatus);
        }


        [TestMethod]
        public void GetBoardMinesExeptionTest()
        {
            ChangeConfiguration();

            gameSetting.player.startPosition = new Coordinate() { X = 1, Y = 1 };

            GameSetting mockGameSetting = _gameSettingsServices.ValidateGameSettings(gameSetting);

            mockGameSetting.InValidSettingsMessage.ShouldEqual(Constants.StartPositionOnMine);

        }


        [TestMethod]
        public void GetBoardExitExeptionTest()
        {
            ChangeConfiguration();

            gameSetting.player.startPosition = new Coordinate() { X = 4, Y = 2 };

            GameSetting mockGameSetting = _gameSettingsServices.ValidateGameSettings(gameSetting);

            mockGameSetting.InValidSettingsMessage.ShouldEqual(Constants.StartPositionOnExit);

        }
    }
}

