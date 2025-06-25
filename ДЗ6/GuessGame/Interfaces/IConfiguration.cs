namespace GuessGame.Interfaces
{
    public interface IConfiguration
    {
        int MinValue { get; }
        int MaxValue { get; }
        int MaxAttempts { get; }
    }
}