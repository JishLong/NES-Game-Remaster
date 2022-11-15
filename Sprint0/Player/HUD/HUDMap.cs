using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors.UnlockdDoorSprites;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Player.HUD
{
    public class HUDMap
    {
        private LevelManager LevelManager;
        private Player Player;

        private (int, int) PlayerCoords;    // Which room to draw the player in
        private (int, int) BossRoomCoords;  // Which room to draw the boss in

        private Dictionary<ISprite, Vector2> RoomSprites; // Maps sprites to positions where they should be drawn.

        public int[,] MapArray { get; set; }
        private int MapSize;

        public HUDMap(LevelManager levelManager, Player player)
        {
            LevelManager = levelManager;
            RoomSprites = new Dictionary<ISprite, Vector2>();
            MapArray = levelManager.CurrentLevel.Map.MapArray;
            MapSize = levelManager.CurrentLevel.Map.MapSize;
            Player = player;

            CreateMap();
        }

        private void CreateMap()
        {
            int width = 7 * (int) GameScale;
            int height = 3 * (int) GameScale;
            int buffer = 1 * (int) GameScale;
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (MapArray[i,j] > 0)
                    {
                        Vector2 Position = new Vector2(j * width + buffer, i * height + buffer);
                        RoomSprites.Add(new HUDMapRoomSprite(), Position);
                        // Add a new block at this position 
                    }
                }
            }
        }

        public void Update()
        {

        }

        public void DrawPlayerLocation(SpriteBatch sb, Rectangle sourceRect)
        {

        }

        public void DrawBossLocation(SpriteBatch sb, Rectangle sourceRect)
        {

        }
        public void DrawMap(SpriteBatch sb, Rectangle sourceRect)
        {
            foreach (KeyValuePair<ISprite, Vector2> pair in RoomSprites)
            {
                ISprite sprite = pair.Key;
                Vector2 position = pair.Value;
                position = position + new Vector2(sourceRect.X + 20, sourceRect.Y + 20);
                sprite.Draw(sb, position, Color.Blue, HUDLayerDepth);
            }
        }
    }
}
