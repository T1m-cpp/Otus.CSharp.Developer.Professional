using Prototype.Abstractions;

namespace Prototype.Implementations
{
    //Класс, наследующийся от Car, представляет электромобиль.
    //Добавляет свойство ёмкости батареи (BatteryCapacity).
    //Поддерживает клонирование через конструктор копирования и методы интерфейсов.
    public class ElectricCar : Car
    {
        public int BatteryCapacity { get; set; }

        public ElectricCar(string brand, int year, int numberOfDoors, int batteryCapacity) : base(brand, year, numberOfDoors)
        {
            BatteryCapacity = batteryCapacity;
        }

        protected ElectricCar(ElectricCar car) : base(car)
        {
            BatteryCapacity = car.BatteryCapacity;
        }

        public override Vehicle MyClone()
        {
            return new ElectricCar(this);
        }
    }
}
