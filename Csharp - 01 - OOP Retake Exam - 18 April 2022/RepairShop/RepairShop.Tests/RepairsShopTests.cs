using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;

            [SetUp]
            public void StartUp()
            {
                this.car = new Car("Bmw", 4);
                this.garage = new Garage("Monkey", 5);
            }

            [Test]
            public void GarageCtor()
            {
                Assert.AreEqual("Monkey", this.garage.Name);
                Assert.AreEqual(5, this.garage.MechanicsAvailable);
            }

            [TestCase("", 5)]
            [TestCase(null, 5)]
            public void NameCorrect(string name, int mehanics)
            {
                Assert.Throws<ArgumentNullException>(() =>
                new Garage(name, mehanics));
            }

            [TestCase("Bmw", -3)]
            [TestCase("Bmw", 0)]
            public void NameMechanics(string name, int mehanics)
            {
                Assert.Throws<ArgumentException>(() =>
                new Garage(name, mehanics));
            }

            [Test]
            public void AddCar()
            {
                this.garage.AddCar(this.car);
                Assert.AreEqual(1, this.garage.CarsInGarage);

                for (int i = 2; i <= 5; i++)
                {
                    this.garage.AddCar(new Car($"Car{i}", i));
                }

                Assert.Throws<InvalidOperationException>(() =>
                this.garage.AddCar(new Car("Opel", 7)));
            }
        }
    }
}