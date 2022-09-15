using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bank;

        [SetUp]
        public void Setup()
        {
            this.bank = new BankVault();
        }

        [Test]
        public void CreateBank()
        {
            var dict = new Dictionary<string, Item>()
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            Assert.AreEqual(dict.ToImmutableDictionary(), this.bank.VaultCells);
            Assert.AreEqual(dict.Count, this.bank.VaultCells.Count);
        }

        [Test]
        public void AddItem()
        {
            string cell = "A1";
            var item = new Item("Pesho", "123");

            string actual = this.bank.AddItem(cell, item);
            string expectedMess = "Item:123 saved successfully!";

            Assert.AreEqual(expectedMess, actual);
        }

        [Test]
        public void AddNotExistItem()
        {
            string cell = "9a";
            var item = new Item("Pesho", "123");

            Assert.Throws<ArgumentException>(() => this.bank.AddItem(cell, item));  
        }

        [Test]
        public void AddNotNullItem()
        {
            string cell = "A1";
            var item = new Item("Pesho", "123");

            this.bank.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() => this.bank.AddItem(cell, item));
        }

        [Test]
        public void AddSameItemIdItem()
        {
            string cell = "A1";
            var item = new Item("Pesho", "123");

            this.bank.AddItem(cell, item);

            Assert.Throws<InvalidOperationException>(() => this.bank.AddItem("A4", new Item("Ivan", "123")));
        }

        [Test]
        public void RemoveItem()
        {
            string cell = "A2";
            var removeItem = new Item("Gosho", "456");

            this.bank.AddItem("A1", new Item("Pesho", "123"));
            this.bank.AddItem(cell, removeItem);
            this.bank.AddItem("A3", new Item("Petko", "987"));


            string actual = this.bank.RemoveItem(cell, removeItem);
            string expectedMess = "Remove item:456 successfully!";

            Assert.AreEqual(expectedMess, actual);
        }

        [Test]
        public void RemoveNotContainsCell()
        {
            this.bank.AddItem("A1", new Item("Pesho", "123"));
            this.bank.AddItem("A2", new Item("Gosho", "456"));
            this.bank.AddItem("A3", new Item("Petko", "987"));

            string cell = "b7";
            var item = new Item("Sasho", "057");

            Assert.Throws<ArgumentException>(() => this.bank.RemoveItem(cell, item));
        }

        [Test]
        public void RemoveNotContainsItem()
        {
            this.bank.AddItem("A1", new Item("Pesho", "123"));
            this.bank.AddItem("A2", new Item("Gosho", "456"));
            this.bank.AddItem("A3", new Item("Petko", "987"));

            string cell = "A3";
            var item = new Item("Sasho", "057");

            Assert.Throws<ArgumentException>(() => this.bank.RemoveItem(cell, item));
        }
    }
}