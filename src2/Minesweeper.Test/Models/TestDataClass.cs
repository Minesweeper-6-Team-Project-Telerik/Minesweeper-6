using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.Test.Models
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;
    using Minesweeper.Models.Interfaces;

    using System.IO;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestDataClass
    {
        private string testFileName = "test.tmp";

        [TestMethod]
        public void TestSaveAndLoadDataShouldReturnSameResult()
        {
            try
            {
                File.Delete(testFileName);
            }
            catch
            {
                
            }

            var players = new List<MinesweeperPlayer>
                              {
                                  new MinesweeperPlayer()
                                      {
                                          Name = "test",
                                          Time = 0,
                                          Type =
                                              MinesweeperDifficultyType.Easy
                                      }
                              };

            MinesweeperGameData.Save(players, this.testFileName);
            var playersRes = MinesweeperGameData.Load<List<MinesweeperPlayer>>(this.testFileName);

            Assert.AreEqual(players[0].Name, playersRes[0].Name, "Save and load do not produce same results!");
        }

        [TestMethod]
        public void TestSaveNullObjectShouldNotThrow()
        {
            MinesweeperGameData.Save<string>(null, this.testFileName);         
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerOperation),
             "No exception in case of invalid file!")]
        public void TestSaveInvalidFileShouldThrow()
        {
            MinesweeperGameData.Save<string>("aaa", "zz:/test.a");
        }

        [TestMethod]
        public void TestLoadingInvalidStringReturnDefaultData()
        {
            var readStr = MinesweeperGameData.Load<string>(string.Empty);
            Assert.AreEqual(null, readStr, "No default data in case of error!");            
        }
    }
}
