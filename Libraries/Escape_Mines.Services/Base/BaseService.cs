using Escape_Mines.Services.Factory.Service;

namespace Escape_Mines.Services.Base
{
    public abstract class BaseService
    {
        private IServiceFactory _factory;
        public IServiceFactory Factory => _factory = new ServiceFactory();

    }
}
