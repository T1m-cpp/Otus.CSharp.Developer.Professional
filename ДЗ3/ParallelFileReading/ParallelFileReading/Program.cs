using System.Diagnostics;

string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "files");

RandomFileGenerator.ClearFilesFolder(directoryPath);
//Генерируем 3 файла со случайными символами длиной от 10000 до 100000 символов
RandomFileGenerator.GenerateRandomFiles("files", 3, 10000, 100000);

int workersCount = 3;

var timer = new Stopwatch();
timer.Start();
//Считаем количество пробелов в 3-х файлах 3-мя тасками 
int count = ParallelFileReader.ReadFiles("files", workersCount);
timer.Stop();
Console.WriteLine($"Время обработки 3-х файлов: {timer.Elapsed}");
Console.WriteLine($"Прочитанные файлы содержат {count} пробелов.");

timer.Reset();

//Очищаем папку с файлами
RandomFileGenerator.ClearFilesFolder(directoryPath);
//Генерируем тестовые файлы
RandomFileGenerator.GenerateRandomFiles("files", 20, 1000, 100000);

workersCount = Environment.ProcessorCount; //Получаем кол-во потоков нашего процессора

timer.Start();
//Считаем количество пробелов во всех файлах числом тасок, равным колечесту потоков нашего процессора
count = ParallelFileReader.ReadFiles("files", workersCount);
timer.Stop();
Console.WriteLine($"Время обработки всех файлов в папке: {timer.Elapsed}");
Console.WriteLine($"Прочитанные файлы содержат {count} пробелов.");
RandomFileGenerator.ClearFilesFolder(directoryPath);