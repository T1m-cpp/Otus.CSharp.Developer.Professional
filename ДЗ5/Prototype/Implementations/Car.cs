using Prototype.Abstractions;

namespace Prototype.Implementations
{
    //Класс, наследующийся от Vehicle, представляет общий тип легкового автомобиля.
    //Добавляет свойство количества дверей (NumberOfDoors).
    //Поддерживает клонирование через конструктор копирования и методы MyClone и Clone.
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string brand, int year, int numberOfDoors)
            : base(brand, year)
        {
            NumberOfDoors = numberOfDoors;
        }

        protected Car(Car other) : base(other)
        {
            NumberOfDoors = other.NumberOfDoors;
        }

        public override Vehicle MyClone()
        {
            return new Car(this);
        }
    }
}
