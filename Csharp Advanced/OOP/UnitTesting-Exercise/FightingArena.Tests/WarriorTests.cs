namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Reflection;
    using System;
    using System.Xml.Serialization;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Aleks", 30, 200);
        }
        [Test]
        public void WarriorConstructorShouldWorkCorrectly()
        {
            string expectedName = "Aleks";
            int expectedDamage = 30;
            int expectedHP = 200;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WarriorShouldThrowExceptionIfNameIsEmptyOrWhitespace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior(name, 30,200));
            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WarriorShouldThrowExceptionIfDamageIsNotPositive(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior("Aleks", damage, 200));
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-1)]
        public void WarriorShouldThrowExceptionIfHPIsNotPositive(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior("Aleks",30,hp));

            Assert.AreEqual("HP should not be negative!", exception.Message);      
        }

        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAtackerHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAtackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [TestCase(10)]
        [TestCase(30)]
        public void WarriorShouldNotAttackIfHisHPIsEqualOrLessThan30(int hp)
        {
            Warrior attacker = new("Aleks", 10, hp);
            Warrior defender = new("Ivan", 5, 90);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);     
        }

        [TestCase(10)]
        [TestCase(30)]
        public void WarriorShouldNotAttackEnemyWithHPEqualOrLessThan30(int hp)
        {
            Warrior attacker = new("Aleks", 10, 90);
            Warrior defender = new("Ivan", 5, hp);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        [Test]
        public void WarriorShouldNotAttackEnemyWithBiggerDamageThanHisHealth()
        {
            Warrior attacker = new("Aleks", 10, 35);
            Warrior defender = new("Ivan", 45, 100);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            Warrior attacker = new Warrior("Aleks", 50, 100);
            Warrior defender = new Warrior("Ivan", 45, 40);

            int expectedAttackerHP = 55;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}