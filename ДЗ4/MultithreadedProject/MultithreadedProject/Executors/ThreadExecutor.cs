namespace MultithreadedProject.Executors
{
    internal class ThreadExecutor : IExecutor
    {
        public long CalculateSum(int[] array)
        {
            int threadsCount = Environment.ProcessorCount;
            int arrayLength = array.Length;
            Object lockObj = new();

            var threads = new List<Thread>(threadsCount);

            int elementsPerThread = arrayLength / threadsCount;
            int extra = arrayLength % threadsCount; // остаток

            int arrayIndex = 0;
            long sum = 0;

            for (int i = 0; i < threadsCount; i++)
            {
                int count = elementsPerThread + (i < extra ? 1 : 0); // первые extra воркеров получат по 1 доп. элементу
                int start = arrayIndex;
                int end = start + count;

                Thread t = new(() =>
                {
                    long localSum = 0;
                    for (int num = start; num < end; num++)
                    {
                        localSum += array[num];
                    }

                    lock (lockObj) { sum += localSum; }
                });

                arrayIndex = end;

                threads.Add(t);
                t.Start();
            }

            foreach (Thread t in threads) { t.Join(); }
            return sum;

        }
    }
}
