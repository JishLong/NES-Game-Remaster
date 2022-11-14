using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using System.IO;
using Sprint0.Levels.Utils;
using Sprint0.Doors;
using Sprint0.Entities;
using Sprint0.Levels.Events;
using Sprint0.Events;
using System;

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

        public LevelLoader(LevelManager manager)
        {
            LevelManager = manager;
            LevelResources = LevelResources.GetInstance();
            RoomLinker = new RoomLinker();
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
                Room room = LoadRoomFromDir(level, levelDirName, roomDirName);
                level.AddRoom(room);
                level.AddEntity(room);
            }
            // Load event system.
            LoadEntities(level, RootPath + levelDirName + "/Entities.csv");
            LoadEvents(level, RootPath + levelDirName + "/Events.csv");

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
            LoadDoors(level, room, RootPath + levelDirName + "/" + roomDirName + "/Doors.csv");
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
                        Vector2 position = new Vector2(x, y);
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
                    if (LevelResources.ItemMap.ContainsKey(field))
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
        public void LoadDoors(Level level, Room room, string roomDoorFile)
        { 
            Parser = new TextFieldParser(roomDoorFile);
            Parser.SetDelimiters(",");
            while (!Parser.EndOfData)
            {
                string[] fields = Parser.ReadFields();
                foreach (string field in fields)
                {
                    if (LevelResources.DoorMap.ContainsKey(field))
                    {
                        string key = field.Substring(0, field.IndexOf('_'));
                        Types.Door doorType = LevelResources.DoorMap[field];
                        IDoor door = new Door(room, doorType, field);
                        room.AddDoorToRoom(key, door);
                        level.AddEntity(door); // Doors are also inherently entities.
                    }
                }
            }
        }
        public void LoadBorder(Room room, string roomBorderFile)
        {
            Parser = new TextFieldParser(roomBorderFile);
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
        public void LoadEntities(Level level, string levelEntitiesFile)
        {
            Parser = new TextFieldParser(levelEntitiesFile);
            Parser.SetDelimiters(",");
            Parser.ReadLine(); // Consume the first line.
            while (!Parser.EndOfData)
            {
                string[] fields = Parser.ReadFields();
                string category = fields[0];
                string type = fields[1];
                string name = fields[2];
                string roomName = fields[3];
                int xPosition = int.Parse(fields[4]) * LevelResources.BlockWidth + LevelResources.BorderWidth;
                int yPosition = int.Parse(fields[5]) * LevelResources.BlockHeight + LevelResources.BorderWidth;
                Vector2 position = new Vector2(xPosition, yPosition);
                // Factory takes room as an argument because the entity must be added as a specific type to an individual room.
                IEntity entity = EntityFactory.GetInstance().GetEntity(level, roomName, category, type, name, position);
                // Generic entity type is then added to the level's collection.
                foreach (IEntity levelEntity in level.Entities)
                {
                    if (levelEntity.GetName() == entity.GetName())
                    {
                        throw new Exception("Cannot add entity with name " + entity.GetName() + " to level " + level.LevelName + ". An entity with this name already exists!");
                    }
                }
                level.AddEntity(entity);
            }
        }
        public void LoadEvents(Level level, string levelEventsFile)
        {
            Parser = new TextFieldParser(levelEventsFile);
            Parser.SetDelimiters(",");
            Parser.ReadLine();  // Consume the first line.
            while (!Parser.EndOfData)
            {
                string[] fields = Parser.ReadFields();
                Types.Event type = LevelResources.EventMap[fields[0]];
                string catylistEntityName = fields[1];
                string receivingEntityName = fields[2];
                IEvent levelEvent = EventFactory.GetInstance().GetEvent(level, type, catylistEntityName, receivingEntityName);
                level.AddEvent(levelEvent);
            }
        }
    }
}
