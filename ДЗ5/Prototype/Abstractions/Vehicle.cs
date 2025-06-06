namespace Prototype.Abstractions
{
    //Базовый абстрактный класс, представляющий любое транспортное средство.
    //Содержит общие свойства, такие как марка (Brand) и год выпуска (Year).
    //Реализует интерфейсы IMyCloneable<Vehicle> и ICloneable для поддержки шаблона "Прототип",
    //обеспечивая возможность клонирования объектов.
    public abstract class Vehicle : IMyCloneable<Vehicle>, ICloneable
    {
        public string Brand { get; set; }
        public int Year { get; set; }

        protected Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        protected Vehicle(Vehicle other)
        {
            Brand = other.Brand;
            Year = other.Year;
        }

        public abstract Vehicle MyClone();
        public object Clone()
        {
            return MyClone();
        }
    }
}
