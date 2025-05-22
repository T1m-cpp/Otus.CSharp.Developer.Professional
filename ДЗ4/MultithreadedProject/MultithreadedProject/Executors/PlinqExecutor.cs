namespace MultithreadedProject.Executors
{
    internal class PlinqExecutor : IExecutor
    {
        public long CalculateSum(int[] array) 
        {
            long sum = array.AsParallel().Sum();
            return sum;
        }
    }
}
