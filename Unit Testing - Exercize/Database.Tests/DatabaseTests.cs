namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddLess16Elements(int[] addElements)
        {
            Database testDb = new Database(addElements);

            int[] actualData = testDb.Fetch();
            int[] expectedData = addElements;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "You should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount,
                "You should set initial value for count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void MaximumCountMustNotAllowExceed(int[] addElements)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(addElements);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void MustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Should return the count of the added elements!");
        }

        [Test]
        public void WhenNotElementsToAddShouldReturnZero()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "When not elements to add should return zero!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Less16ElementsAddShouldAdd(int[] addElements)
        {
            foreach (int e in addElements)
            {
                this.db.Add(e);
            }

            int[] actualData = this.db.Fetch();
            int[] expextedData = addElements;

            int actualCount = this.db.Count;
            int expectedCount = expextedData.Length;

            CollectionAssert.AreEqual(expextedData, actualData,
                "Should add elements to the field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Should change the count when adding!");
        }

        [Test]
        public void WhenAddingMoreThan16ElemntsShouldThrowException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void RemoveTheLastElementsOnce(int[] startElements)
        {
            foreach (int e in startElements)
            {
                this.db.Add(e);
            }

            this.db.Remove();
            List<int> list = new List<int>(startElements);
            list.RemoveAt(list.Count - 1);

            int[] actualData = this.db.Fetch();
            int[] expectedData = list.ToArray();

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Should remove element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Should decrement the count of the Database!");
        }

        [Test]
        public void ShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };
            foreach (int e in initData)
            {
                this.db.Add(e);
            }

            for (int i = 0; i < initData.Count; i++)
            {
                this.db.Remove();
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = this.db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Should remove element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Should decrement the count of the Database!");
        }

        [Test]
        public void WhenThereAreNoElementRemoveThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchReturnCopyArray(int[] initData)
        {
            foreach (int e in initData)
            {
                this.db.Add(e);
            }

            int[] actualResult = this.db.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult,
                "Should return copy array of the existing data!");
        }
    }
}
