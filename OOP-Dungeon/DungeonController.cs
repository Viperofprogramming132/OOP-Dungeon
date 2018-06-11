using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Dungeon.DungeonModel;
using System.Drawing;
using OOP_Dungeon.Resources;

///
/// Author: Nigel Edwards
/// Date: Jan 2015
/// 
namespace OOP_Dungeon.DungeonController
{
    /// <summary>
    /// Simple default controller for turn based game - abstract class
    /// </summary>
    public abstract class DungeonController
    {
        protected Boolean m_isFinished;
        public Boolean IsFinished { get { return m_isFinished; } }

        protected Dungeon m_dungeon;

        public DungeonController(Dungeon d)
        {
            m_isFinished = false;
            m_dungeon = d;
        }

        public abstract void takeTurn();
    }

    /// <summary>
    /// Concrete controller for a console application
    /// </summary>
    public class ConsoleDungeonController:DungeonController
    {
        public ConsoleDungeonController(Dungeon d) : base(d) { }

        /// <summary>
        /// Turn takes a vlaid key input and move charater accordingly
        /// </summary>
        public override void takeTurn()
        {
            ConsoleKey key = getValidKey();
            Character.DIR dir = Character.DIR.NONE;
            switch (key)
            {
                case (ConsoleKey.RightArrow):
                    dir = Character.DIR.RIGHT;
                    break;
                case (ConsoleKey.LeftArrow):
                    dir = Character.DIR.LEFT;
                    break;
                case (ConsoleKey.UpArrow):
                    dir = Character.DIR.UP;
                    break;
                case (ConsoleKey.DownArrow):
                    dir = Character.DIR.DOWN;
                    break;
                case (ConsoleKey.Q):
                    m_isFinished = true;
                    break;
            }

            if (!m_isFinished)
            {
                // Check the player can move if so move player.
                Point pos = m_dungeon.Player.getNewPosition(dir);
                if (m_dungeon.Map.isValidMove(pos.X, pos.Y))
                    m_dungeon.Player.move(dir);
            }

            //checks if the monster is still alive
            if (m_dungeon.Monster != null)
            {
                
                if (m_dungeon.Player.hasCollided(m_dungeon.Monster))
                {
                    //all the combat
                    sbyte playerHealth = m_dungeon.Player.health;
                    sbyte monsterHealth = m_dungeon.Monster.health;

                    byte playerAttack = m_dungeon.Player.attack;
                    byte monsterAttack = m_dungeon.Monster.attack;

                    byte playerDef = m_dungeon.Player.defence;
                    byte monsterDef = m_dungeon.Monster.defence;

                    sbyte totalDamage = (sbyte)(playerAttack - monsterDef);
                    if (totalDamage > 0)
                    {
                        monsterHealth = (sbyte)(monsterHealth - totalDamage);
                    }

                    totalDamage = (sbyte)(monsterAttack - playerDef);
                    if (totalDamage > 0)
                    {
                        monsterHealth = (sbyte)(playerHealth - totalDamage);
                    }

                    m_dungeon.Monster.health = monsterHealth;
                    m_dungeon.Player.health = playerHealth;
                    if (m_dungeon.Monster.health <= 0)
                    {
                        m_dungeon.Monster = null;
                    }

                }
            }

            //when the player collids with a item (Armour)
            if (m_dungeon.Player.hasCollided(m_dungeon.Items.Armours.ElementAt(m_dungeon.Items.aNum)))
            {
                m_dungeon.Player.Armor = m_dungeon.Items.Armours.ElementAt(m_dungeon.Items.aNum);
            }
            //when the player collids with a item (Weapon)
            if (m_dungeon.Player.hasCollided(m_dungeon.Items.Weapons.ElementAt(m_dungeon.Items.wNum)))
            {
                m_dungeon.Player.Weapon = m_dungeon.Items.Weapons.ElementAt(m_dungeon.Items.wNum);
            }
        }

        /// <summary>
        /// Limits input to four arrow keys and Q for quit.
        /// </summary>
        /// <returns></returns>
        private ConsoleKey getValidKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;

            } while ((key != ConsoleKey.Q) &&
                     (key != ConsoleKey.RightArrow) &&
                     (key != ConsoleKey.LeftArrow) &&
                     (key != ConsoleKey.UpArrow) &&
                     (key != ConsoleKey.DownArrow));
            return key;
        }
    }
}
