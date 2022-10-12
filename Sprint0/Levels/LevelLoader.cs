using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Sprint0.Levels.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Levels
{
    // Many things have been ommented out for now to fix errors caused by things that aren't implemented yet

    /// <summary>
    /// The loader's job is to parse and load game entities from the level csv files.
    /// (Loading involves using the corresponding entity types factory to create a new instance of that entity.)
    /// These entities are then added to the owning object's collections (the level manager.)
    /// </summary>
    public class LevelLoader
    {
        private LevelManager LevelManager;
        private LevelResources LevelResources;
        private string RootPath;
        private TextFieldParser Parser;

        public LevelLoader(LevelManager manager)
        {
            LevelManager = manager;
            LevelResources = LevelResources.GetInstance();
            RootPath = "../../../Levels/";
        }
        public Level LoadLevelFromFile(string levelName)
        {
            // Get level directory and list of room files.
            DirectoryInfo dir = new DirectoryInfo(RootPath + levelName);
            DirectoryInfo[] RoomDirs = dir.GetDirectories();

            // List of rooms to add to the level.
            List<Room> rooms = new List<Room>();
            Level level = new Level();

            // For each room file, load their corresponding items.
            foreach (DirectoryInfo dirInfo in RoomDirs)
            {
                Room room = new Room();
                string roomName = dirInfo.Name;

                // Load blocks, characters and items.
                LoadBlocks(room, RootPath + roomName + "/Blocks.csv");
                LoadCharacters(room, RootPath + roomName + "/Characters.csv");
                LoadBlocks(room, RootPath + roomName + "/Blocks.csv");

                level.AddRoom(room);
            }

            return level;
        }
        public void LoadBlocks(Room room, string roomName)
        {
            Parser = new TextFieldParser(roomName);
            Parser.SetDelimiters(",");
            var row = 0;
            while (!Parser.EndOfData)
            {
                var col = 0;
                string[] fields = Parser.ReadFields();
                foreach (string field in fields)
                {
                    //TODO: Add some protection here. Fields may have been typed incorrectly.
                    Types.Block block = LevelResources.BlockMap[field];
                    int x = LevelResources.BlockWidth * col;
                    int y = LevelResources.BlockHeight * row;
                    Vector2 position = new Vector2(x, y);
                    room.AddBlockToRoom(block, position);
                    col++;
                }
                row++;
            }
        }

        public void LoadCharacters(Room room, string roomName)
        {
            Parser = new TextFieldParser(roomName);
            Parser.SetDelimiters(",");
            var row = 0;
            while (!Parser.EndOfData)
            {
                var col = 0;
                string[] fields = Parser.ReadFields();
                foreach (string field in fields)
                {
                    if(LevelResources.CharacterMap.ContainsKey(field))
                    {
                        Types.Character character = LevelResources.CharacterMap[field];
                        int x = LevelResources.BlockWidth * col;
                        int y = LevelResources.BlockHeight * row;
                        Vector2 position = new Vector2(x, y);
                        //LevelManager.AddCharacter(character, position);
                    }
                    col++;
                }
                row++;
            }

        }
        public void LoadItems(Room room, string roomName)
        {
            Parser = new TextFieldParser(roomName);
            Parser.SetDelimiters(",");
            var row = 0;
            while (!Parser.EndOfData)
            {
                var col = 0;
                string[] fields = Parser.ReadFields();
                foreach (string field in fields)
                {
                    if(LevelResources.CharacterMap.ContainsKey(field))
                    {
                        Types.Character character = LevelResources.CharacterMap[field];
                        int x = LevelResources.BlockWidth * col;
                        int y = LevelResources.BlockHeight * row;
                        Vector2 position = new Vector2(x, y);
                        //LevelManager.AddCharacter(character, position);
                    }
                    col++;
                }
                row++;
            }

        }
    }
}
