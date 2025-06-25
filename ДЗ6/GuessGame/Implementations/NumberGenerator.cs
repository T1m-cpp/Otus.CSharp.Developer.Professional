using GuessGame.Interfaces;

namespace GuessGame.Implementations
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random _random;
        public NumberGenerator() => _random = new Random();
        public int GenerateNumber(int minValue, int maxValue) => _random.Next(minValue, maxValue + 1);
    }
}
