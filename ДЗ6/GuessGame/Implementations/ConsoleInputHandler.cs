using GuessGame.Interfaces;

namespace GuessGame.Implementations
{
    public class ConsoleInputHandler : IInputHandler
    {
        public int GetGuess(int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write($"Введите число от {minValue} до {maxValue} (или 'exit' для выхода): ");
                string input = Console.ReadLine() ?? String.Empty;

                if (input?.ToLower() == "exit")
                {
                    throw new OperationCanceledException("Игра прервана пользователем.");
                }

                if (int.TryParse(input, out int guess) && guess >= minValue && guess <= maxValue)
                {
                    return guess;
                }

                Console.WriteLine($"Ошибка: введите целое число в диапазоне от {minValue} до {maxValue}.");
            }
        }
    }
}