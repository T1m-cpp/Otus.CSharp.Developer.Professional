public class ParallelFileReader
{
    public static int ReadThreeFiles()
    {
        RandomFileGenerator.ClearFilesFolder();
        RandomFileGenerator.GenerateRandomFiles(3, 100, 1000);

        var tasks = new List<Task<int>>();

        string directoryPath = Path.Combine(AppContext.BaseDirectory, "files");

        var files = Directory.GetFiles(directoryPath);

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
        //for (int i = 0; i < 3; i++) {
        //    tasks.Add(Task.Run(() => CountSpacesInFile(filePath));



        //}
        return 1;
    }
    public static int CountSpacesInFile(string filePath)
    {
        string content = File.ReadAllText(filePath);
        return content.Count(c => c == ' ');
    }
}