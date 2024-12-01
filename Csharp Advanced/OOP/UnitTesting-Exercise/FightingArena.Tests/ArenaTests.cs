namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstrucurShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new Warrior("Dimitri", 50, 200);

            arena.Enroll(warrior);
            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedResult, arena.Count);
        }

        [Test]
        public void ArenaEnrollShouldWorkCorrectly()
        {
            Warrior warrior = new("Gosho", 5, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void ArenaEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new("Dimitri", 50, 200);
            arena.Enroll(warrior);
            InvalidOperationException exception =Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!",exception.Message);
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior attacker = new("Ivan", 15, 100);
            Warrior defender = new("George", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 35;

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfAttackerNotFound()
        {
            Warrior attacker1 = new Warrior("Dimitri", 20, 200);
            Warrior defender1 = new Warrior("Kolio", 30, 400);

            arena.Enroll(defender1);

            InvalidOperationException exception1 = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker1.Name, defender1.Name));
            Assert.AreEqual($"There is no fighter with name {attacker1.Name} enrolled for the fights!", exception1.Message);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfDefenderNotFound()
        {
            Warrior attacker1 = new Warrior("Dimitri", 20, 200);
            Warrior defender1 = new Warrior("Kolio", 30, 400);

            arena.Enroll(attacker1);

            InvalidOperationException exception1 = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker1.Name, defender1.Name));
            Assert.AreEqual($"There is no fighter with name {defender1.Name} enrolled for the fights!", exception1.Message);
        }
    }
}
