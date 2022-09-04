namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void NewWarrior()
        {
            string expectedName = "Ivan";
            int expectedDamage = 60;
            int expectedHp = 50;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHp = warrior.HP;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]
        public void NameSuccessfulWarrior()
        {
            string expectedName = "Ivan";
            int expectedDamage = 60;
            int expectedHp = 50;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase("")]
        [TestCase("      ")]
        [TestCase(null)]
        public void NameExceptionWarrior(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 60, 50);
            });
        }

        [Test]
        public void DamageSuccessfulWarrior()
        {
            string expectedName = "Ivan";
            int expectedDamage = 60;
            int expectedHp = 50;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-9)]
        public void DamageExceptionWarrior(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", damage, 50);
            });
        }

        [Test]
        public void HPSuccessfulWarrior()
        {
            string expectedName = "Ivan";
            int expectedDamage = 60;
            int expectedHp = 50;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            int actualHp = warrior.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestCase(-1)]
        [TestCase(-9)]
        public void HPExceptionWarrior(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", 60, hp);
            });
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void CannotAttackEnemy(int hp)
        {
            Warrior warriorAttack = new Warrior("Ivan", 50, 60);
            Warrior warriorDefend = new Warrior("Dragan", 55, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorAttack.Attack(warriorDefend);
            });
        }

        [TestCase(60, 70)]
        [TestCase(67, 78)]
        [TestCase(80, 81)]
        public void EnemyIsStronger(int attackHp, int defendDamage)
        {
            Warrior warriorAttack = new Warrior("Ivan", 60, attackHp);
            Warrior warriorDefend = new Warrior("Dragan", defendDamage, 65);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorAttack.Attack(warriorDefend);
            });
        }

        [TestCase(70, 60)]
        [TestCase(78, 67)]
        [TestCase(81, 80)]
        public void SuccessfulAttackHp(int attackHp, int defendDamage)
        {
            Warrior warriorAttack = new Warrior("Ivan", 60, attackHp);
            Warrior warriorDefend = new Warrior("Dragan", defendDamage, 65);

            warriorAttack.Attack(warriorDefend);

            int actualHp = warriorAttack.HP;
            int expectedHp = attackHp - defendDamage;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestCase(70, 60)]
        [TestCase(78, 67)]
        [TestCase(81, 80)]
        public void SuccessfulKillEnemy(int attackDamage, int defendHp)
        {
            Warrior warriorAttack = new Warrior("Ivan", attackDamage, 100);
            Warrior warriorDefend = new Warrior("Dragan", 50, defendHp);

            warriorAttack.Attack(warriorDefend);

            int actualHp = warriorDefend.HP;
            int expectedHp = 0;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestCase(60, 70)]
        [TestCase(67, 78)]
        [TestCase(80, 81)]
        public void SuccessfulAttackEnemyHp(int attackDamage, int defendHp)
        {
            Warrior warriorAttack = new Warrior("Ivan", attackDamage, 100);
            Warrior warriorDefend = new Warrior("Dragan", 50, defendHp);

            warriorAttack.Attack(warriorDefend);

            int actualHp = warriorDefend.HP;
            int expectedHp = defendHp - attackDamage;

            Assert.AreEqual(expectedHp, actualHp);
        }
    }
}