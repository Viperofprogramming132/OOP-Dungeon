using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Dungeon.DungeonModel;
using OOP_Dungeon.Resources;

///
/// Author: Nigel Edwards
/// Date: Jan 2015
/// 
namespace OOP_Dungeon.DungeonView
{
    /// <summary>
    /// Base View class from which all different views can be created
    /// </summary>
    public abstract class DungeonView
    {
        protected Dungeon m_dungeon;
        
        
        public DungeonView(Dungeon dungeon)
        {
            m_dungeon = dungeon;
        }

        public abstract void draw();
    }

    /// <summary>
    /// View of dungeon using a cmd console
    /// </summary>
    public class ConsoleDungeonView : DungeonView
    {
        /// <summary>
        /// Simple default constructor
        /// </summary>
        /// <param name="d"></param>
        public ConsoleDungeonView(Dungeon d) : base(d) { }

        /// <summary>
        /// Draw Dungeon to the console
        /// </summary>
        public override void draw()
        {
            Console.Clear();
            drawMap();
            //Checks if player has item equipt
            if(m_dungeon.Player.defence == 1)
                drawArmour(m_dungeon.Items.Armours.ElementAt(m_dungeon.Items.aNum));
            //Checks if player has item equipt
            if (m_dungeon.Player.attack == 1)
                drawWeapon(m_dungeon.Items.Weapons.ElementAt(m_dungeon.Items.wNum));
            //checks if the monster still exists
            if (m_dungeon.Monster != null)
                drawMonster();

            //draws Player stats and monster stats to screen
            drawStats();
            drawPlayer();
        }

        /// <summary>
        /// Draw the map to the console
        /// </summary>
        private void drawMap()
        {
            DungeonMap map = m_dungeon.Map;
            // StringBuider used to give some double buffering
            StringBuilder sb = new StringBuilder();

            // loop over the map and draw each charater to the screen
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    char c = map.getTile(x, y);
                    if (c == DungeonMap.INVALID)
                        c = ' ';
                    sb.Append(c);
                }
                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
        }
        
        /// <summary>
        /// Draw player to the screen
        /// </summary>
        private void drawPlayer()
        {
            Character c = m_dungeon.Player;
            int x = c.Pos.X;
            int y = c.Pos.Y;
            Console.SetCursorPosition(x, y);
            Console.Write(c.Symbol);
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Draws the Monster to the screen
        /// </summary>
        private void drawMonster()
        {
            Character m = m_dungeon.Monster;
            int x = m.Pos.X;
            int y = m.Pos.Y;
            Console.SetCursorPosition(x, y);
            Console.Write(m.Symbol);
            //Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Draws Armour to screen
        /// </summary>
        private void drawArmour(Item i)
        {
            Console.SetCursorPosition(i.Pos.X,i.Pos.Y);
            Console.Write('A');
        }
        /// <summary>
        /// Draws Weapons to screen
        /// </summary>
        private void drawWeapon(Item i)
        {
            Console.SetCursorPosition(i.Pos.X, i.Pos.Y);
            Console.Write('W');
        }
        /// <summary>
        /// Draws Stats to the Screen
        /// </summary>
        private void drawStats()
        {
            int x = 0;
            int y = 15;
            Console.SetCursorPosition(x, y);
            if (m_dungeon.Monster != null)
            {
                Console.WriteLine("Monster Health {0}", m_dungeon.Monster.health);
            }
            else
            {
                Console.WriteLine("Monster Is Dead");
            }
            Console.WriteLine("Player Health {0}", m_dungeon.Player.health);
        }
    }
}
