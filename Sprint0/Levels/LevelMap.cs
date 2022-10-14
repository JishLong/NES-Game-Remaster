using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Sprint0.Levels.Utils;
using System.Collections.Generic;
using System;
using System.IO;

namespace Sprint0.Levels
{
    public class LevelMap
    {
        string MapName;
        public int[,] MapArray { get; set; }
        private TextFieldParser Parser;
        private string RootPath;
        //Constructor
        public LevelMap(string levelName)
        {
            RootPath = "../../../Levels/";  // TODO: There is probably a better way to do this than with relative paths...
            MapName = RootPath + levelName + "/" + "Map.csv";
            MapArray = new int[10, 10]; // TODO: Need to make a MAPSIZE constant somewhere.
        }

        /// <summary>
        /// Turns the Map.csv file into an easy to use 2D array.
        /// </summary>
        public void LoadMap()
        {
            Parser = new TextFieldParser(MapName);
            Parser.SetDelimiters(",");
            var row = 0;
            while (!Parser.EndOfData)
            {
                var col = 0;
                string[] fields = Parser.ReadFields();
                
                foreach (string field in fields)
                {
                    if (char.IsDigit(field[0]))
                    {
                        MapArray[row, col] = (int)char.GetNumericValue(field[0]);
                    }
                    else
                    {
                        MapArray[row, col] = -1;
                    }
                    col++;
                }
                row++;
            }
        }
    }
}
