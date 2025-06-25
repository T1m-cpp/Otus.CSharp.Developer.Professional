using GuessGame.Interfaces;

namespace GuessGame.Implementations
{
    public class ConsoleOutputHandler : IOutputHandler
    {
        public void ShowMessage(string message) => Console.WriteLine(message);

        public void ShowHint(int guess, int target)
        {
            if (guess < target)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else if (guess > target)
            {
                Console.WriteLine("Загаданное число меньше.");
            }
            else
            {
                Console.WriteLine("Поздравляем! Вы угадали число!");
            }
        }
    }
}