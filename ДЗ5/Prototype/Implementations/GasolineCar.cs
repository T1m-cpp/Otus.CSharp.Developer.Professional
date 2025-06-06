using Prototype.Abstractions;

namespace Prototype.Implementations
{
    //Класс, наследующийся от Car, представляет автомобиль с бензиновым двигателем.
    //Включает свойство объёма топливного бака (TankCapacity).
    //Реализует клонирование, копируя все свойства, включая унаследованные.
    public class GasolineCar : Car
    {
        public int TankCapacity { get; set; }

        public GasolineCar(string brand, int year, int numberOfDoors, int tankCapacity) : base(brand, year, numberOfDoors)
        {
            TankCapacity = tankCapacity;
        }

        protected GasolineCar(GasolineCar car) : base(car)
        {
            TankCapacity = car.TankCapacity;
        }

        public override Vehicle MyClone()
        {
            return new GasolineCar(this);
        }
    }
}
