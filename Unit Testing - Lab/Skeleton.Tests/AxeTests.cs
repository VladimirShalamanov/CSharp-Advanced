using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attac.");
        }

        [Test]
        public void AxeUnderZeroAfterAttack()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(0, 0);
                Dummy dummy = new Dummy(10, 10);

                axe.Attack(dummy);
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Axe is broken."
            );
        }
    }
}