using Escape_Mines.Common.Common;
using Escape_Mines.Services.MovePlayer;
using System.Collections.Generic;
using System.Linq;

namespace Escape_Mines.Services.Factory.Object
{
    public class ObjectFactory : IObjectFactory
    {
        #region Fields

        private readonly IEnumerable<IMovePlayerService> _movePlayerServices;

        #endregion

        #region Constructor

        public ObjectFactory(IEnumerable<IMovePlayerService> movePlayerServices)
        {
            _movePlayerServices = movePlayerServices;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public IMovePlayerService CreateMove(PlayerMove playerMove)
        {
            return _movePlayerServices.Single(item => item.IsMoveValid(playerMove));
        }

        #endregion

    }
}
