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