using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
/// Author: Nigel Edwards
/// Date: Jan 2015
/// 
namespace OOP_Dungeon.DungeonModel
{
    /// <summary>
    /// Character base class for dungeon game
    /// </summary>
    public class Character
    {
        private char m_symbol;
        public char Symbol { get { return m_symbol; } }

        public enum DIR { NONE, UP, DOWN, LEFT, RIGHT };

        private sbyte m_health;
        protected byte m_defence;
        protected byte m_attack;
        public sbyte health { get { return m_health; } set { m_health = value; } } 
        public byte defence { get { return m_defence; } }
        public byte attack { get { return m_attack; } }

        private Point m_pos;
        public Point Pos { get { return m_pos; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Character(char symbol, int x, int y, sbyte health, byte defence, byte attack)
        {
            m_attack = attack;
            m_defence = defence;
            m_health = health;
            m_symbol = symbol;
            m_pos = new Point(x, y);
        }

        /// <summary>
        /// Checks if the player has collided with the monster
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Boolean hasCollided(Character c)
        {
            return ((m_pos.X == c.m_pos.X) && (m_pos.Y == c.m_pos.Y));
        }

        /// <summary>
        /// Checks if the player has collided with an item
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Boolean hasCollided(Item c)
        {
            return ((m_pos.X == c.Pos.X) && (m_pos.Y == c.Pos.Y));
        }
        /// <summary>
        /// Move character in direction given - note no checking of valid new posistion
        /// </summary>
        /// <param name="dir"></param>
        public void move(DIR dir)
        {
            m_pos = getNewPosition(dir);
        }
        
        /// <summary>
        /// Get the position if character moves in given direction
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public Point getNewPosition(DIR dir)
        {
            Point pos = m_pos;
            switch (dir)
            {
                case DIR.UP:
                    pos.Y--;
                    break;
                case DIR.DOWN:
                    pos.Y++;
                    break;
                case DIR.LEFT:
                    pos.X--;
                    break;
                case DIR.RIGHT:
                    pos.X++;
                    break;
            }
            return pos;
        }
    }

    /// <summary>
    /// Player Class. Inherits Character
    /// </summary>
    public class Player : Character
    {
        private Armour m_armour;
        private Weapon m_weapon;

        //Get sets for equipment for the player
        public Weapon Weapon { get { return m_weapon; } set { m_weapon = value; m_attack = m_weapon.damage; } }
        public Armour Armor { get { return m_armour; } set { m_armour = value; m_defence = m_armour.AC; } }

        //Constructor of Player
        public Player(char symbol, int x, int y, Weapon weapon, Armour armour) : base(symbol, x, y, 100, armour.AC, weapon.damage)
        {
            m_armour = armour;
            m_weapon = weapon;
        }

    }

    /// <summary>
    /// Monster Class. Inherits Character
    /// </summary>
    public class Monster : Character
    {
        //Constructor for Monster required to set location
        public Monster(char symbol, int x, int y) : base(symbol, x, y, 100, 1, 1)
        {
            
        }
    }
}
