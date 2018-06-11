using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using OOP_Dungeon.DungeonView;

///
/// Author: Nigel Edwards
/// Date: Jan 2015
/// 
namespace OOP_Dungeon.DungeonModel
{
    public class DungeonMap
    {
        // Memebers
        private List<String> m_map;
        private Boolean m_loaded;
        private int m_hieght, m_width;
        
        // Definitions of tile types
        public const char INVALID = '?';
        public const char WALL = '#';

        // Accessors 
        public int Height { get { return m_hieght; } }
        public int Width { get { return m_width; } }

        /// <summary>
        /// Constructor for Dungeon Map
        /// </summary>
        public DungeonMap()
        {
            m_map = new List<string>();
            m_loaded = false;
            m_hieght = 0;
            m_width = 0;
        }

        /// <summary>
        /// Load dungeon map from text file
        /// This method could throw so should be used in a try catch block
        ///     ArgumentException           - path is an empty string (""). 
        ///     ArgumentNullException       - path is null. 
        ///     FileNotFoundException       - The file cannot be found. 
        ///     DirectoryNotFoundException  - The specified path is invalid, such as being on an unmapped drive. 
        ///     IOException                 - path includes an incorrect or invalid syntax for file name, directory name, or volume label. 
        ///     OutOfMemoryException        - There is insufficient memory to allocate a buffer for the returned string. 
        /// </summary>
        /// <param name="filename"></param>
        public void load(String path)
        {
            m_loaded = false;
            m_hieght = 0;
            m_width = 0;
            using (StreamReader streamReader = new StreamReader(path))
            {
                string data = streamReader.ReadToEnd();

                char[] delimiters = new char[] { '\r', '\n' };
                string[] lines = data.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    m_map.Add(line);
                    m_hieght++;

                    if (m_width < line.Length)
                        m_width = line.Length;
                }
            }
            m_loaded = true;
        }

        /// <summary>
        /// returns the tile at the location given
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public char getTile(int x, int y)
        {

            if ((x < 0) || (x >= m_width) || (y < 0) || (y >= m_hieght) || !m_loaded)
                return INVALID;

            String line = m_map.ElementAt(y);

            if (x >= line.Length)
                return INVALID;

            return line.ElementAt(x);
        }

        /// <summary>
        /// Checks if the given coords are a valid move (not a wall or invalid)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Boolean isValidMove(int x, int y)
        {
            char c = getTile(x, y);
            return ((c != INVALID) && (c != WALL));
        }
    }
}
