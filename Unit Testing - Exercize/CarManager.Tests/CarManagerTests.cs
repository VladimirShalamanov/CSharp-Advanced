namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car("Lambo", "Urus", 10, 100);
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void AddUncorrectlyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(null, "Urus", 10, 100);
            });
        }

        [Test]
        public void AddUncorrectlyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Lambo", null, 10, 100);
            });
        }

        [Test]
        public void AddUncorrectlyFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Lambo", "Urus", -1, 100);
            });
        }

        [Test]
        public void AddCorrectlyFuelAmount()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void AddUncorrectlyFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Lambo", "Urus", 10, 0);
            });
        }

        [Test]
        public void RefuelingCar()
        {
            this.car.Refuel(20);

            int expectedFuel = 20;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void RefuelingCarWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }

        [Test]
        public void RefuelingCarWithOverCapacityFuel()
        {
            this.car.Refuel(200);

            int expectedFuel = 100;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void DrivingCarSuccessful()
        {
            this.car.Refuel(20);
            this.car.Drive(50);

            double expectedFuel = 15;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void DrivingCarWithOverDistance()
        {
            this.car.Refuel(1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(50);
            });
        }
    }
}