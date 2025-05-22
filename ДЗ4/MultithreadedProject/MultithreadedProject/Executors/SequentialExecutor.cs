using System.Diagnostics;

namespace MultithreadedProject.Executors
{
    internal class SequentialExecutor : IExecutor
    {
        public long CalculateSum(int[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;   
        }
    }
}
