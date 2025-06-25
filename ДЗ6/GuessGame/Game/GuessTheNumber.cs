using GuessGame.Interfaces;

namespace GuessGame.Game
{
    public class GuessTheNumber : IGame
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;
        private readonly IConfiguration _configuration;

        public GuessTheNumber(
            INumberGenerator numberGenerator,
            IInputHandler inputHandler,
            IOutputHandler outputHandler,
            IConfiguration configuration)
        {
            _numberGenerator = numberGenerator;
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
            _configuration = configuration;
        }

        public void Run()
        {
            int targetNumber = _numberGenerator.GenerateNumber(_configuration.MinValue, _configuration.MaxValue);
            int attemptsLeft = _configuration.MaxAttempts;

            _outputHandler.ShowMessage($"Добро пожаловать в игру 'Угадай число'!");
            _outputHandler.ShowMessage($"Угадайте число от {_configuration.MinValue} до {_configuration.MaxValue}.");
            _outputHandler.ShowMessage($"У вас есть {_configuration.MaxAttempts} попыток.");

            try
            {
                while (attemptsLeft > 0)
                {
                    int guess = _inputHandler.GetGuess(_configuration.MinValue, _configuration.MaxValue);
                    attemptsLeft--;

                    _outputHandler.ShowHint(guess, targetNumber);

                    if (guess == targetNumber)
                    {
                        return;
                    }

                    if (attemptsLeft > 0)
                    {
                        _outputHandler.ShowMessage($"Осталось попыток: {attemptsLeft}");
                    }
                    else
                    {
                        _outputHandler.ShowMessage($"Игра окончена! Загаданное число было: {targetNumber}");
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                _outputHandler.ShowMessage(ex.Message);
            }
        }
    }
}