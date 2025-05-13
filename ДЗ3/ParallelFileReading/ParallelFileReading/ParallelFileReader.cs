public class ParallelFileReader
{
    //Метод параллельного считывания файлов с заданным количеством тасок
    public static int ReadFiles(string directoryPath, int workersCount = 3)
    {
        var tasks = new Task<int>[workersCount];

        var files = Directory.GetFiles(directoryPath);
        int totalFiles = files.Length;
        int filesPerWorker = totalFiles / workersCount;
        int extra = totalFiles % workersCount; // остаток

        int fileIndex = 0;
        for (int i = 0; i < workersCount; i++)
        {
            int count = filesPerWorker + (i < extra ? 1 : 0); // первые extra воркеров получат по 1 доп. файлу
            int start = fileIndex;
            int end = start + count;

            tasks[i] = Task.Run(() =>
            {
                int spaces = 0;
                for (int j = start; j < end; j++)
                {
                    spaces += CountSpacesInFile(files[j]);
                }
                return spaces;
            });

            fileIndex = end;
        }

        Task.WaitAll(tasks);

        return tasks.Sum(t => t.Result);

    }

    //Метод подсчета пробелов в файле
    public static int CountSpacesInFile(string filePath)
    {
        string content = File.ReadAllText(filePath);
        return content.Count(c => c == ' ');
    }
}