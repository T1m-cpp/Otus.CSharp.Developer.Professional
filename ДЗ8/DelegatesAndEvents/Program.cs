using DelegatesAndEvents.CollectionExtensions;
using DelegatesAndEvents.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        // Демонстрация функции поиска максимального элемента
        var carList = new List<Car>
        {
            new Car {Name = "Ford", MaxSpeed = "220 km/h", Price = 2_000_000},
            new Car {Name = "Lada", MaxSpeed = "160 km/h", Price = 1_000_000},
            new Car {Name = "Geely", MaxSpeed = "190 km/h", Price = 2_300_000}
        };

        var mostExpensiveCar = carList.GetMax(c => c.Price);
        Console.WriteLine($"Самый дорогой автомобиль: {mostExpensiveCar.Name} - {mostExpensiveCar.Price}");

        var fastestCar = carList.GetMax(c => float.Parse(c.MaxSpeed.Split(' ')[0]));
        Console.WriteLine($"Самый быстрый автомобиль: {fastestCar.Name} - {fastestCar.MaxSpeed}\n");

        // Демонстрация обхода каталога с событиями
        var fileSearcher = new FileSearcher();
        fileSearcher.FileFound += (s, e) => 
        {
            Console.WriteLine($"Найден файл {e.FileName}");
            if (e.FileName.Contains("abc"))
            {
                e.Cancel = true;
                Console.WriteLine("Поиск окончен");
            } 
        };

        try
        {
            fileSearcher.SearchDirectory("C:\\Users\\Tim\\Desktop\\Otus.CSharp.Developer.Professional\\ДЗ8\\DelegatesAndEvents\\TestFiles\\");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}