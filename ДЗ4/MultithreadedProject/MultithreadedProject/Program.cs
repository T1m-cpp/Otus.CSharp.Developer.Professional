using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        var config = DefaultConfig.Instance
            .WithSummaryStyle(SummaryStyle.Default.WithMaxParameterColumnWidth(100));

        var summary = BenchmarkRunner.Run<SumBenchmark>(config);

        Console.WriteLine(summary.Table);
    }
}

//using MultithreadedProject;
//using MultithreadedProject.Executors;
//using System.Diagnostics;
//using System.Runtime.InteropServices;

//int[] sizes = { 100_000, 1_000_000, 10_000_000 };

//IExecutor[] executors = { new SequentialExecutor(), new ThreadExecutor(), new PlinqExecutor()};

//var timer = new Stopwatch();

//PrintBasicSystemInfo();

//foreach (var size in sizes)
//{
//    Console.WriteLine($"{new string('_', 120)}");
//    var array = ArrayGenerator.GenerateRandomArray(size);
//    foreach (var executor in executors)
//    {
//        timer.Start();
//        long sum = executor.CalculateSum(array);
//        timer.Stop();
//        Console.WriteLine($"size: {size},\t executor: {executor} \t- time: {timer.ElapsedMilliseconds} \tsum: {sum}");
//        timer.Reset();
//    }
//}

//static void PrintBasicSystemInfo()
//{
//    Console.WriteLine("=== Базовые характеристики ===");
//    Console.WriteLine($"ОС: {RuntimeInformation.OSDescription}");
//    Console.WriteLine($"Архитектура: {RuntimeInformation.OSArchitecture}");
//    Console.WriteLine($"Процессоров: {Environment.ProcessorCount}");
//    Console.WriteLine($"Версия .NET: {Environment.Version}");
//}