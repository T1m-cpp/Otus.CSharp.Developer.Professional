using Reflection.Implementations;
using Reflection.Interfaces;
using Reflection.TestClasses;
using System.Diagnostics;
using System.Text.Json;

namespace Reflection
{
    public class PerformanceTester<T> where T : class, new()
    {
        private readonly T testObj_;
        private readonly ISerialize<T> serializer_;
        private readonly IDeserialize<T> deserializer_;

        public PerformanceTester(T testObj)
        {
            testObj_ = testObj ?? throw new ArgumentNullException(nameof(testObj));
            serializer_ = new Serializer<T>();
            deserializer_ = new Deserializer<T>();
        }

        public void RunTest(int iterationsCount)
        {
            var stopwatch = new Stopwatch();

            // Рефлексия - Сериализация
            stopwatch.Restart();
            string csvResult = string.Empty;
            for (int i = 0; i < iterationsCount; i++)
            {
                csvResult = serializer_.Serialize(testObj_);
            }
            var reflectionSerializeTime = stopwatch.ElapsedMilliseconds;

            // Вывод в консоль и замер времени
            stopwatch.Restart();
            Console.WriteLine($"CSV: {csvResult}");
            var consoleOutputTime = stopwatch.ElapsedMilliseconds;

            // Рефлексия - Десериализация
            T deserializedObj = null;
            stopwatch.Restart();
            for (int i = 0; i < iterationsCount; i++)
            {
                deserializedObj = deserializer_.Deserialize(csvResult);
            }
            var reflectionDeserializeTime = stopwatch.ElapsedMilliseconds;

            // System.Text.Json - Сериализация
            stopwatch.Restart();
            string jsonResult = string.Empty;
            for (int i = 0; i < iterationsCount; i++)
            {
                jsonResult = JsonSerializer.Serialize(testObj_);
            }
            var jsonSerializeTime = stopwatch.ElapsedMilliseconds;

            // System.Text.Json - Десериализация
            stopwatch.Restart();
            F jsonDeserializedObj = null;
            for (int i = 0; i < iterationsCount; i++)
            {
                jsonDeserializedObj = JsonSerializer.Deserialize<F>(jsonResult);
            }
            var jsonDeserializeTime = stopwatch.ElapsedMilliseconds;

            // Вывод результатов
            Console.WriteLine($"\nРезультаты ({iterationsCount} итераций):");
            Console.WriteLine($"Моя рефлексия:");
            Console.WriteLine($"Время на сериализацию = {reflectionSerializeTime} мс");
            Console.WriteLine($"Время на десериализацию = {reflectionDeserializeTime} мс");
            Console.WriteLine($"Время на вывод в консоль = {consoleOutputTime} мс");
            Console.WriteLine($"System.Text.Json:");
            Console.WriteLine($"Время на сериализацию = {jsonSerializeTime} мс");
            Console.WriteLine($"Время на десериализацию = {jsonDeserializeTime} мс");
        }
    }

}
