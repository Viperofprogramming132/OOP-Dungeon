using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using OOP_Dungeon.DungeonModel;
using OOP_Dungeon;

namespace OOP_DungeonUnitTestProject
{
    [TestClass]
    public class UTCharacter
    {
        /// <summary>
        /// Suimplistic Constructor Test
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            Weapon w = new Weapon(1, "weapon", 'W', 1, 1);
            Armour a = new Armour(2, "armour", 'A', 1, 1);
            Player c = new Player('P', 1, 2, w, a);
            Assert.AreEqual(new Point(1, 2), c.Pos);
            Assert.AreEqual('P', c.Symbol);
            Assert.AreEqual(1, c.attack);
            Assert.AreEqual(2, c.defence);
        }
    }
}
