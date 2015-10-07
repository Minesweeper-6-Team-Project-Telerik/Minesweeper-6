﻿namespace WpfMinesweeper.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    using WpfMinesweeper;
    using WpfMinesweeper.View;
    
    [TestClass]
    public class WindowsTest
    {
        private void TestActionDelegate(string testString)
        {
            return;
        }

        [TestMethod]
        public void TestMainWindowCreation()
        {
            var mainWindow = new MainWindow();

            Assert.AreNotEqual(null, mainWindow, "Main window created successfully");
        }

        [TestMethod]
        public void TestScoreWindowCreation()
        {
            var board = new List<MinesweeperPlayer>();
            var scoreWindow = new ScoresWindow(board);

            Assert.AreNotEqual(null, scoreWindow, "Score window created successfully");
        }

      //  [TestMethod]
      //  [ExpectedException(typeof(NullReferenceException))]
      //  public void TestScoreWindowNotCreatedWhenPassedInvalidData()
      //  {
            // todo: not needed anymore: var scoreWindow = new ScoresWindow(null);
            // todo: not needed anymore: Assert.Fail();
      //  }

        [TestMethod]
        public void TestInputBoxCreation()
        {
            var inputBox = new InputBox(TestActionDelegate);

            Assert.AreNotEqual(null, inputBox, "Input box created successfully");
        }


    }
}