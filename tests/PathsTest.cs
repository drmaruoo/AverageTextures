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
        public void testGetAllPaths()
        {
            //arrange
            createFakeDirectory();
            string directory = @"Fakes\";
            List<string> paths = new List<string>();
            List<string> expectedPaths = new List<string>();
            Paths.filetypes filetype = Paths.filetypes.txt;
            expectedPaths.Add(@"Fakes\Test.txt");

            //act
            paths = Paths.getAllPaths(directory, filetype);

            //assert
            CollectionAssert.AreEqual(expectedPaths, paths);
        }

        [TestMethod]
        public void testGetFileInfoList()
        {
            //arrange
            createFakeDirectory();
            string directory = @"Fakes\";
            List<FileInfo> fileInfos = new List<FileInfo>();
            List<FileInfo> expectedFileInfos = new List<FileInfo>();
            Paths.filetypes filetype = Paths.filetypes.txt;

            expectedFileInfos.Add(new FileInfo(directory + "Test.txt"));

            //act
            fileInfos = Paths.getFileInfoList(directory, filetype);


            //assert
            Assert.AreEqual(expectedFileInfos[0].ToString(), fileInfos[0].ToString());
        }

        [TestMethod]
        public void testGetPathsCount()
        {
            //arrange
            createFakeDirectory();
            string directory = @"Fakes\";
            int pathCount;
            int expectedPathCount = 1;
            Paths.filetypes filetype = Paths.filetypes.txt;

            //act
            pathCount = Paths.getPathsCount(directory, filetype);

            //assert
            Assert.AreEqual(expectedPathCount, pathCount);

        }

        [TestMethod]
        public void testGetNewPath(FileInfo fileinfo, string newName)
        {
            //arrange

            //act

            //assert
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
