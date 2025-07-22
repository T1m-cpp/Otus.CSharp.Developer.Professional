using DelegatesAndEvents.FileSearcher;

internal class FileSearcher
{
    public event EventHandler<FileArgs> FileFound;

    public void SearchDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException($"Directory {path} not found");
        }

        foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
        {
            var args = new FileArgs(file);
            OnFileFound(args);

            if (args.Cancel)
            {
                Console.WriteLine("Search was cancelled by event handler");
                break;
            }
        }
    }

    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }
}