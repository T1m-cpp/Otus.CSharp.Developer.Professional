using Prototype.Abstractions;
using Prototype.Implementations;

public class Program
{
    public static void Main()
    {
        // Создание оригинального объекта
        Truck original = new Truck("Kamaz", 2023, 2, 100, 2000);
        Console.WriteLine("Original: " + original);

        // Клонирование через IMyCloneable
        Vehicle myClone = original.MyClone();
        Console.WriteLine("IMyCloneable clone: " + myClone);

        // Клонирование через ICloneable
        object standardClone = original.Clone();
        Console.WriteLine("ICloneable clone: " + standardClone);

        // Проверка глубокого копирования
        original.LoadCapacity = 3000;
        Console.WriteLine("\nAfter changing original load capacity:");
        Console.WriteLine("Original: " + original);
        Console.WriteLine("IMyCloneable clone: " + myClone);
        Console.WriteLine("ICloneable clone: " + standardClone);
    }
}