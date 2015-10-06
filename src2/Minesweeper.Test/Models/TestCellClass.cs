// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCellClass.cs" company="">
//   
// </copyright>
// <summary>
//   The test cell class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Test.Models
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    /// <summary>
    /// The test cell class.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestCellClass
    {
        /// <summary>
        /// The test create new cell and expect that all values are false.
        /// </summary>
        [TestMethod]
        public void TestCreateNewCellAndExpectThatAllValuesAreFalse()
        {
            var cell = new MinesweeperCell();
            Assert.AreEqual(
                cell.HasBomb || cell.IsProtected || cell.IsRevealed, 
                false, 
                "Not all initial velues are false!");
        }

        /// <summary>
        /// The test cell can be revealed just once.
        /// </summary>
        [TestMethod]
        public void TestCellCanBeRevealedJustOnce()
        {
            var cell = new MinesweeperCell();
            cell.IsRevealed = true;
            cell.IsRevealed = false;
            Assert.AreEqual(cell.IsRevealed, true, "Cell can be set to not revealed!");
        }

        /// <summary>
        /// The test cell cannot be revealed if protected.
        /// </summary>
        [TestMethod]
        public void TestCellCannotBeRevealedIfProtected()
        {
            var cell = new MinesweeperCell();
            cell.IsProtected = true;
            cell.IsRevealed = true;
            Assert.AreEqual(cell.IsRevealed, false, "Cell can be revealed if it is protected!");
        }

        /// <summary>
        /// The test bomb cannot be removed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidCellOperation), "Putting bomb twice is allowed!")]
        public void TestBombCannotBeRemoved()
        {
            var cell = new MinesweeperCell();
            cell.HasBomb = true;
            cell.HasBomb = false;
        }
    }
}