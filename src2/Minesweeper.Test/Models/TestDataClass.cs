using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.Test.Models
{
    using System.Diagnostics.CodeAnalysis;

    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestDataClass
    {
        private string testFileName = "test.tmp";

        [TestMethod]
        public void TestSaveAndLoadDataShouldReturnSameResult()
        {
            var testStr = "test string";
            MinesweeperGameData.Save(testStr, this.testFileName);
            var readStr = MinesweeperGameData.Load<string>(this.testFileName);

            Assert.AreEqual(testStr, readStr, "Save and load do not produce same results!");
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
