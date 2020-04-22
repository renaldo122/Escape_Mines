using Escape_Mines.Common.Extensions;
using Escape_Mines.Common.Objects;
using Escape_Mines.Services.Base;
using Escape_Mines.Services.FileConfiguration;
using System;
using System.Collections.Generic;

namespace Escape_Mines.Services.Board
{
    public class BoardServices : BaseService, IBoardServices
    {

        #region Fields
        private readonly IFileConfigurationServices _fileConfigurationServices;
        #endregion

        #region Constructor

        /// <summary>
        /// Ctor
        /// </summary>
        public BoardServices() : base() => _fileConfigurationServices = Factory.fileConfigurationServices;
        #endregion

        #region Methods

        /// <inheritdoc />
        public BoardData GetBoard()
        {

            string[] boardData = _fileConfigurationServices.GetSingleConfigurationDataFile(1).Split(' ');
            return new BoardData() { Width = boardData[0].ToInt32(), Height = boardData[1].ToInt32() };

        }

        /// <inheritdoc />
        public Coordinate GetExitBoard()
        {
            string[] eixtData = _fileConfigurationServices.GetSingleConfigurationDataFile(3).Split(' ');
            return new Coordinate() { X = eixtData[0].ToInt32(), Y = eixtData[1].ToInt32() };
        }

        /// <inheritdoc />
        public IEnumerable<Coordinate> GetBoardMines()
        {
            List<Coordinate> mines = new List<Coordinate>();
            string[] minesData = _fileConfigurationServices.GetSingleConfigurationDataFile(2).Split(' ');
            foreach (string mineItem in minesData)
            {
                string[] mine = mineItem.Split(',');
                if (mine.Length > 1)
                {
                    mines.Add(new Coordinate() { X = mine[0].ToInt32(), Y = mine[1].ToInt32() });
                }
            }
            return mines;
        }

        #endregion

    }
}
