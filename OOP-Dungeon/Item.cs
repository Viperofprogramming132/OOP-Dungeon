using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Dungeon
{
    /// <summary>
    /// Item Class base class for all the items
    /// </summary>
    public class Item
    {
        string m_name;
        char m_symbol;
        private Point m_pos;

        //Gets for items
        public char Symbol { get { return m_symbol; } }
        public string name { get { return m_name; } }
        public Point Pos { get { return m_pos; } }

        public Item(string name, char symbol, int x, int y)
        {
            m_name = name;
            m_symbol = symbol;
            m_pos = new Point(x, y);
        }


    }

    /// <summary>
    /// Armour inherits from item
    /// </summary>
    public class Armour : Item
    {
        private byte m_AC;

        //gets for armour
        public byte AC { get { return m_AC; } }

        public Armour (byte AC, string name, char symbol, int x, int y) : base(name, symbol, x, y)
        {
            m_AC = AC;
        }

        
    }
    public class Weapon : Item
    {
        private byte m_damage;

        //Gets for Weapon
        public byte damage { get { return m_damage; } }

        public Weapon(byte damage, string name, char symbol, int x, int y)
            : base(name, symbol, x, y)
        {
            m_damage = damage;
        }

        
    }
}
