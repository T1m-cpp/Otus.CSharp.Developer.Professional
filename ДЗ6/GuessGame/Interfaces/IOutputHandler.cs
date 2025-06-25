namespace GuessGame.Interfaces
{
    public interface IOutputHandler
    {
        void ShowMessage(string message);
        void ShowHint(int guess, int target);
    }
}