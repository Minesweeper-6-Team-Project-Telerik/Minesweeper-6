using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.Test.Models
{
    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    [TestClass]
    public class TestCellClass
    {
        [TestMethod]
        public void TestCreateNewCellAndExpectThatAllValuesAreFalse()
        {
            var cell = new MinesweeperCell();
            Assert.AreEqual(cell.HasBomb || cell.IsProtected || cell.IsRevealed, false, "Not all initial velues are false!");
        }

        [TestMethod]
        public void TestCellCanBeRevealedJustOnce()
        {
            var cell = new MinesweeperCell();
            cell.IsRevealed = true;
            cell.IsRevealed = false;
            Assert.AreEqual(cell.IsRevealed, true, "Cell can be set to not revealed!");
        }

        [TestMethod]
        public void TestCellCannotBeRevealedIfProtected()
        {
            var cell = new MinesweeperCell();
            cell.IsProtected = true;
            cell.IsRevealed = true;
            Assert.AreEqual(cell.IsRevealed, false, "Cell can be revealed if it is protected!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCellOperation),
             "Putting bomb twice is allowed!")]
        public void TestBombCannotBeRemoved()
        {
            var cell = new MinesweeperCell();
            cell.HasBomb = true;
            cell.HasBomb = false;            
        }

    }
}
