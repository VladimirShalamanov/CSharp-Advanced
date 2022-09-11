namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void CreateRobot()
        {
            var robot = new Robot("Pesho", 100);

            Assert.AreEqual("Pesho", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void RobotManagerCreate()
        {
            var manager = new RobotManager(5);

            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(5, manager.Capacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(9)]
        public void Capacity(int capacity)
        {
            var manager = new RobotManager(capacity);

            Assert.AreEqual(capacity, manager.Capacity);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-9)]
        [TestCase(-15)]
        public void CapacityError(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void AddRobot()
        {
            var manager = new RobotManager(4);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Sharo", 90);

            manager.Add(r1);
            manager.Add(r2);
            manager.Add(r3);

            Assert.AreEqual(3, manager.Count);
        }

        [Test]
        public void AddSameNameRobot()
        {
            var manager = new RobotManager(4);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Bamby", 90);

            manager.Add(r1);
            manager.Add(r2);

            Assert.Throws<InvalidOperationException>(() => manager.Add(r3));
        }

        [Test]
        public void AddOverCapacityManager()
        {
            var manager = new RobotManager(2);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Sharo", 90);

            manager.Add(r1);
            manager.Add(r2);

            Assert.Throws<InvalidOperationException>(() => manager.Add(r3));
        }

        [Test]
        public void RemoveRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Sharo", 90);

            manager.Add(r1);
            manager.Add(r2);
            manager.Add(r3);
            manager.Remove("Bamby");

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void RemoveNotExistRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Sharo", 90);

            manager.Add(r1);
            manager.Add(r2);
            manager.Add(r3);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("Penka"));
        }

        [Test]
        public void WorkRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Sharo", 90);

            manager.Add(r1);
            manager.Add(r2);
            manager.Add(r3);

            manager.Work("Sharo", "Dev", 40);

            Assert.AreEqual(50, r3.Battery);
        }

        [Test]
        public void WorkNotExistRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);

            manager.Add(r1);
            manager.Add(r2);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Penka", "Dev", 30));
        }

        [Test]
        public void WorkWithOverBatteryRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);

            manager.Add(r1);
            manager.Add(r2);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Bamby", "Dev", 90));
        }

        [Test]
        public void ChargeRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);
            var r3 = new Robot("Sharo", 90);

            manager.Add(r1);
            manager.Add(r2);
            manager.Add(r3);

            manager.Work("Sharo", "Dev", 40);
            manager.Charge("Sharo");

            Assert.AreEqual(90, r3.Battery);
        }

        [Test]
        public void ChargeNotExistRobot()
        {
            var manager = new RobotManager(3);
            var r1 = new Robot("Pesho", 100);
            var r2 = new Robot("Bamby", 80);

            manager.Add(r1);
            manager.Add(r2);
            manager.Work("Bamby", "Dev", 40);
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Penka"));
        }
    }
}
