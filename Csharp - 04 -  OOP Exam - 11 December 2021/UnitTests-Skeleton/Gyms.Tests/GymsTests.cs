namespace Gyms.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        [TestCase("Tom")]
        [TestCase("Marko")]
        [TestCase("Vladislav")]
        public void CreateAthlete(string name)
        {
            var athlete = new Athlete(name);

            Assert.AreEqual(name, athlete.FullName);
        }

        [Test]
        [TestCase("Fitness", 8)]
        [TestCase("Mari", 14)]
        [TestCase("Trako", 2)]
        public void CreateGym(string name, int capacity)
        {
            var gym = new Gym(name, capacity);

            Assert.AreEqual(name, gym.Name);
            Assert.AreEqual(capacity, gym.Capacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NameUncorrect(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym g = new Gym(name, 7);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-7)]
        [TestCase(int.MinValue)]
        public void CapacityUncorrect(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym g = new Gym("Alofit", capacity);
            });
        }

        [Test]
        public void OverAddAthlete()
        {
            var gym = new Gym("Trako", 2);
            var a1 = new Athlete("Tom");
            var a2 = new Athlete("Tom1");

            gym.AddAthlete(a1);
            gym.AddAthlete(a2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(a2);
            });
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void AddAthlete(int cap)
        {
            var gym = new Gym("Fitness", cap);
            var athlete1 = new Athlete("Tom");

            gym.AddAthlete(athlete1);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void ErrorRemoveAthlete()
        {
            var remove = "Vanko";

            var gym = new Gym("Fitness", 4);
            var athlete = new Athlete("Tom");
            var athlete2 = new Athlete("Tom2");
            var athlete3 = new Athlete("Tom3");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(remove);
            });
        }

        [Test]
        public void RemoveAthlete()
        {
            var gym = new Gym("Fitness", 3);
            var athlete1 = new Athlete("Tom");
            var athlete2 = new Athlete("Bambi");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.RemoveAthlete("Bambi");

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void ErrorInjureAthlete()
        {
            var gym = new Gym("Fitness", 4);
            var athlete1 = new Athlete("Tom");
            var athlete2 = new Athlete("Bambi");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            gym.InjureAthlete("Vanko"));
        }

        [Test]
        public void InjureAthlete()
        {
            var gym = new Gym("Fitness", 3);
            var athlete1 = new Athlete("Tom");
            var athlete2 = new Athlete("Bambi");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            Athlete ath = gym.InjureAthlete("Tom");

            Assert.IsTrue(ath.IsInjured);
        }

        [Test]
        public void ReportWithoutAthlete()
        {
            var gym = new Gym("Fitness", 0);

            string report = "Active athletes at Fitness: ";

            Assert.AreEqual(report, gym.Report());
        }

        [Test]
        public void ReportWithOneAthlete()
        {
            var gym = new Gym("Fitness", 3);

            var tom = new Athlete("Tom");

            gym.AddAthlete(tom);
            string report = "Active athletes at Fitness: Tom";

            Assert.AreEqual(report, gym.Report());
        }

        [Test]
        public void ReportWithManyAthletes()
        {
            var gym = new Gym("Fitness", 4);
            var athlete1 = new Athlete("Tom");
            var athlete2 = new Athlete("Bambi");
            var athlete3 = new Athlete("Toby");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            string report = "Active athletes at Fitness: Tom, Bambi, Toby";

            Assert.AreEqual(report, gym.Report());
        }
    }
}
