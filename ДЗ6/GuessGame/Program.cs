using GuessGame.Game;
using GuessGame.Implementations;
using GuessGame.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка DI-контейнера
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(new JsonConfiguration("config.json"))
                .AddSingleton<INumberGenerator, NumberGenerator>()
                .AddSingleton<IInputHandler, ConsoleInputHandler>()
                .AddSingleton<IOutputHandler, ConsoleOutputHandler>()
                .AddSingleton<IGame, GuessTheNumber>()
                .BuildServiceProvider();

            // Получение экземпляра игры через DI-контейнер
            var game = serviceProvider.GetService<GuessTheNumber>();
            if (game == null)
            {
                Console.WriteLine("Ошибка: не удалось получить экземпляр игры из DI-контейнера.");
                return;
            }
            game.Run();
        }
    }
}