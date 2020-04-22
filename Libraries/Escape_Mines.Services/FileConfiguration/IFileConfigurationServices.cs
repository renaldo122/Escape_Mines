using System.Collections.Generic;

namespace Escape_Mines.Services.FileConfiguration
{
    public interface IFileConfigurationServices
    {

        /// <summary>
        /// Get single line from configuration file
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        string GetSingleConfigurationDataFile(int line);


        /// <summary>
        /// Get all lines from configuration file
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        IEnumerable<string> GetMultipleConfigurationDataFile(int line);
    }
}
