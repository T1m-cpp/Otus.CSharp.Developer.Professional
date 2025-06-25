using GuessGame.Interfaces;
using System.Text.Json;

namespace GuessGame.Implementations
{
    public class JsonConfiguration : IConfiguration
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int MaxAttempts { get; set; }

        public JsonConfiguration(string configPath)
        {
            try
            {
                var json = File.ReadAllText(configPath);
                using var document = JsonDocument.Parse(json);

                var root = document.RootElement;
                MinValue = root.GetProperty("MinValue").GetInt32();
                MaxValue = root.GetProperty("MaxValue").GetInt32();
                MaxAttempts = root.GetProperty("MaxAttempts").GetInt32();

                if (MinValue >= MaxValue || MaxAttempts <= 0)
                {
                    throw new ArgumentException("Некорректные параметры конфигурации.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки конфигурации: {ex.Message}. Используются значения по умолчанию.");
                MinValue = 1;
                MaxValue = 100;
                MaxAttempts = 10;
            }
        }
    }
}