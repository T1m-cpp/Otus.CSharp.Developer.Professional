namespace MultithreadedProject
{
    internal class ArrayGenerator
    {
        public static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101);
            }
            return array;
        }
    }
}
