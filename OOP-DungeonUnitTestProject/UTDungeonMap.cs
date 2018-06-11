using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Dungeon.DungeonModel;
using System.Diagnostics;
using System.IO;

namespace OOP_DungeonUnitTestProject
{
    [TestClass]
    public class UTDungeonMap
    {
        DungeonMap map = new DungeonMap();

        /// <summary>
        /// Simplistic test to ensure Constructor has worked
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {            
            Assert.AreEqual(map.Height, 0);
            Assert.AreEqual(map.Width, 0);
        }

        /// <summary>
        /// Load file tests
        /// </summary>
        [TestMethod]
        public void LoadTest()
        {
            // Ensure load fails if file not found 
            try
            {
                map.load("NotAFile.map");
                Assert.Fail("Should fail with file not found exception");
            }
            catch (FileNotFoundException e)
            { 
                // No need to do anything here really
                Debug.WriteLine(e.Message);
            }

            // Ensure defaul map loads OK
            try
            {
                map.load(Directory.GetCurrentDirectory() + "//testmap.dat");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.AreEqual(6, map.Height);
            Assert.AreEqual(11, map.Width);
        }

        /// <summary>
        /// Test to ensure the correct tile information is loaded from default map
        /// </summary>
        [TestMethod]
        public void getTileTest()
        {
            // Char array representation of defulat map
            char[,] maptest = new char[,]  { {'0','1','2','3','4','5','6','7','8','9','0'},
                                             {'#','#','#','#','#','#','#','#','#','#','#'},
                                             {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                                             {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                                             {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                                             {'#','#','#','#','#','#','#','#','#','#','#'} };

            try
            {
                map.load(Directory.GetCurrentDirectory() + "//testmap.dat");
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        // Note horrible mapping between row column in 2D array
                        Assert.AreEqual(maptest[y, x], map.getTile(x, y));
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
