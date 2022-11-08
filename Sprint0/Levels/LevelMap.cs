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
        private TextFieldParser Parser;
        public string MapFile { get; }
        public int[,] MapArray { get; set; }
        private readonly int MapSize = 9;
        public int MaxNumRooms { get; }
        private string RootPath;
        //Constructor
        public LevelMap(string levelName)
        {
            RootPath = "../../../Levels/";  // TODO: There is probably a better way to do this than with relative paths...
            MapFile = RootPath + levelName + "/" + "Map.csv";
            MapArray = new int[MapSize, MapSize];
            MaxNumRooms = MapSize * MapSize;
            LoadMap();  // Load the map to an array on construction.
        }
        
        /// <summary>
        /// Turns the Map.csv file into an easy to use 2D array.
        /// </summary>
        public void LoadMap()
        {
            Parser = new TextFieldParser(MapFile);
            Parser.SetDelimiters(",");
            var row = 0;
            while (!Parser.EndOfData)
            {
                var col = 0;
                string[] fields = Parser.ReadFields();

                foreach (string field in fields)
                {
                    
                    if (char.IsDigit(field[0]) || field[0] == '-')
                    {
                        MapArray[row, col] = Int32.Parse(field);
                    }
                    else
                    {
                        MapArray[row, col] = MaxNumRooms + 1;
                    }
                    col++;
                }
                row++;
            }
        }
    }
}
