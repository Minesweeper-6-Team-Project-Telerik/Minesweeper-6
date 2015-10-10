// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDataClass.cs" company="">
//   
// </copyright>
// <summary>
//   The test data class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Test.Models
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    /// <summary>
    /// The test data class.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestDataClass
    {
        /// <summary>
        /// The test file name.
        /// </summary>
        private readonly string testFileName = "test.tmp";

        /// <summary>
        /// The test save and load data should return same result.
        /// </summary>
        [TestMethod]
        public void TestSaveAndLoadDataShouldReturnSameResult()
        {
            try
            {
                File.Delete(this.testFileName);
            }
            catch
            {
            }

            var players = new List<MinesweeperPlayer>
                              {
                                  new MinesweeperPlayer
                                      {
                                          Name = "test", 
                                          Time = 0, 
                                          Type = MinesweeperDifficultyType.Easy
                                      }
                              };

            MinesweeperGameData.Save(players, this.testFileName);
            var playersRes = MinesweeperGameData.Load<List<MinesweeperPlayer>>(this.testFileName);

            Assert.AreEqual(players[0].Name, playersRes[0].Name, "Save and load do not produce same results!");
        }

        /// <summary>
        /// The test save null object should not throw.
        /// </summary>
        [TestMethod]
        public void TestSaveNullObjectShouldNotThrow()
        {
            MinesweeperGameData.Save<string>(null, this.testFileName);
        }

        /// <summary>
        /// The test save invalid file should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerOperation), "No exception in case of invalid file!")]
        public void TestSaveInvalidFileShouldThrow()
        {
            MinesweeperGameData.Save("aaa", "zz:/test.a");
        }

        /// <summary>
        /// The test load invalid file should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerOperation), "No exception in case of invalid file!")]
        public void TestLoadInvalidFileShouldThrow()
        {
            MinesweeperGameData.Load<string>("zz:/test.a");
        }

        /// <summary>
        /// The test loading invalid string return default data.
        /// </summary>
        [TestMethod]
        public void TestLoadingInvalidStringReturnDefaultData()
        {
            var readStr = MinesweeperGameData.Load<string>(string.Empty);
            Assert.AreEqual(null, readStr, "No default data in case of error!");
        }
    }
}