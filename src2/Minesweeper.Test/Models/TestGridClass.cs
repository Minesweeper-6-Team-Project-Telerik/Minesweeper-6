using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.Test.Models
{
    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    [TestClass]
    public class TestGridClass
    {
        private bool isBombFired;

        [TestMethod]
        public void TestCreateNewGridShouldCreateCorrectGridStructure()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);
            Assert.AreNotEqual(grid, null, "New grid is null!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestGridInitializationWithInvalidValuesShouldThrow()
        {
            var grid = new MinesweeperGrid(1, -1, 0);            
        }

        // reveal cells
        [TestMethod]
        public void TestRevealAllCellsAndCheckIfTheyAreRevealed1()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    grid.RevealCell(i, j);
                }
            }

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellRevealed(i, j), true, "Not all cells are reveavled!");
                }
            }
        }

        [TestMethod]
        public void TestRevealAllCellsAndCheckIfTheyAreRevealed2()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);

            grid.RevealAllMines();

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellRevealed(i, j), true, "Not all cells are reveavled!");
                }
            }
        }

        // protect mines
        [TestMethod]
        public void TestProtectAllCellsAndCheckIfTheyAreProtected()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Hard);

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    grid.ProtectCell(i, j);
                }
            }

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellProtected(i, j), true, "Not all cells are protected!");
                }
            }

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    grid.TriggerCellProtection(i, j);
                }
            }

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    Assert.AreEqual(grid.IsCellProtected(i, j), false, "Not all cells are unprotected!");
                }
            }
        }

        [TestMethod]
        public void TestRevealAllCellsAndCheckIfBombEventIsFired()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.BoomEvent += this.GridOnBoomEvent;

            this.isBombFired = false;
            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Cols; j++)
                {
                    grid.RevealCell(i, j);
                }
            }

            Assert.AreEqual(this.isBombFired, true, "Bomb event is not fired!");

        }

        private void GridOnBoomEvent(object sender, EventArgs eventArgs)
        {
            this.isBombFired = true;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestRevealCellWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.RevealCell(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestProtectCellWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.ProtectCell(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestNeighbourMinesCountWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.NeighbourMinesCount(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestIsCellValidWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.IsCellRevealed(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestIsCellProtectedWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.IsCellProtected(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidGridOperation),
             "Grid do not throw an exception in case of invalid input values!")]
        public void TestHasCellBombWithInvalidInputShouldThrow()
        {
            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium);
            grid.HasCellBomb(-1, -1);
        }

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
