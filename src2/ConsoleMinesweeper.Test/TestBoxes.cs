using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMinesweeper.Test
{
    using System.Collections.Generic;

    using ConsoleMinesweeper;
    using ConsoleMinesweeper.Models;

    [TestClass]
    public class TestBoxes
    {
        private bool isButtonClicked = false;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Exception not thrown!")]
        public void TestConsoleBoxWithInvalidCoordinatesSHouldThrow()
        {
            var box = new ConsoleBox<ConsoleColor>(0, 0, 10, 10, ConsoleColor.Black, ConsoleColor.Blue, "n/a");            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Exception not thrown!")]
        public void TestConsoleBoxWithInvalidSizesSHouldThrow()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 0, 0, ConsoleColor.Black, ConsoleColor.Blue, "n/a");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Exception not thrown!")]
        public void TestConsoleBoxWithNullTextShouldThrow()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Blue, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Exception not thrown!")]
        public void TestConsoleBoxWithNullColorsShouldThrow()
        {
            var box = new ConsoleBox<string>(10, 10, 10, 10, null, null, "test");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Exception not thrown!")]
        public void TestConsoleButtonWithNullColorsShouldThrow()
        {
            var box = new ConsoleButton<string>(10, 10, "c1", "c2", null, null, "test");
        }

        [TestMethod]
        public void TestConsoleButtonWithValidValuesShouldContainCorrectValues()
        {
            var box = new ConsoleButton<ConsoleColor>(10, 10, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, "test");
            Assert.AreEqual(box.SizeX, 10, "Invalid parameter");
            Assert.AreEqual(box.SizeY, 10, "Invalid parameter");
            Assert.AreEqual(box.ColorBackground, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorText, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorTextSelected, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.ColorBackSelected, ConsoleColor.Black, "Invalid parameter");
            Assert.AreEqual(box.Text, "test", "Invalid parameter");
        }

        [TestMethod]
        public void TestConsoleButtonTriggerColorsAreFlipped()
        {
            var box = new ConsoleButton<ConsoleColor>(10, 10, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Blue, "test");
            box.Trigger();
            Assert.AreEqual(box.ColorBackSelected, ConsoleColor.Black, "Invalid color after trigger");
            Assert.AreEqual(box.ColorTextSelected, ConsoleColor.Black, "Invalid color after trigger");
            box.Trigger();
            Assert.AreEqual(box.ColorBackSelected, ConsoleColor.Blue, "Invalid color after trigger");
            Assert.AreEqual(box.ColorTextSelected, ConsoleColor.Blue, "Invalid color after trigger");
        }

        [TestMethod]
        public void TestConsoleButtonEventIsFiredWhenClicked()
        {
            var box = new ConsoleButton<ConsoleColor>(10, 10, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Blue, "test");
            box.ClickEvent += (sender, args) => { this.isButtonClicked = true; };
            this.isButtonClicked = false;
            box.Click();
            Assert.AreEqual(this.isButtonClicked, true, "Button click do not trigger an event!");
        }
    }
}
