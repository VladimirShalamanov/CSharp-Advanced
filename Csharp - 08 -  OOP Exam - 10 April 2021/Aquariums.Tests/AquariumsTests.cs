namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void CreateFish()
        {
            var f = new Fish("Nemo");

            Assert.AreEqual("Nemo", f.Name);
            Assert.IsTrue(f.Available);
        }

        [Test]
        public void CreateAquarium()
        {
            var a = new Aquarium("More", 5);

            Assert.AreEqual("More", a.Name);
            Assert.AreEqual(5, a.Capacity);
            Assert.AreEqual(0, a.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateNullOrEmptyAquarium(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 5));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-8)]
        [TestCase(-47)]
        public void CreateNegativeNumberAquarium(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("More", capacity));
        }

        [Test]
        public void AddFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");
            a.Add(f);

            Assert.AreEqual(1, a.Count);
        }

        [Test]
        public void AddFishOverCapacity()
        {
            var a = new Aquarium("More", 2);
            var f = new Fish("Nemo");
            var f2 = new Fish("Petar");
            var f3 = new Fish("Ivo");
            a.Add(f);
            a.Add(f2);

            Assert.Throws<InvalidOperationException>(() => a.Add(f3));
        }

        [Test]
        public void RemoveFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");
            var f2 = new Fish("Petar");
            var f3 = new Fish("Ivo");

            a.Add(f);
            a.Add(f2);
            a.Add(f3);
            a.RemoveFish("Petar");

            Assert.AreEqual(2, a.Count);
        }

        [Test]
        public void RemoveNonexistFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");
            
            a.Add(f);

            Assert.Throws<InvalidOperationException>(() => a.RemoveFish("Petar"));
        }

        [Test]
        public void SellFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");
            var f2 = new Fish("Petar");

            a.Add(f);
            a.Add(f2);

            Fish fishSell = a.SellFish("Petar");

            Assert.IsFalse(fishSell.Available);
            Assert.AreEqual(f2, fishSell);
        }

        [Test]
        public void SellNonExistFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");
            var f2 = new Fish("Petar");

            a.Add(f);
            a.Add(f2);

            Assert.Throws<InvalidOperationException>(() => a.SellFish("Ivo"));
        }

        [Test]
        public void ReportWithManyFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");
            var f2 = new Fish("Petar");
            var f3 = new Fish("Ivo");

            a.Add(f);
            a.Add(f2);
            a.Add(f3);

            string actulalReport = a.Report();

            string expectedReport = "Fish available at More: Nemo, Petar, Ivo";

            Assert.AreEqual(expectedReport, actulalReport);
        }

        [Test]
        public void ReportWithOneFish()
        {
            var a = new Aquarium("More", 5);
            var f = new Fish("Nemo");

            a.Add(f);

            string actulalReport = a.Report();

            string expectedReport = "Fish available at More: Nemo";

            Assert.AreEqual(expectedReport, actulalReport);
        }

        [Test]
        public void ReportWithoutFish()
        {
            var a = new Aquarium("More", 5);

            string actulalReport = a.Report();

            string expectedReport = "Fish available at More: ";

            Assert.AreEqual(expectedReport, actulalReport);
        }
    }
}
