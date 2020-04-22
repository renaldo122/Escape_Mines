using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using Escape_Mines.Services.Board;
using Escape_Mines.Services.Factory.Object;
using Escape_Mines.Services.GameSettings;
using Escape_Mines.Services.MovePlayer;
using Escape_Mines.Services.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Escape_Mines.Tests
{
    [TestClass]
    public abstract class BaseTestInitalizer
    {
        #region Services


        public Mock<IBoardServices> _mockBoardServices;
        public Mock<IPlayerServices> _mockPlayerServices;
        public Mock<IObjectFactory> _mockObjectFactory;
        public Mock<IMovePlayerService> _mockMovePlayerService;
        public ObjectFactory _objectFactory;

        public GameSettingsServices _gameSettingsServices;
        public PlayerServices _playerServices;
        public MovePlayerLeftService _movePlayerLeftService;
        public MovePlayerRightService _movePlayerRightService;
        public MovePlayerForwardService _movePlayerForwardService;

        public List<IMovePlayerService> _movePlayerService = new List<IMovePlayerService>();

        #endregion

        #region Initialize

        [TestInitialize]
        public virtual void Initialize()
        {
            _mockBoardServices = new Mock<IBoardServices>();
            _mockPlayerServices = new Mock<IPlayerServices>();
            _mockObjectFactory = new Mock<IObjectFactory>();
            _mockMovePlayerService = new Mock<IMovePlayerService>();
            _movePlayerLeftService = new MovePlayerLeftService();
            _movePlayerRightService = new MovePlayerRightService();
            _movePlayerForwardService = new MovePlayerForwardService();
            _movePlayerService.Add(_movePlayerLeftService);
            _movePlayerService.Add(_movePlayerRightService);
            _movePlayerService.Add(_movePlayerForwardService);
            _objectFactory = new ObjectFactory(_movePlayerService);
            _playerServices = new PlayerServices(_objectFactory);
            _gameSettingsServices = new GameSettingsServices(_playerServices);
            
        }

        #endregion


        [TestCleanup]
        public void Cleanup()
        {
        }


        public GameSetting GetGameSettingsMockUpDataTest()
        {
            _mockBoardServices.Setup(x => x.GetBoard()).Returns(new BoardData() { Width = 5, Height = 4 });
            _mockBoardServices.Setup(x => x.GetBoardMines()).Returns(new List<Coordinate>()
            {
                new Coordinate() { X = 1, Y = 1 },
                new Coordinate() { X = 3, Y = 1 },
                new Coordinate() { X = 3, Y = 3 }
            });
            _mockBoardServices.Setup(x => x.GetExitBoard()).Returns(new Coordinate() { X = 4, Y = 2 });
            _mockPlayerServices.Setup(x => x.GetPlayerData()).Returns(new PlayerData() { startPosition = new Coordinate() { X = 0, Y = 1 }, direction = Direction.N });
            _mockPlayerServices.Setup(x => x.GetPlayerMove()).Returns(new List<List<PlayerMove>>
            {
                  new List<PlayerMove>() { PlayerMove.R, PlayerMove.M, PlayerMove.L, PlayerMove.M, PlayerMove.M },
                  new List<PlayerMove>() { PlayerMove.M, PlayerMove.R, PlayerMove.M, PlayerMove.M, PlayerMove.M,  PlayerMove.R, PlayerMove.M, PlayerMove.M,PlayerMove.M,PlayerMove.R,PlayerMove.M }
            });

            GameSetting mockGameSetting = _gameSettingsServices.LoadGameSettings();
            return mockGameSetting;
        }
        public abstract void SetupTest();
    }

}
