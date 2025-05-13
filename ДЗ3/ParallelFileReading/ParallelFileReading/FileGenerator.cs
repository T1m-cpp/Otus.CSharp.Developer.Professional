using System.Text;

//Метод генерации файла со случайным набором символов
public class RandomFileGenerator
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789                 ";
    public static void GenerateRandomFiles(string directoryPath, int filesCount = 3, int minLength = 10, int maxLength = 100)
    {
        // Создаем папку, если ее нет
        Directory.CreateDirectory(directoryPath);

        Random random = new Random();

        for (int i = 1; i <= filesCount; i++)
        {
            string fileName = $"file_{i}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath))
            {
                Console.WriteLine($"Файл {fileName} уже существует, пропускаем");
                continue;
            }

            int contentLength = random.Next(minLength, maxLength + 1);

            StringBuilder content = new StringBuilder();
            for (int j = 0; j < contentLength; j++)
            {
                int index = random.Next(chars.Length);
                content.Append(chars[index]);
            }

            File.WriteAllText(filePath, content.ToString());

            int spaceCount = content.ToString().Count(c => c == ' ');

            Console.WriteLine($"Создан файл {fileName} (длина: {contentLength}, пробелов: {spaceCount})");
        }
    }

    //Метод очистки папки с файлами
    public static void ClearFilesFolder(string directoryPath)
    {
        try
        {
            // Удаляем папку со всем содержимым (если существует)
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, recursive: true);
            }

            // Создаём пустую папку заново
            Directory.CreateDirectory(directoryPath);

            Console.WriteLine($"Папка files очищена: {directoryPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка очистки папки: {ex.Message}");
        }
    }
}
