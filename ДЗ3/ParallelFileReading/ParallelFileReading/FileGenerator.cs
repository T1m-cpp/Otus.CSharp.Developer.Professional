using System.Text;

public class RandomFileGenerator
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789                 ";
    public static void GenerateRandomFiles(int filesCount, int minLength = 10, int maxLength = 100)
    {
        // Путь к папке files в папке проекта
        string directoryPath = Path.Combine(AppContext.BaseDirectory, "files");

        // Создаем папку, если ее нет
        Directory.CreateDirectory(directoryPath);

        // Генератор случайных чисел
        Random random = new Random();

        // Символы, которые будут использоваться для генерации

        for (int i = 1; i <= filesCount; i++)
        {
            // Формируем имя файла
            string fileName = $"file_{i}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // Проверяем существование файла
            if (File.Exists(filePath))
            {
                Console.WriteLine($"Файл {fileName} уже существует, пропускаем");
                continue;
            }

            // Генерируем случайную длину содержимого
            int contentLength = random.Next(minLength, maxLength + 1);

            // Генерируем случайное содержимое
            StringBuilder content = new StringBuilder();
            for (int j = 0; j < contentLength; j++)
            {
                int index = random.Next(chars.Length);
                content.Append(chars[index]);
            }

            // Записываем в файл
            File.WriteAllText(filePath, content.ToString());

            // Подсчет пробелов в сгенерированном файле
            int spaceCount = content.ToString().Count(c => c == ' ');

            Console.WriteLine($"Создан файл {fileName} (длина: {contentLength}, пробелов: {spaceCount})");
        }
    }

    public static void ClearFilesFolder()
    {
        // Путь к папке files рядом с Program.cs
        string folderPath = Path.Combine(AppContext.BaseDirectory, "files");

        try
        {
            // Удаляем папку со всем содержимым (если существует)
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, recursive: true);
            }

            // Создаём пустую папку заново
            Directory.CreateDirectory(folderPath);

            Console.WriteLine($"Папка files очищена: {folderPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка очистки папки: {ex.Message}");
        }
    }
}
