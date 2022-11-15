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
        private ISprite PlayerLocationSprite;
        private ISprite BossLocationSprite;

        private int HUDOffsetX = 50;
        private int HUDOffsetY = 60;
        private int BossRoomID;
        private int CurrentRoomID;

        private Dictionary<ISprite, Vector2> RoomSprites; // Maps sprites to positions where they should be drawn.
        private Dictionary<int, Vector2> PlayerPositions; // Pairs room ids with positions in which to draw the player.
        private Vector2 BossPosition;   // Position to draw the boss room.

        public int[,] MapArray { get; set; }
        private int MapSize;

        public HUDMap(LevelManager levelManager, Player player)
        {
            LevelManager = levelManager;
            RoomSprites = new Dictionary<ISprite, Vector2>();
            PlayerPositions = new Dictionary<int, Vector2>();
            MapArray = levelManager.CurrentLevel.Map.MapArray;
            MapSize = levelManager.CurrentLevel.Map.MapSize;
            CurrentRoomID = levelManager.CurrentLevel.CurrentRoom.RoomID;   // Set this on initialization
            BossRoomID = levelManager.CurrentLevel.BossRoomIndex;
            PlayerLocationSprite = new PlayerLocationSprite();
            BossLocationSprite = new BossLocationSprite();
            Player = player;

            CreateMap();
        }

        private void CreateMap()
        {
            int roomWidth = 7 * (int) GameScale;
            int roomHeight = 3 * (int) GameScale;
            int roomBuffer = 1 * (int) GameScale;
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (MapArray[i,j] > 0)
                    {
                        Vector2 RoomPosition = new Vector2(j * roomWidth + j * roomBuffer, i * roomHeight + i * roomBuffer);
                        RoomSprites.Add(new HUDMapRoomSprite(), RoomPosition);
                        // Add a new block at this position 
                        Vector2 PlayerPosition = new Vector2(j * roomWidth + j * roomBuffer + 6, i * roomHeight + i * roomBuffer);
                        PlayerPositions.Add(MapArray[i, j], PlayerPosition);

                        if (MapArray[i, j] == BossRoomID)
                        {
                            BossPosition = new Vector2(j * roomWidth + j * roomBuffer + 6, i * roomHeight + i * roomBuffer);
                        }
                    }
                }
            }
        }

        public void Update()
        {
            // Get this every tick.
            CurrentRoomID = LevelManager.CurrentLevel.CurrentRoom.RoomID;
            BossLocationSprite.Update();
        }

        public void DrawPlayerLocation(SpriteBatch sb, Rectangle sourceRect)
        {

            if (PlayerPositions.ContainsKey(CurrentRoomID))
            {
                Vector2 position = PlayerPositions[CurrentRoomID];
                position = position + new Vector2(sourceRect.X + HUDOffsetX, sourceRect.Y + HUDOffsetY);
                PlayerLocationSprite.Draw(sb, position, Color.Green, HUDLayerDepth);
            }
        }

        public void DrawBossLocation(SpriteBatch sb, Rectangle sourceRect)
        {
            Vector2 position = BossPosition;
            position = position + new Vector2(sourceRect.X + HUDOffsetX, sourceRect.Y + HUDOffsetY);
            BossLocationSprite.Draw(sb, position, Color.Red, HUDLayerDepth + 0.05f);
        }
        public void DrawMap(SpriteBatch sb, Rectangle sourceRect)
        {
            foreach (KeyValuePair<ISprite, Vector2> pair in RoomSprites)
            {
                ISprite sprite = pair.Key;
                Vector2 position = pair.Value;
                position = position + new Vector2(sourceRect.X + HUDOffsetX, sourceRect.Y + HUDOffsetY);
                sprite.Draw(sb, position, Color.Blue, HUDLayerDepth+0.1f);
            }
        }
    }
}
