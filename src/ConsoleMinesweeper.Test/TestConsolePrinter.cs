// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestConsolePrinter.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The test console printer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleMinesweeper.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The test console printer.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestConsolePrinter
    {
        /// <summary>
        /// The calls.
        /// </summary>
        private int calls;

        /// <summary>
        /// The events.
        /// </summary>
        private int events;

        /// <summary>
        /// The open cell event.
        /// </summary>
        private EventHandler openCellEvent;

        /// <summary>
        /// The protect cell event.
        /// </summary>
        private EventHandler protectCellEvent;

        /// <summary>
        /// The test key.
        /// </summary>
        private ConsoleKeyInfo testKey;

        /// <summary>
        /// The test key 2.
        /// </summary>
        private ConsoleKeyInfo testKey2;

        /// <summary>
        /// The test str.
        /// </summary>
        private string testStr;

        /// <summary>
        /// The console mock.
        /// </summary>
        /// <returns>
        /// The <see cref="IConsoleWrapper"/>.
        /// </returns>
        private IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> ConsoleMock()
        {
            var mockedWrapper = new Mock<IConsoleWrapper<ConsoleColor, ConsoleKeyInfo>>();
            mockedWrapper.Setup(r => r.Write(It.IsAny<string>())).Callback<string>(r => { this.testStr = r; });
            mockedWrapper.Setup(r => r.ReadKey(It.IsAny<bool>())).Returns(
                () =>
                    {
                        this.calls++;

                        if (this.calls < 50)
                        {
                            return this.testKey;
                        }

                        if (this.calls < 100)
                        {
                            return this.testKey2;
                        }

                        return new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
                    });
            mockedWrapper.Setup(r => r.ResetColor()).Verifiable();
            mockedWrapper.Setup(r => r.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            return mockedWrapper.Object;
        }

        /// <summary>
        /// The test console printer print should return value.
        /// </summary>
        [TestMethod]
        public void TestConsolePrinterPrintShouldReturnValue()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            this.testStr = string.Empty;
            ConsolePrinter.Print(this.ConsoleMock(), box);
            Assert.AreNotEqual(this.testStr, string.Empty, "ConsolePrinter do not print!");
        }

        /// <summary>
        /// The test console printer print grid.
        /// </summary>
        [TestMethod]
        public void TestConsolePrinterPrintGrid()
        {
            this.calls = 0;
            this.testStr = string.Empty;
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKey2 = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreNotEqual(this.testStr, string.Empty, "ConsolePrinter grid do not print!");

            this.calls = 0;
            this.testStr = string.Empty;
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.RightArrow, false, false, false);
            this.testKey2 = new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false);
            box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreNotEqual(this.testStr, string.Empty, "ConsolePrinter grid do not print!");

            this.openCellEvent += (sender, args) => { this.events++; };
            this.protectCellEvent += (sender, args) => { this.events++; };

            this.calls = 0;
            this.testStr = string.Empty;
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreEqual(this.events, 49, "ConsolePrinter grid do not print!");

            this.calls = 0;
            this.testStr = string.Empty;
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.F, false, false, false);
            box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreEqual(this.events, 98, "ConsolePrinter grid do not print!");
        }
    }
}
