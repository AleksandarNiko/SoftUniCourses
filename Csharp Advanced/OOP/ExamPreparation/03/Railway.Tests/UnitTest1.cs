using NuGet.Frameworks;

namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;

    public class Tests
    {
        private RailwayStation railwayStation;
        private string train = "sofia-varna";
        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation("Ivan");
        }

        [Test]
        public void CheckConstuctor()
        {
            Assert.AreEqual("Ivan", railwayStation.Name);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void NameIsNullOrWhiteSpace(string name)
        {
            ArgumentException exception =Assert.Throws<ArgumentException>(() => new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void NewArrivalOnBoardShouldWorkCorrectly()
        {
            railwayStation.NewArrivalOnBoard("John");
            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasArrivedShouldWorkCorrectly()
        {
            railwayStation.NewArrivalOnBoard($"{train}");
            Assert.AreEqual("There are other trains to arrive before sofia-plovdiv.",
                railwayStation.TrainHasArrived("sofia-plovdiv"));

            Assert.AreEqual($"{train} is on the platform and will leave in 5 minutes.",
                railwayStation.TrainHasArrived($"{train}"));

            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
            Assert.AreEqual($"{train}", railwayStation.DepartureTrains.Dequeue());
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasLeftShouldWorkCorrectly()
        {
            railwayStation.NewArrivalOnBoard(train);
            railwayStation.TrainHasArrived(train);

            Assert.AreEqual(false, railwayStation.TrainHasLeft("Non existance"));
            Assert.AreEqual(true, railwayStation.TrainHasLeft(train));
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
        }
    }
}