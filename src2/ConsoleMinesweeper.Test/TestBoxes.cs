// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBoxes.cs" company="">
//   
// </copyright>
// <summary>
//   The test boxes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleMinesweeper.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The test boxes.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestBoxes
    {
        /// <summary>
        /// The is button clicked.
        /// </summary>
        private bool isButtonClicked;

        /// <summary>
        /// The test console box with invalid coordinates s hould throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Exception not thrown!")]
        public void TestConsoleBoxWithInvalidCoordinatesSHouldThrow()
        {
            var box = new ConsoleBox<ConsoleColor>(0, 0, 10, 10, ConsoleColor.Black, ConsoleColor.Blue, "n/a");
        }

        /// <summary>
        /// The test console box with invalid sizes s hould throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Exception not thrown!")]
        public void TestConsoleBoxWithInvalidSizesSHouldThrow()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 0, 0, ConsoleColor.Black, ConsoleColor.Blue, "n/a");
        }

        /// <summary>
        /// The test console box with null text should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestConsoleBoxWithNullTextShouldThrow()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Blue, null);
        }

        /// <summary>
        /// The test console box with null colors should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestConsoleBoxWithNullColorsShouldThrow()
        {
            var box = new ConsoleBox<string>(10, 10, 10, 10, null, null, "test");
        }

        /// <summary>
        /// The test console box with valid values should contain correct values.
        /// </summary>
        [TestMethod]
        public void TestConsoleBoxWithValidValuesShouldContainCorrectValues()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            Assert.AreEqual(box.StartX, 10, "Invalid parameter");
            Assert.AreEqual(box.StartY, 10, "Invalid parameter");
            Assert.AreEqual(box.SizeX, 10, "Invalid parameter");
            Assert.AreEqual(box.SizeY, 10, "Invalid parameter");
            Assert.AreEqual(box.ColorBackground, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorText, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.Text, "test", "Invalid parameter");
        }

        /// <summary>
        /// The test console button with null colors should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestConsoleButtonWithNullColorsShouldThrow()
        {
            var box = new ConsoleButton<string>(10, 10, "c1", "c2", null, null, "test");
        }

        /// <summary>
        /// The test console button with valid values should contain correct values.
        /// </summary>
        [TestMethod]
        public void TestConsoleButtonWithValidValuesShouldContainCorrectValues()
        {
            var box = new ConsoleButton<ConsoleColor>(
                10, 
                10, 
                ConsoleColor.Black, 
                ConsoleColor.Black, 
                ConsoleColor.Black, 
                ConsoleColor.Black, 
                "test");
            Assert.AreEqual(box.SizeX, 10, "Invalid parameter");
            Assert.AreEqual(box.SizeY, 10, "Invalid parameter");
            Assert.AreEqual(box.ColorBackground, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorText, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorTextSelected, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorBackSelected, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.Text, "test", "Invalid parameter");
        }

        /// <summary>
        /// The test console button trigger colors are flipped.
        /// </summary>
        [TestMethod]
        public void TestConsoleButtonTriggerColorsAreFlipped()
        {
            var box = new ConsoleButton<ConsoleColor>(
                10, 
                10, 
                ConsoleColor.Black, 
                ConsoleColor.Black, 
                ConsoleColor.Blue, 
                ConsoleColor.Blue, 
                "test");
            box.Trigger();
            Assert.AreEqual(box.ColorBackSelected, ConsoleColor.Black, "Invalid color after trigger");
            Assert.AreEqual(box.ColorTextSelected, ConsoleColor.Black, "Invalid color after trigger");
            box.Trigger();
            Assert.AreEqual(box.ColorBackSelected, ConsoleColor.Blue, "Invalid color after trigger");
            Assert.AreEqual(box.ColorTextSelected, ConsoleColor.Blue, "Invalid color after trigger");
        }

        /// <summary>
        /// The test console button event is fired when clicked.
        /// </summary>
        [TestMethod]
        public void TestConsoleButtonEventIsFiredWhenClicked()
        {
            var box = new ConsoleButton<ConsoleColor>(
                10, 
                10, 
                ConsoleColor.Black, 
                ConsoleColor.Black, 
                ConsoleColor.Blue, 
                ConsoleColor.Blue, 
                "test");
            box.ClickEvent += (sender, args) => { this.isButtonClicked = true; };
            this.isButtonClicked = false;
            box.Click();
            Assert.AreEqual(this.isButtonClicked, true, "Button click do not trigger an event!");
        }
    }
}