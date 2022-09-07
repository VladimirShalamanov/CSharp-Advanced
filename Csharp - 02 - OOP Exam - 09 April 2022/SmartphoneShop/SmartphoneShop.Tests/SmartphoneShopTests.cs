namespace SmartphoneShop.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void StartUp()
        {
            this.smartphone = new Smartphone("Huawei", 100);
            this.shop = new Shop(3);
        }

        [Test]
        public void CtorShop()
        {
            Assert.AreEqual(3, this.shop.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(-8)]
        public void CorrectCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Shop(capacity));
        }

        //----------------------------------------------

        [Test]
        public void AddExsistingPhone()
        {
            this.shop.Add(this.smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            this.shop.Add(this.smartphone));
        }

        [Test]
        public void AddOverCount()
        {
            Shop sh = new Shop(5);
            for (int i = 1; i <= 5; i++)
            {
                sh.Add(new Smartphone($"S{i}", i));
            }
            Assert.Throws<InvalidOperationException>(() =>
            sh.Add(new Smartphone("Nokia", 50)));
        }

        [Test]
        public void AddSuccessful()
        {
            this.shop.Add(this.smartphone);
            Assert.AreEqual(1, this.shop.Count);
        }

        [Test]
        public void RemoveNotExisting()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            this.shop.Remove("Iphone"));
        }

        [Test]
        public void RemoveSuccessful()
        {
            this.shop.Add(this.smartphone);

            this.shop.Remove("Huawei");

            Assert.AreEqual(0, this.shop.Count);
        }

        [Test]
        public void TestPhoneNotExisting()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            this.shop.TestPhone("Iphone", 30));
        }

        [Test]
        public void TestPhoneWithLowBattery()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            this.shop.TestPhone("Huawei", 101));
        }

        [Test]
        public void TestPhoneSuccessful()
        {
            this.shop.Add(this.smartphone);

            this.shop.TestPhone("Huawei", 40);

            Assert.AreEqual(60, this.smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargeNotExistingPhone()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            this.shop.ChargePhone("Iphone"));
        }

        [Test]
        public void ChargeSuccessful()
        {
            this.shop.Add(this.smartphone);

            this.shop.TestPhone("Huawei", 30);

            this.shop.ChargePhone("Huawei");

            Assert.AreEqual(this.smartphone.CurrentBateryCharge, this.smartphone.MaximumBatteryCharge);
        }
    }
}