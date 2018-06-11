using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Dungeon.Resources;

///
/// Author: Nigel Edwards
/// Date: Jan 2015
/// 
namespace OOP_Dungeon.DungeonModel
{
    public class Dungeon
    {
        private DungeonMap m_map;
        public DungeonMap Map { get { return m_map; } }
        private Player m_player;
        public Player Player { get { return m_player; } }
        private Monster m_monster;
        public Monster Monster { get { return m_monster; } set { m_monster = value; } }
        private Resouces m_items;
        public Resouces Items { get { return m_items; } }

        /// <summary>
        /// Construct a new dugeon using a map from given file and setting player at location x,y
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Dungeon(String path, int x, int y, int mX, int mY)
        {
            m_map = new DungeonMap();
            m_map.load(path);
            m_items = new Resouces();
            m_player = new Player('@', x, y, m_items.Weapons.Find(weapon => weapon.name == "Fists"), m_items.Armours.Find(armour => armour.name == "Casual Clothes"));
            m_monster = new Monster('M', mX, mY);
        }

        //ʘ ʇ
    }
}
