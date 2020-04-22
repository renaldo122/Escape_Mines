using System.Linq;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using Escape_Mines.Common.Exceptions;
using Escape_Mines.Common.Common;

namespace Escape_Mines.Services.FileConfiguration
{
    public class FileConfigurationServices : IFileConfigurationServices
    {

        #region Methods

        /// <inheritdoc />
        public string GetSingleConfigurationDataFile(int line)
        {
            return File.ReadLines(GetConfigurationFilePath()).Skip(line - 1).First();
        }


        /// <inheritdoc />
        public IEnumerable<string> GetMultipleConfigurationDataFile(int line)
        {
            return File.ReadLines(GetConfigurationFilePath()).Skip(line - 1);
        }


        /// <summary>
        /// Get configuration file path from App.config
        /// </summary>
        /// <returns></returns>
        private string GetConfigurationFilePath()
        {
            string fileConfigPath = ConfigurationManager.AppSettings[Constants.AppSettingsKey];
            if (File.Exists(fileConfigPath))
                return fileConfigPath;
            else
                throw new EscapeMinesException("Configuration file path not found at App.config");
        }

        #endregion

    }
}
