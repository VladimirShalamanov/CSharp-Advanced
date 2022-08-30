using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthAfterAttack()
        {
            Axe axe = new Axe(1, 2);
            Dummy dummy = new Dummy(2, 2);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(1));
        }

        [Test]
        public void DummyIsDeadAfterAttack()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(1, 2);
                Dummy dummy = new Dummy(0, 2);

                axe.Attack(dummy);
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
             "Dummy is dead."
            );
        }

        [Test]
        public void DummyIsDeadGiveXp()
        {
            Axe axe = new Axe(1, 2);
            Dummy dummy = new Dummy(0, 2);

            dummy.GiveExperience();

            Assert.That(dummy.IsDead());
        }

        [Test]
        public void DummyIsNotDead()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(1, 2);
                Dummy dummy = new Dummy(2, 2);

                axe.Attack(dummy);

                dummy.GiveExperience();
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Target is not dead."
            );
        }
    }
}