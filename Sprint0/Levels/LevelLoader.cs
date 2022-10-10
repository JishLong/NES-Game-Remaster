using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Sprint0.Levels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Levels
{
    /// <summary>
    /// The loader's job is to parse and load game entities from the level csv files.
    /// (Loading involves using the corresponding entity types factory to create a new instance of that entity.)
    /// These entities are then added to the owning object's collections (the level manager.)
    /// </summary>
    public class LevelLoader
    {
        private LevelManager LevelManager;
        private LevelResources LevelResources;
        private TextFieldParser Parser;

        public LevelLoader(LevelManager manager, string level)
        {
            LevelManager = manager;
            LevelResources = LevelResources.GetInstance();
            // TODO: use the 'level' param instead of hard coded paths.
            LoadBlocks("../../../Levels/Level1/Room1_Blocks.csv");
            LoadCharacters("../../../Levels/Level1/Room1_Characters.csv");
        }
        public void LoadBlocks(string levelName)
        {
            Parser = new TextFieldParser(levelName);
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
                    LevelManager.AddBlock(block, position);
                    col++;
                }
                row++;
            }
        }

        public void LoadCharacters(string levelName)
        {
            Parser = new TextFieldParser(levelName);
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
                        LevelManager.AddCharacter(character, position);
                    }
                    col++;
                }
                row++;
            }

        }
    }
}
