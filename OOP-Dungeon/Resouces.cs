using OOP_Dungeon.DungeonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dungeon.Resources
{
    /// <summary>
    /// Items Class sets all items and adds to list
    /// </summary>
    public class Resouces
    {
        protected int armourNum, weaponNum;
        protected Random ran = new Random();
        public List<Weapon> Weapons { get { return weaponList; } }
        public List<Armour> Armours { get { return armourList; } }
        public int aNum { get { return armourNum; } }
        public int wNum { get { return weaponNum; } }

        private List<Weapon> weaponList  = new List<Weapon>();
        private List<Armour> armourList = new List<Armour>();

        /// <summary>
        /// Constructor for the items
        /// </summary>
        public Resouces() 
        {
            armourList.Add(new Armour(1, "Casual Clothes", 'A', 0, 99));
            weaponList.Add(new Weapon(1, "Fists", 'W', 0, 99));
            armourList.Add(new Armour(100, "Test Armour", 'A', 5, 10));
            weaponList.Add(new Weapon(100, "Test Weapon", 'W', 5, 8));
            // defines which armour and weapon are made
            armourNum = ran.Next(1, Armours.Count);
            weaponNum = ran.Next(1, Weapons.Count);
        }
    }
}
