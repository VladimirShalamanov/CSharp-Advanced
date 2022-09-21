using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        [Test]
        public void CreteUnitCar()
        {
            UnitCar uniCar = new UnitCar("Lambo", 500, 5.5);

            Assert.AreEqual("Lambo", uniCar.Model);
            Assert.AreEqual(500, uniCar.HorsePower);
            Assert.AreEqual(5.5, uniCar.CubicCentimeters);
        }

        [Test]
        public void CreateUnitDriver()
        {
            var uniCar = new UnitCar("Lambo", 500, 5.5);
            var unitDriver = new UnitDriver("Pesho", uniCar);

            Assert.AreEqual("Pesho", unitDriver.Name);
            Assert.AreEqual(uniCar, unitDriver.Car);
        }

        [Test]
        public void CreateNullUnitDriver()
        {
            var uniCar = new UnitCar("Lambo", 500, 5.5);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, uniCar));
        }

        [Test]
        public void CreateRaceEntry()
        {
            var raceEntry = new RaceEntry();

            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddNullDriver()
        {
            var raceEntry = new RaceEntry();
            var uniCar = new UnitCar("Lambo", 500, 5.5);
            UnitDriver drivNull = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(drivNull));
        }

        [Test]
        public void AddExistingDriver()
        {
            var raceEntry = new RaceEntry();
            var uniCar = new UnitCar("Lambo", 500, 5.5);
            var unitDriver = new UnitDriver("Pesho", uniCar);
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver));
        }

        [Test]
        public void AddDriver()
        {
            var raceEntry = new RaceEntry();
            var uniCar = new UnitCar("Lambo", 500, 5.5);
            var unitDriver = new UnitDriver("Pesho", uniCar);
            
            string acualMess = raceEntry.AddDriver(unitDriver);
            string expectedMess = "Driver Pesho added in race.";

            Assert.AreEqual(expectedMess, acualMess);
        }

        [Test]
        public void CalculateAverageHorsePowerWithOnluOneDriver()
        {
            var raceEntry = new RaceEntry();
            var uniCar = new UnitCar("Lambo", 500, 5.5);
            var unitDriver = new UnitDriver("Pesho", uniCar);
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower()
        {
            var raceEntry = new RaceEntry();
            var uniCar1 = new UnitCar("Lambo", 500, 5.5);
            var uniCar2= new UnitCar("Opel", 120, 2.2);
            var uniCar3 = new UnitCar("Reno", 90, 1.5);

            var u1 = new UnitDriver("Pesho", uniCar1);
            var u2 = new UnitDriver("Ivan", uniCar2);
            var u3 = new UnitDriver("Dragan", uniCar3);
            raceEntry.AddDriver(u1);
            raceEntry.AddDriver(u2);
            raceEntry.AddDriver(u3);

            var driver = new Dictionary<string, UnitDriver>();
            driver.Add(u1.Name, u1);
            driver.Add(u2.Name, u2);
            driver.Add(u3.Name, u3);

            double averageHP = raceEntry.CalculateAverageHorsePower();

            double expectedHP = driver.Values.Select(x => x.Car.HorsePower).Average();

            Assert.AreEqual(expectedHP, averageHP);
        }
    }
}