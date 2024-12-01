namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp() 
        {
            car = new Car("BMW", "e90", 23.5, 34.6);
        }

        [Test]
        public void CreatingCarCountShouldBeCorrect()
        {
            string expectedMake = "BMW";
            string expectedModel = "e90";
            double expectedFuelConsump = 23.5;
            double expectedFuelCapacity = 34.6;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsump, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeWithZeroFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMakeShouldBeCorrectly(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car(make, "e90", 23.5, 34.6));
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldBeCorrectly(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", model, 23.5, 34.6));
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarShouldThrowExceptionIfFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", "e90", fuelConsumption, 34.6));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarShouldThrowExceptionIfFuelAmountIsNegative()
        {
            Assert.Throws<InvalidOperationException>(()
           => car.Drive(12), "Fuel amount cannot be negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarShouldThrowExceptionIfFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", "e90",23.5 , fuelCapacity));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void CarRefuelShouldThrowExceptionIfFuelIsNegativeOrZero(double fuelToRefuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(fuelToRefuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarRefuelShouldIncreaseFuelAmount()
        {
            int expectedResult = 10;

            car.Refuel(10);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            double expectedResult = 34.6;

            car.Refuel(65);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarDriveMethodShouldDecreaseFuelAmount()
        {
            double expectedResult = 7.65;

            car.Refuel(10);
            car.Drive(10);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarDriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            car.Refuel(2);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => car.Drive(30));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}