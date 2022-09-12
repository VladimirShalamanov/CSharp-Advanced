namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CreatePresent()
        {
            string name = "Pesho";
            double magic = 2;
            var present = new Present(name, magic);

            Assert.AreEqual(name, present.Name);
            Assert.AreEqual(magic, present.Magic);
        }

        [Test]
        public void CreateBag()
        {
            var bag = new Bag();
            var list = new List<Present>();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void AddPresent()
        {
            var bag = new Bag();
            var present = new Present("Pesho", 2);

            string actualMessege = bag.Create(present);

            string expectedMessege = "Successfully added present Pesho.";

            Assert.AreEqual(expectedMessege, actualMessege);
        }

        [Test]
        public void AddNullPresent()
        {
            var bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void AddExistPresent()
        {
            var bag = new Bag();
            var p1 = new Present("Pesho", 2);
            bag.Create(p1);

            Assert.Throws<InvalidOperationException>(() => bag.Create(p1));
        }

        [Test]
        public void RemoveReurnTrue()
        {
            var bag = new Bag();
            var p1 = new Present("Pesho", 2);
            var p2 = new Present("Bamby", 3);

            bag.Create(p1);
            bag.Create(p2);

            bool truee = bag.Remove(p1);

            Assert.IsTrue(truee);
        }

        [Test]
        public void RemoveReurnFalse()
        {
            var bag = new Bag();
            var p1 = new Present("Pesho", 2);
            var p2 = new Present("Bamby", 3);
            var invalid = new Present("Stoicho", 7);

            bag.Create(p1);
            bag.Create(p2);

            bool falsee = bag.Remove(invalid);

            Assert.IsFalse(falsee);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            var bag = new Bag();
            var p1 = new Present("Pesho", 2);
            var p2 = new Present("Bamby", 3);
            var p3 = new Present("Kiro", 7);

            bag.Create(p1);
            bag.Create(p2);
            bag.Create(p3);

            Present actualPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(p1, actualPresent);
        }

        //[Test]
        //public void ReturnNullGetPresentWithLeastMagic()
        //{
        //    var bag = new Bag();

        //    Present actualPresent = bag.GetPresentWithLeastMagic();
        //    Present expectedPresent = null;

        //    Assert.AreEqual(expectedPresent, actualPresent);
        //}

        [Test]
        public void GetPresentByName()
        {
            var bag = new Bag();
            var p1 = new Present("Pesho", 2);
            var p2 = new Present("Bamby", 3);
            var p3 = new Present("Kiro", 7);

            bag.Create(p1);
            bag.Create(p2);
            bag.Create(p3);

            Present actualPresent = bag.GetPresent("Kiro");

            Assert.AreEqual(p3, actualPresent);
        }

        [Test]
        public void GetNullPresentByName()
        {
            var bag = new Bag();

            Present actualPresent = bag.GetPresent("Kiro");

            Assert.AreEqual(null, actualPresent);
        }

        [Test]
        public void GetPresent()
        {
            var bag = new Bag();
            var p1 = new Present("Pesho", 2);
            var p2 = new Present("Bamby", 3);
            var p3 = new Present("Kiro", 7);

            var list = new List<Present>();
            bag.Create(p1);
            bag.Create(p2);
            bag.Create(p3);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);

            IReadOnlyCollection<Present> actualPresents = bag.GetPresents();
            IReadOnlyCollection<Present> expectedPresents = list.AsReadOnly();

            Assert.AreEqual(expectedPresents, actualPresents);
        }

        [Test]
        public void GetNullPresent()
        {
            var bag = new Bag();

            var list = new List<Present>();

            IReadOnlyCollection<Present> actualPresents = bag.GetPresents();
            IReadOnlyCollection<Present> expectedPresents = list.AsReadOnly();

            Assert.AreEqual(expectedPresents, actualPresents);
        }
    }
}
