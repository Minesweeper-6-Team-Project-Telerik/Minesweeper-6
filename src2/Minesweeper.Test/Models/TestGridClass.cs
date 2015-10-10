// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestGridClass.cs" company="">
//   
// </copyright>
// <summary>
//   The test grid class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Test.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    /// <summary>
    /// The test grid class.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestGridClass
    {
        /// <summary>
        /// The is bomb fired.
        /// </summary>
        private bool isBombFired;

        /// <summary>
        /// The test create new grid should create correct grid structure.
        /// </summary>
        [TestMethod]
        public void TestCreateNewGridShouldCreateCorrectGridStructure()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);
            Assert.AreNotEqual(grid, null, "New grid is null!");
        }

        /// <summary>
        /// The test grid initialization with invalid values should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Grid do not throw an exception in case of invalid input values!")
        ]
        public void TestGridInitializationWithInvalidValuesShouldThrow()
        {
            var grid = new MinesweeperGrid(1, -1, 0);
        }

        // reveal cells
        /// <summary>
        /// The test reveal all cells and check if they are revealed 1.
        /// </summary>
        [TestMethod]
        public void TestRevealAllCellsAndCheckIfTheyAreRevealed1()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    grid.RevealCell(i, j);
                }
            }

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellRevealed(i, j), true, "Not all cells are reveavled!");
                }
            }
        }

        /// <summary>
        /// The test reveal all cells and check if they are revealed 2.
        /// </summary>
        [TestMethod]
        public void TestRevealAllCellsAndCheckIfTheyAreRevealed2()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);

            grid.RevealAllMines();

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellRevealed(i, j), true, "Not all cells are reveavled!");
                }
            }
        }

        // protect mines
        /// <summary>
        /// The test protect all cells and check if they are protected.
        /// </summary>
        [TestMethod]
        public void TestProtectAllCellsAndCheckIfTheyAreProtected()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Hard);

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    grid.ProtectCell(i, j);
                }
            }

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellProtected(i, j), true, "Not all cells are protected!");
                }
            }

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    grid.TriggerCellProtection(i, j);
                }
            }

            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellProtected(i, j), false, "Not all cells are unprotected!");
                }
            }
        }

        /// <summary>
        /// The test reveal all cells and check if bomb event is fired.
        /// </summary>
        [TestMethod]
        public void TestRevealAllCellsAndCheckIfBombEventIsFired()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.BoomEvent += this.GridOnBoomEvent;

            this.isBombFired = false;
            for (var i = 0; i < grid.Rows; i++)
            {
                for (var j = 0; j < grid.Cols; j++)
                {
                    grid.RevealCell(i, j);
                }
            }

            Assert.AreEqual(this.isBombFired, true, "Bomb event is not fired!");
        }

        /// <summary>
        /// The grid on boom event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GridOnBoomEvent(object sender, EventArgs eventArgs)
        {
            this.isBombFired = true;
        }

        /// <summary>
        /// The test reveal cell with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestRevealCellWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.RevealCell(-1, -1);
        }

        /// <summary>
        /// The test protect cell with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestProtectCellWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.ProtectCell(-1, -1);
        }

        /// <summary>
        /// The test neighbour mines count with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestNeighbourMinesCountWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.NeighborMinesCount(-1, -1);
        }

        /// <summary>
        /// The test is cell valid with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestIsCellValidWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.IsCellRevealed(-1, -1);
        }

        /// <summary>
        /// The test is cell protected with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestIsCellProtectedWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.IsCellProtected(-1, -1);
        }

        /// <summary>
        /// The test has cell bomb with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestHasCellBombWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.HasCellBomb(-1, -1);
        }

        /// <summary>
        /// The test trigger cell protection with invalid input should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation), 
            "Grid do not throw an exception in case of invalid input values!")]
        public void TestTriggerCellProtectionWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.TriggerCellProtection(-1, -1);
        }
    }
}