using Prototype.Abstractions;

namespace Prototype.Implementations
{
    // Класс, наследующийся от GasolineCar, представляет грузовик.
    // Включает свойство грузоподъёмности (LoadCapacity).
    // Реализует клонирование и переопределяет метод ToString для вывода всех характеристик.
    public class Truck : GasolineCar
    {
        public int LoadCapacity { get; set; }

        public Truck(string brand, int year, int numberOfDoors, int tankCapacity, int loadCapacity) : base(brand, year, numberOfDoors, tankCapacity)
        {
            LoadCapacity = loadCapacity;
        }

        protected Truck(Truck truck) : base(truck)
        {
            LoadCapacity = truck.LoadCapacity;
        }

        public override Vehicle MyClone()
        {
            return new Truck(this);
        }

        public override string ToString()
        {
            return $"Truck: {Brand}, Year: {Year}, Doors: {NumberOfDoors}, " +
               $"tankCapacity: {TankCapacity}, LoadCapacity: {LoadCapacity}";
        }
    }
}
