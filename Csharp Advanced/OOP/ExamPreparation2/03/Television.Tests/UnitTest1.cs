namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Xml.Linq;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice device;
        [SetUp]
        public void Setup()
        {
            device = new TelevisionDevice("Toshiba", 200.20, 15, 15);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            string expectedBrand = "Toshiba";
            double expectedPrice = 200.20;
            int expectedWidth = 15;
            int expectedHeight = 15;
                
            Assert.That(device,Is.Not.Null);
            Assert.AreEqual(expectedBrand, device.Brand);
            Assert.AreEqual(expectedPrice, device.Price);
            Assert.AreEqual(expectedWidth, device.ScreenWidth);
            Assert.AreEqual(expectedHeight, device.ScreenHeigth);

        }

        [Test]
        public void SwitchOnMethodShouldWorkCorrectly()
        {
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            string actual = device.SwitchOn();
            Assert .AreEqual(expected, actual);
        }

        [Test]
        public void Test_Assert_SwitchOn_LastMuted_ReturnsCorrectInformation()
        {
            device.MuteDevice();
            string expectedOutput = "Cahnnel 0 - Volume 13 - Sound Off";

            string output = device.SwitchOn();

            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void ChangeNegativeChannelShouldWorkCorrrectly()
        {
            Assert.Throws<ArgumentException>(() => device.ChangeChannel(-1));
        }

        [Test]
        public void ChangeValidChannel()
        {
            int newChannel = 5;

            int channel = device.ChangeChannel(newChannel);
            Assert.AreEqual(newChannel, channel);
        }
        [Test]
        public void ToStringMethodShouldWorkCorrectly()
        {
            string expected= $"TV Device: {device.Brand}, Screen Resolution: {device.ScreenWidth}x{device.ScreenHeigth}, Price {device.Price}$";
            string actual = device.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeUpChangeMethodShouldWorkCorrectly(int volume)
        {
            string expected = "Volume: 20";
            string actual= device.VolumeChange("UP",volume);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeDownChangeMethodShouldWorkCorrectly(int volume)
        {
            string expected = "Volume: 6";
            string actual = device.VolumeChange("DOWN", volume);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MuteMethodShouldWorkCorrectly()
        {
            bool expected = true;
            bool actual = device.MuteDevice();
            Assert.AreEqual(expected, actual);
        }
    }
}