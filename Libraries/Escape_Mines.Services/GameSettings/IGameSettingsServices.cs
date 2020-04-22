using Escape_Mines.Common.Common;
using Escape_Mines.Common.Objects;
using System.Collections.Generic;

namespace Escape_Mines.Services.GameSettings
{
    public interface IGameSettingsServices
    {

        /// <summary>
        /// Start game with all input configuration file preconfigured
        /// </summary>
        /// <param name="gameSetting"></param>
        /// <returns></returns>
        IEnumerable<GameResult> StartGame(GameSetting gameSetting);


        /// <summary>
        /// Get status result based on game settings
        /// </summary>
        /// <param name="gameSetting"></param>
        /// <returns></returns>
        StatusResult GetStatusResult(GameSetting gameSetting);


        /// <summary>
        /// Load all game settings from configuration file 
        /// </summary>
        /// <returns></returns>
        GameSetting LoadGameSettings();


        /// <summary>
        /// Validate Game Settings
        /// </summary>
        /// <param name="gameSetting"></param>
        /// <returns></returns>
        GameSetting ValidateGameSettings(GameSetting gameSetting);
    }
}
