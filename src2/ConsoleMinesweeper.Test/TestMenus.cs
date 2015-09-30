using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMinesweeper.Test
{
    using ConsoleMinesweeper.Interfaces;

    using Moq;

    [TestClass]
    public class TestMenus
    {
        private string testStr;
        private ConsoleKeyInfo[] testKeys = new ConsoleKeyInfo[30];
        private int keysCnt;

        private IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> ConsoleMock()
        {
            var mockedCarsRepository = new Mock<IConsoleWrapper<ConsoleColor, ConsoleKeyInfo>>();
            mockedCarsRepository.Setup(r => r.Write(It.IsAny<string>())).Callback<string>(r => { this.testStr = r; });
            mockedCarsRepository.Setup(r => r.ReadKey(It.IsAny<bool>())).Returns(() =>
            {
                return testKeys[keysCnt++];
            });
            mockedCarsRepository.Setup(r => r.ResetColor()).Verifiable();
            mockedCarsRepository.Setup(r => r.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>())).Verifiable(); ;
            return mockedCarsRepository.Object;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            ConsoleMenus.StartGameMenu(this.ConsoleMock());
            ConsoleMenus.StartMainMenu(this.ConsoleMock());
            ConsoleMenus.StartScoresMenu(this.ConsoleMock());

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
        //    ConsoleMenus.StartMainMenu(this.ConsoleMock());
        }
    }
}
