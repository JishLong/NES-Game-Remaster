using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.IO;
using Sprint0.Levels.Utils;
using Sprint0.Doors;

namespace Sprint0.Levels
{
    /// <summary>
    /// The loader's job is to parse and load game entities from the level's csv files (which are really owned by individual rooms).
    /// Loading involves using the corresponding entity type's factory to create a new instance of that entity and then adding those
    /// entities to the corresponding Room object's collections.
    /// </summary>
    public class LevelLoader
    {
        private LevelManager LevelManager;
        private LevelResources LevelResources;
        private RoomLinker RoomLinker;
        private string RootPath;
        private TextFieldParser Parser;
        private int BorderOffset;

        public LevelLoader(LevelManager manager)
        {
            LevelManager = manager;
            LevelResources = LevelResources.GetInstance();
            RoomLinker = new RoomLinker();
            BorderOffset = 0;
            RootPath = "../../../Levels/";  // TODO: There is probably a better way to do this than with relative paths...
        }
        public Level LoadLevelFromDir(Types.Level levelType)
        {
            // Create new level.
            Level level = LevelFactory.GetInstance().GetLevel(levelType);
            string levelDirName = level.LevelName;

            // Get level directory and list of room files.
            DirectoryInfo dir = new DirectoryInfo(RootPath + levelDirName);
            DirectoryInfo[] RoomDirs = dir.GetDirectories();

            // Load each room for this level.
            foreach (DirectoryInfo dirInfo in RoomDirs)
            {
                string roomDirName = dirInfo.Name;
                level.AddRoom(LoadRoomFromDir(level, levelDirName, roomDirName));
            }

            // Link rooms together using map.
            RoomLinker.LinkRooms(level);

            return level;
        }
        public Room LoadRoomFromDir(Level level, string levelDirName, string roomDirName)
        {
            Room room = new Room(level, roomDirName);
            // Load blocks, characters and items.
            LoadBlocks(room, RootPath + levelDirName + "/" + roomDirName + "/Blocks.csv");
            LoadCharacters(room, RootPath + levelDirName + "/" + roomDirName + "/Characters.csv");
            LoadItems(room, RootPath + levelDirName + "/" + roomDirName + "/Items.csv");
            LoadDoors(room, RootPath + levelDirName + "/" + roomDirName + "/Doors.csv");
            LoadBorder(room, RootPath + levelDirName + "/" + roomDirName + "/Border.csv");
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
                    if (LevelResources.BlockMap.ContainsKey(field))
                    {
                        Types.Block block = LevelResources.BlockMap[field];
                        int x = LevelResources.BlockWidth * col;
                        int y = LevelResources.BlockHeight * row;
                        Vector2 position = new Vector2(x + BorderOffset, y + BorderOffset);
                        room.AddBlockToRoom(block, position);
                    }
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
                    if (LevelResources.CharacterMap.ContainsKey(field))
                    {
                        Types.Character character = LevelResources.CharacterMap[field];
                        int x = LevelResources.BlockWidth * col;
                        int y = LevelResources.BlockHeight * row;
                        Vector2 position = new Vector2(x + BorderOffset, y + BorderOffset);
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
                    if (LevelResources.ItemMap.ContainsKey(field))
                    {
                        Types.Item item = LevelResources.ItemMap[field];
                        int x = LevelResources.BlockWidth * col;
                        int y = LevelResources.BlockHeight * row;
                        Vector2 position = new Vector2(x+BorderOffset, y+BorderOffset);
                        room.AddItemToRoom(item, position);
                    }
                    col++;
                }
                row++;
            }
        }
        public void LoadDoors(Room room, string roomName)
        { 
            Parser = new TextFieldParser(roomName);
            Parser.SetDelimiters(",");
            while (!Parser.EndOfData)
            {
                string[] fields = Parser.ReadFields();
                foreach (string field in fields)
                {
                    if (LevelResources.DoorMap.ContainsKey(field))
                    {
                        Types.Door doorType = LevelResources.DoorMap[field];
                        IDoor door = new Door(room, doorType);
                        room.AddDoorToRoom(door);
                    }
                }
            }
        }
        public void LoadBorder(Room room, string roomName)
        {
            Parser = new TextFieldParser(roomName);
            Parser.SetDelimiters(",");
            while (!Parser.EndOfData)
            {
                string[] fields = Parser.ReadFields();
                foreach (string field in fields)
                {   // There should really only be one value in this file.
                    if (LevelResources.BorderMap.ContainsKey(field))
                    {
                        Types.Border borderType = LevelResources.BorderMap[field];
                        room.SetBorder(borderType);
                    }
                }
            }
        }
    }
}
