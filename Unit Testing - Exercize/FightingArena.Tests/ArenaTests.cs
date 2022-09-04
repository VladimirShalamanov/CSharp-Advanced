namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void EmptyCollectionWarrior()
        {
            var testA = new Arena();

            var actualArena = testA.Warriors.ToList();
            var expectedArena = new List<Warrior>();

            CollectionAssert.AreEqual(expectedArena, actualArena);
        }

        [Test]
        public void TestTypeOfWarrior()
        {

            var actualType = typeof(Arena)
                .GetProperties()
                .First(w => w.Name == "Warriors")
                .PropertyType
                .Name;
            var expectedType = typeof(IReadOnlyCollection<Warrior>)
                .Name;

            Assert.AreEqual(expectedType, actualType);
        }

        [Test]
        public void EmptyArenaReturnZero()
        {
            var actualCount = this.arena.Count;
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountOfEnrollWarriorsInArena()
        {
            var warrior = new Warrior("Ivan", 60, 50);
            this.arena.Enroll(warrior);

            var actualCount = this.arena.Count;
            var expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CollecionOfEnrollWarriorsInArena()
        {
            var warrior1 = new Warrior("Ivan", 60, 50);
            var warrior2 = new Warrior("Dragan", 70, 40);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            var actualArena = this.arena.Warriors.ToList();
            var expectedArena = new List<Warrior>() { warrior1, warrior2 };

            CollectionAssert.AreEqual(expectedArena, actualArena);
        }

        [Test]
        public void ExceptionWhenEnrollExistingWarrior()
        {
            var warrior = new Warrior("Ivan", 60, 50);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void FightWithInvalidAttacker()
        {
            var warrior = new Warrior("Ivan", 60, 50);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Trash", "Ivan");
            });
        }

        [Test]
        public void FightWithInvalidDefender()
        {
            var warrior = new Warrior("Ivan", 60, 50);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Ivan", "Trash");
            });
        }

        [Test]
        public void SuccessFulFight()
        {
            var warriorAttack = new Warrior("Ivan", 60, 100);
            var warriorDefend = new Warrior("Dragan", 70, 100);

            this.arena.Enroll(warriorAttack);
            this.arena.Enroll(warriorDefend);

            this.arena.Fight("Ivan", "Dragan");

            var actualAtHp = warriorAttack.HP;
            var expectedAtHp = 100 - warriorDefend.Damage;

            var actualDeHp = warriorDefend.HP;
            var expectedDeHp = 100 - warriorAttack.Damage;

            Assert.AreEqual(expectedAtHp, actualAtHp);
            Assert.AreEqual(expectedDeHp, actualDeHp);
        }
    }
}
