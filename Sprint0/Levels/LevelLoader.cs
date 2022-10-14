using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Sprint0.Levels.Utils;
using System.Collections.Generic;
using System;
using System.IO;


namespace Sprint0.Levels
{
    // Abandon all hope, ye who enter here.

    /// <summary>
    /// The loader's job is to parse and load game entities from the level's csv files (which are really owned by individual rooms).
    /// Loading involves using the corresponding entity type's factory to create a new instance of that entity and then adding those
    /// entities to the corresponding Room object's collections.
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
            RootPath = "../../../Levels/";  // TODO: There is probably a better way to do this than with relative paths...
        }
        public Level LoadLevelFromDir(string levelDirName)
        {
            // Get level directory and list of room files.
            DirectoryInfo dir = new DirectoryInfo(RootPath + levelDirName);
            DirectoryInfo[] RoomDirs = dir.GetDirectories();
                
            // Create new level.
            Level level = new Level(levelDirName);

            // For each room, load their entities and add the room to the level.
            for (int row = 0; row < level.Map.MapArray.Length; row++)
            {
                for (int col = 0; col < level.Map.MapArray.Length; col ++)
                {
                    
                }
            }

            foreach (DirectoryInfo dirInfo in RoomDirs)
            {
                string roomDirName = dirInfo.Name;
                level.AddRoom(LoadRoomFromDir(level, levelDirName, roomDirName));
            }

            return level;
        }
        public Room LoadRoomFromDir(Level level, string levelDirName, string roomDirName)
        {
            Room room = new Room(level);
            // Load blocks, characters and items.
            LoadBlocks(room, RootPath + levelDirName + "/" + roomDirName + "/Blocks.csv");
            LoadCharacters(room, RootPath + levelDirName + "/" + roomDirName + "/Characters.csv");
            LoadBlocks(room, RootPath + levelDirName + "/" + roomDirName + "/Blocks.csv");
            return room;
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
                        room.AddCharacterToRoom(character, position);
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
                        Types.Item item = LevelResources.ItemMap[field];
                        int x = LevelResources.BlockWidth * col;
                        int y = LevelResources.BlockHeight * row;
                        Vector2 position = new Vector2(x, y);
                        room.AddItemToRoom(item, position);
                    }
                    col++;
                }
                row++;
            }
        }
    }
}
