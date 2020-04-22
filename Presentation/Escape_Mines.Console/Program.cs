using Autofac;
using Escape_Mines.Common.Objects;
using Escape_Mines.Services.GameSettings;
using System;
using System.Collections.Generic;

namespace Escape_Mines
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var services = Startup.Configure();

            IGameSettingsServices gameSettingsServices = services.Resolve<IGameSettingsServices>();

            GameSetting gameSetting = gameSettingsServices.LoadGameSettings();

             gameSetting = gameSettingsServices.ValidateGameSettings(gameSetting);

            if (!gameSetting.IsValidSettings)
            {
                Console.WriteLine($"Result: { gameSetting.InValidSettingsMessage}");

                Console.WriteLine();
            }
            else
            {
                IEnumerable<GameResult> gameResults = gameSettingsServices.StartGame(gameSetting);

                foreach (GameResult gameResult in gameResults)
                {
                    Console.WriteLine($"Moves {string.Join(",", gameResult.playerMoves)} result is: {gameResult.statusResult.ToString()}");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

    }
}
