using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MultithreadedProject.Executors;
using MultithreadedProject;

[MemoryDiagnoser]
[RankColumn]
[SimpleJob(RuntimeMoniker.Net80)]
public class SumBenchmark
{
    private int[] _data;
    private IExecutor _sequentialExecutor;
    private IExecutor _threadExecutor;
    private IExecutor _plinqExecutor;

    [Params(100_000, 1_000_000, 10_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _data = ArrayGenerator.GenerateRandomArray(Size);
        _sequentialExecutor = new SequentialExecutor();
        _threadExecutor = new ThreadExecutor();
        _plinqExecutor = new PlinqExecutor();

        // Проверка корректности
        var sum1 = _sequentialExecutor.CalculateSum(_data);
        var sum2 = _threadExecutor.CalculateSum(_data);
        var sum3 = _plinqExecutor.CalculateSum(_data);

        if (sum1 != sum2 && sum2 != sum3)
            throw new Exception("Different sums calculated!");
    }

    [Benchmark(Baseline = true)]
    public long Sequential()
    {
        long sum = _sequentialExecutor.CalculateSum(_data);
        return sum;
    }

    [Benchmark]
    public long ThreadBased()
    {
        long sum = _threadExecutor.CalculateSum(_data);
        return sum;
    }

    [Benchmark]
    public long Plinq()
    {
        long sum = _plinqExecutor.CalculateSum(_data);
        return sum;
    }
}