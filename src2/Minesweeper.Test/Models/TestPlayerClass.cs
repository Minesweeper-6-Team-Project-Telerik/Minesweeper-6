using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.Test.Models
{
    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    [TestClass]
    class TestPlayerClass
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPlayerNullName()
        {
            MinesweeperPlayer player = new MinesweeperPlayer();
        }

        [TestMethod]
        public void TestGetPlayerName()
        {
            MinesweeperPlayer player = new MinesweeperPlayer("Koko"); //?
            string expected = "Koko";
            string current = player.Name;

            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayerCompareWithNonPlayerObject()
        {
            MinesweeperPlayer firstPlayer = new MinesweeperPlayer();
            object secondPlayer = "some player";
            Assert.AreEqual(firstPlayer.CompareTo(secondPlayer)); //?
        }
    }
}
