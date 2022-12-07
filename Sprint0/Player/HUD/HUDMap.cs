using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;
using Sprint0.Sprites;
using Sprint0.Sprites.Gui;
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

        private Vector2 HUDOffset = new Vector2(16, 20) * GameWindow.ResolutionScale;
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
            int roomWidth = (int)(7 * GameWindow.ResolutionScale);
            int roomHeight = (int)(3 * GameWindow.ResolutionScale);
            int roomBuffer = (int)(1 * GameWindow.ResolutionScale);
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

        public void DrawPlayerLocation(SpriteBatch sb)
        {

            if (PlayerPositions.ContainsKey(CurrentRoomID))
            {
                Vector2 position = PlayerPositions[CurrentRoomID];
                position = position + HUDOffset;
                PlayerLocationSprite.Draw(sb, Utils.LinkToCamera(position), Color.Green, HUDLayerDepth + 0.1f);
            }
        }

        public void DrawBossLocation(SpriteBatch sb)
        {
            Vector2 position = BossPosition;
            position = position + HUDOffset;
            BossLocationSprite.Draw(sb, Utils.LinkToCamera(position), Color.Red, HUDLayerDepth + 0.11f);
        }
        public void DrawMap(SpriteBatch sb)
        {
            foreach (KeyValuePair<ISprite, Vector2> pair in RoomSprites)
            {
                ISprite sprite = pair.Key;
                Vector2 position = pair.Value;
                position = position + HUDOffset;
                sprite.Draw(sb, Utils.LinkToCamera(position), Color.Blue, HUDLayerDepth+0.12f);
            }
        }
    }
}
