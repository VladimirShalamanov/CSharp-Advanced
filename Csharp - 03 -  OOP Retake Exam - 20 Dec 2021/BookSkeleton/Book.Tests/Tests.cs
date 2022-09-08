namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void CountSuccesses()
        {
            var b = new Book("Kniga", "Pesho");
            Assert.IsNotNull(b);
            Assert.AreEqual(0, b.FootnoteCount);
        }

        [TestCase(null, "Ivan")]
        [TestCase("", "Ivan")]
        public void BookError(string name, string author)
        {
            Assert.Throws<ArgumentException>(() =>
            new Book(name, author));
        }

        [TestCase("Knijka", null)]
        [TestCase("Knijka", "")]
        public void AuthorError(string name, string author)
        {
            Assert.Throws<ArgumentException>(() =>
            new Book(name, author));
        }

        [Test]
        public void AddSuccessesFootnote()
        {
            var b = new Book("Kniga", "Pesho");
            b.AddFootnote(1, "FirstFoot");

            Assert.AreEqual(1, b.FootnoteCount);
        }

        [Test]
        public void AddErrorFootnote()
        {
            var b = new Book("Kniga", "Pesho");
            b.AddFootnote(1, "Ivan");

            Assert.Throws<InvalidOperationException>(() =>
                b.AddFootnote(1, "Ivan"));
        }

        [Test]
        public void FindSuccessesFootnote()
        {
            var b = new Book("Kniga", "Pesho");
            b.AddFootnote(1, "Ivan");

            string expected = "Footnote #1: Ivan";

            Assert.AreEqual(expected, b.FindFootnote(1));
        }

        [Test]
        public void FindErrorFootnote()
        {
            var b = new Book("Kniga", "Pesho");
            b.AddFootnote(1, "Ivan");

            Assert.Throws<InvalidOperationException>(() =>
                b.FindFootnote(2));
        }

        [Test]
        public void AlterSuccessesFootnote()
        {
            var b = new Book("Kniga", "Pesho");
            b.AddFootnote(1, "Ivan");
            b.AlterFootnote(1, "New");

            string expected = "Footnote #1: New";

            Assert.AreEqual(expected, b.FindFootnote(1));
        }

        [Test]
        public void AlterErrorFootnote()
        {
            var b = new Book("Kniga", "Pesho");
            b.AddFootnote(1, "Ivan");

            Assert.Throws<InvalidOperationException>(() =>
                b.AlterFootnote(2, "Ivcho"));
        }
    }
}