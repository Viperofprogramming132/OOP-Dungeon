using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Dungeon.DungeonController;
using OOP_Dungeon.DungeonModel;
using OOP_Dungeon.DungeonView;
using OOP_Dungeon.Resources;

namespace OOP_Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creat a new dugeon and run until we finish
                
                Dungeon d = new Dungeon("testmap.dat", 3, 2, 30, 1);
                
                ConsoleDungeonView cd = new ConsoleDungeonView(d);
                ConsoleDungeonController co = new ConsoleDungeonController(d);       
                do
                {
                    cd.draw();
                    co.takeTurn();
                } while (!co.IsFinished);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
