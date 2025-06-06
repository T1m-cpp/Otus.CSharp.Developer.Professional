using Prototype.Abstractions;
using Prototype.Implementations;

namespace CarPrototypeTests;
public class CarPrototypeTests
{
    [Fact]
    public void Car_MyClone_CreatesIdenticalCopy()
    {
        // Arrange
        Car original = new Car("Toyota", 2023, 4);

        // Act
        Vehicle clone = original.MyClone();

        // Assert
        Assert.NotSame(original, clone); // Проверяем, что это разные объекты
        Assert.IsType<Car>(clone);
        Assert.Equal(original.Brand, clone.Brand);
        Assert.Equal(original.Year, clone.Year);
        Assert.Equal(original.NumberOfDoors, ((Car)clone).NumberOfDoors);

        // Проверяем независимость копии
        original.NumberOfDoors = 2;
        Assert.Equal(4, ((Car)clone).NumberOfDoors);
    }

    [Fact]
    public void Car_Clone_CreatesIdenticalCopy()
    {
        // Arrange
        Car original = new Car("Toyota", 2023, 4);

        // Act
        object clone = original.Clone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<Car>(clone);
        Assert.Equal(original.Brand, ((Car)clone).Brand);
        Assert.Equal(original.Year, ((Car)clone).Year);
        Assert.Equal(original.NumberOfDoors, ((Car)clone).NumberOfDoors);

        // Проверяем независимость копии
        original.NumberOfDoors = 2;
        Assert.Equal(4, ((Car)clone).NumberOfDoors);
    }

    [Fact]
    public void GasolineCar_MyClone_CreatesIdenticalCopy()
    {
        // Arrange
        GasolineCar original = new GasolineCar("Honda", 2022, 4, 50);

        // Act
        Vehicle clone = original.MyClone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<GasolineCar>(clone);
        Assert.Equal(original.Brand, clone.Brand);
        Assert.Equal(original.Year, clone.Year);
        Assert.Equal(original.NumberOfDoors, ((GasolineCar)clone).NumberOfDoors);
        Assert.Equal(original.TankCapacity, ((GasolineCar)clone).TankCapacity);

        // Проверяем независимость копии
        original.TankCapacity = 60;
        Assert.Equal(50, ((GasolineCar)clone).TankCapacity);
    }

    [Fact]
    public void GasolineCar_Clone_CreatesIdenticalCopy()
    {
        // Arrange
        GasolineCar original = new GasolineCar("Honda", 2022, 4, 50);

        // Act
        object clone = original.Clone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<GasolineCar>(clone);
        Assert.Equal(original.Brand, ((GasolineCar)clone).Brand);
        Assert.Equal(original.Year, ((GasolineCar)clone).Year);
        Assert.Equal(original.NumberOfDoors, ((GasolineCar)clone).NumberOfDoors);
        Assert.Equal(original.TankCapacity, ((GasolineCar)clone).TankCapacity);

        // Проверяем независимость копии
        original.TankCapacity = 60;
        Assert.Equal(50, ((GasolineCar)clone).TankCapacity);
    }

    [Fact]
    public void ElectricCar_MyClone_CreatesIdenticalCopy()
    {
        // Arrange
        ElectricCar original = new ElectricCar("Tesla", 2023, 4, 100);

        // Act
        Vehicle clone = original.MyClone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<ElectricCar>(clone);
        Assert.Equal(original.Brand, clone.Brand);
        Assert.Equal(original.Year, clone.Year);
        Assert.Equal(original.NumberOfDoors, ((ElectricCar)clone).NumberOfDoors);
        Assert.Equal(original.BatteryCapacity, ((ElectricCar)clone).BatteryCapacity);

        // Проверяем независимость копии
        original.BatteryCapacity = 90;
        Assert.Equal(100, ((ElectricCar)clone).BatteryCapacity);
    }

    [Fact]
    public void ElectricCar_Clone_CreatesIdenticalCopy()
    {
        // Arrange
        ElectricCar original = new ElectricCar("Tesla", 2023, 4, 100);

        // Act
        object clone = original.Clone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<ElectricCar>(clone);
        Assert.Equal(original.Brand, ((ElectricCar)clone).Brand);
        Assert.Equal(original.Year, ((ElectricCar)clone).Year);
        Assert.Equal(original.NumberOfDoors, ((ElectricCar)clone).NumberOfDoors);
        Assert.Equal(original.BatteryCapacity, ((ElectricCar)clone).BatteryCapacity);

        // Проверяем независимость копии
        original.BatteryCapacity = 90;
        Assert.Equal(100, ((ElectricCar)clone).BatteryCapacity);
    }

    [Fact]
    public void Truck_MyClone_CreatesIdenticalCopy()
    {
        // Arrange
        Truck original = new Truck("Ford", 2021, 2, 70, 1000);

        // Act
        Vehicle clone = original.MyClone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<Truck>(clone);
        Assert.Equal(original.Brand, clone.Brand);
        Assert.Equal(original.Year, clone.Year);
        Assert.Equal(original.NumberOfDoors, ((Truck)clone).NumberOfDoors);
        Assert.Equal(original.TankCapacity, ((Truck)clone).TankCapacity);
        Assert.Equal(original.LoadCapacity, ((Truck)clone).LoadCapacity);

        // Проверяем независимость копии
        original.LoadCapacity = 1200;
        Assert.Equal(1000, ((Truck)clone).LoadCapacity);
    }

    [Fact]
    public void Truck_Clone_CreatesIdenticalCopy()
    {
        // Arrange
        Truck original = new Truck("Ford", 2021, 2, 70, 1000);

        // Act
        object clone = original.Clone();

        // Assert
        Assert.NotSame(original, clone);
        Assert.IsType<Truck>(clone);
        Assert.Equal(original.Brand, ((Truck)clone).Brand);
        Assert.Equal(original.Year, ((Truck)clone).Year);
        Assert.Equal(original.NumberOfDoors, ((Truck)clone).NumberOfDoors);
        Assert.Equal(original.TankCapacity, ((Truck)clone).TankCapacity);
        Assert.Equal(original.LoadCapacity, ((Truck)clone).LoadCapacity);

        // Проверяем независимость копии
        original.LoadCapacity = 1200;
        Assert.Equal(1000, ((Truck)clone).LoadCapacity);
    }
}