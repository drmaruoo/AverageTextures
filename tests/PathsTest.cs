using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AverageTextures;
using System.IO;

namespace AverageTexturesTests
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void TestGetAllPaths()
        {
            //arrange
            createFakeDirectory();
            string directory = @"Fakes\";
            List<string> paths = new List<string>();
            List<string> expectedPaths = new List<string>();
            Paths.filetypes filetype = Paths.filetypes.txt;
            expectedPaths.Add(@"Fakes\Test.txt");

            //act
            paths = Paths.GetAllPaths(directory, filetype);

            //assert
            CollectionAssert.AreEqual(expectedPaths, paths);
        }

        [TestMethod]
        public void TestGetPathsCount()
        {
            //arrange
            createFakeDirectory();
            string directory = @"Fakes\";
            int pathCount;
            int expectedPathCount = 1;
            Paths.filetypes filetype = Paths.filetypes.txt;

            //act
            pathCount = Paths.GetPathsCount(directory, filetype);

            //assert
            Assert.AreEqual(expectedPathCount, pathCount);
        }

        private static void createFakeDirectory()
        {
            if (!Directory.Exists(@"Fakes\"))
            {
                Directory.CreateDirectory(@"Fakes\");
                File.Create(@"Fakes\Test.txt");
                File.Create(@"Fakes\Test.png");
            }
        }
    }
}
