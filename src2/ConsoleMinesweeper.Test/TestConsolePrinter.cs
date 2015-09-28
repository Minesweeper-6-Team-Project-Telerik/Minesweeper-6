using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConsoleMinesweeper.Test
{
    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;

    [TestClass]
    public class TestConsolePrinter
    {
        private string testStr;

        private ConsoleKeyInfo testKey;
        private ConsoleKeyInfo testKey2;

        private int calls;
        private int events;

        private EventHandler openCellEvent;

        private EventHandler protectCellEvent;

        private IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> ConsoleMock()
        {
            var mockedCarsRepository = new Mock<IConsoleWrapper<ConsoleColor, ConsoleKeyInfo>>();
            mockedCarsRepository.Setup(r => r.Write(It.IsAny<string>())).Callback<string>(r => { this.testStr = r; });
            mockedCarsRepository.Setup(r => r.ReadKey(It.IsAny<bool>())).Returns(() =>
                {
                calls++;

                if (calls < 50)
                {
                    return testKey;
                }
                else if (calls < 100)
                {
                    return testKey2;
                }
                else
                {
                    return new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
                }
            });
            mockedCarsRepository.Setup(r => r.ResetColor()).Verifiable();
            mockedCarsRepository.Setup(r => r.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>())).Verifiable(); ;
            return mockedCarsRepository.Object;
        }

        [TestMethod]
        public void TestConsolePrinterPrintShouldReturnValue()
        {
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            this.testStr = "";
            ConsolePrinter.Print(this.ConsoleMock(), box);
            Assert.AreNotEqual(this.testStr, "", "ConsolePrinter do not print!");
        }

        [TestMethod]
        public void TestConsolePrinterPrintGrid()
        {
            calls = 0;
            this.testStr = "";
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKey2 = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            var box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreNotEqual(this.testStr, "", "ConsolePrinter grid do not print!");

            calls = 0;
            this.testStr = "";
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.RightArrow, false, false, false);
            this.testKey2 = new ConsoleKeyInfo(' ', ConsoleKey.LeftArrow, false, false, false);
            box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreNotEqual(this.testStr, "", "ConsolePrinter grid do not print!");

            this.openCellEvent += (sender, args) => { events++; };
            this.protectCellEvent += (sender, args) => { events++; };

            calls = 0;
            this.testStr = "";
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreEqual(events, 49, "ConsolePrinter grid do not print!");

            calls = 0;
            this.testStr = "";
            this.testKey = new ConsoleKeyInfo(' ', ConsoleKey.F, false, false, false);
            box = new ConsoleBox<ConsoleColor>(10, 10, 10, 10, ConsoleColor.Black, ConsoleColor.Black, "test");
            ConsolePrinter.PrintGrid(this.ConsoleMock(), box, this.openCellEvent, this.protectCellEvent);
            Assert.AreEqual(events, 98, "ConsolePrinter grid do not print!");
        }
    }
}
