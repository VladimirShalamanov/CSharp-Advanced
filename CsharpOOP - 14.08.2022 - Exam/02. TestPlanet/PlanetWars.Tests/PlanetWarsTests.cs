using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void AddWeapon()
            {
                string name = "emka";
                double price = 3.50;
                int des = 5;

                var w = new Weapon(name, price, des);

                Assert.AreEqual(name, w.Name);
                Assert.AreEqual(price, w.Price);
                Assert.AreEqual(des, w.DestructionLevel);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-5)]
            [TestCase(-17)]
            public void InvalidPrice(double price)
            {
                string name = "emka";
                int des = 5;

                Assert.Throws<ArgumentException>(() => new Weapon(name, price, des));
            }

            [Test]
            public void IncreaseDestructionLevel()
            {
                string name = "emka";
                double price = 3.50;
                int des = 5;

                var w = new Weapon(name, price, des);
                w.IncreaseDestructionLevel();

                Assert.AreEqual(6, w.DestructionLevel);
            }

            [Test]
            [TestCase(10)]
            [TestCase(11)]
            [TestCase(18)]
            [TestCase(25)]
            public void IsNuclearTrue(int des)
            {
                string name = "emka";
                double price = 3.50;

                var w = new Weapon(name, price, des);
                bool tr = w.IsNuclear;

                Assert.IsTrue(tr);
            }

            [Test]
            [TestCase(9)]
            [TestCase(7)]
            [TestCase(3)]
            public void IsNuclearFalse(int des)
            {
                string name = "emka";
                double price = 3.50;

                var w = new Weapon(name, price, des);
                bool fl = w.IsNuclear;

                Assert.IsFalse(fl);
            }

            [Test]
            public void AddPlanet()
            {
                string name = "zemq";
                double budget = 5.50;

                var p = new Planet(name, budget);

                Assert.AreEqual(name, p.Name);
                Assert.AreEqual(budget, p.Budget);
                Assert.AreEqual(0, p.Weapons.Count);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void InvalidName(string name)
            {
                double budget = 5;

                Assert.Throws<ArgumentException>(() => new Planet(name, budget));
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-4)]
            [TestCase(-9)]
            [TestCase(-16)]
            public void InvalidBudget(double budget)
            {
                string name = "zemq";

                Assert.Throws<ArgumentException>(() => new Planet(name, budget));
            }

            [Test]
            public void TestCollectionWithItems()
            {
                var p = new Planet("zemq", 6);

                p.AddWeapon(new Weapon("ala", 4.70, 3));
                p.AddWeapon(new Weapon("bali", 6.40, 5));
                p.AddWeapon(new Weapon("trapa", 3.20, 8));

                Assert.AreEqual(3, p.Weapons.Count);
            }

            [Test]
            public void TestCollectionNoItems()
            {
                var p = new Planet("zemq", 6);

                Assert.AreEqual(0, p.Weapons.Count);
            }

            [Test]
            public void MilitaryPowerRatio()
            {
                var p = new Planet("zemq", 6);

                p.AddWeapon(new Weapon("ala", 4.70, 3));
                p.AddWeapon(new Weapon("bali", 6.40, 5));
                p.AddWeapon(new Weapon("trapa", 3.20, 2));

                double sum = 10;
                Assert.AreEqual(sum, p.MilitaryPowerRatio);
            }

            [Test]
            public void Profit()
            {
                var p = new Planet("zemq", 4.60);

                p.Profit(2.20);

                Assert.AreEqual(6.80, p.Budget);
            }

            [Test]
            public void SpendFunds()
            {
                var p = new Planet("zemq", 5);

                p.SpendFunds(3);

                Assert.AreEqual(2, p.Budget);
            }

            [Test]
            public void SpendFundsInvalid()
            {
                var p = new Planet("zemq", 5);

                Assert.Throws<InvalidOperationException>(() => p.SpendFunds(6));
            }

            [Test]
            public void AddWeaponToPlanet()
            {
                var p = new Planet("zemq", 5);
                p.AddWeapon(new Weapon("ala", 4.70, 3));
                p.AddWeapon(new Weapon("bali", 6.40, 5));

                Assert.AreEqual(2, p.Weapons.Count);
            }

            [Test]
            public void AddInvalidWeaponToPlanet()
            {
                var p = new Planet("zemq", 5);
                p.AddWeapon(new Weapon("ala", 4.70, 3));

                Assert.Throws<InvalidOperationException>(() => p.AddWeapon(new Weapon("ala", 4.70, 3)));
            }

            [Test]
            public void RemoveWeapon()
            {
                var p = new Planet("zemq", 5);
                p.AddWeapon(new Weapon("ala", 4.70, 3));
                p.RemoveWeapon("ala");

                Assert.AreEqual(0, p.Weapons.Count);
            }

            [Test]
            public void UpgradeWeapon()
            {
                var p = new Planet("zemq", 5);
                p.AddWeapon(new Weapon("ala", 4.70, 3));
                p.UpgradeWeapon("ala");

                Weapon w = p.Weapons.FirstOrDefault(x => x.Name == "ala");

                Assert.AreEqual(4, w.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponInvalid()
            {
                var p = new Planet("zemq", 5);
                p.AddWeapon(new Weapon("ala", 4.70, 3));

                Assert.Throws<InvalidOperationException>(() => p.UpgradeWeapon("bali"));
            }

            [Test]
            public void DestructOpponent()
            {
                var z = new Planet("zemq", 5);
                z.AddWeapon(new Weapon("ala", 4.70, 3));
                z.AddWeapon(new Weapon("bali", 6.40, 5));

                var m = new Planet("mars", 8);
                m.AddWeapon(new Weapon("hana", 4.70, 2));
                m.AddWeapon(new Weapon("kala", 6.40, 3));

                string actualMess = z.DestructOpponent(m);
                string expectedMess = "mars is destructed!";

                Assert.AreEqual(expectedMess, actualMess);
            }

            [Test]
            public void DestructInvalidOpponent()
            {
                var z = new Planet("zemq", 5);
                z.AddWeapon(new Weapon("ala", 4.70, 3));
                z.AddWeapon(new Weapon("bali", 6.40, 5));

                var m = new Planet("mars", 8);
                m.AddWeapon(new Weapon("hana", 4.70, 5));
                m.AddWeapon(new Weapon("kala", 6.40, 6));

                Assert.Throws<InvalidOperationException>(() => z.DestructOpponent(m));
            }
        }
    }
}
