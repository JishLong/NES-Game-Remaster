﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Levels;
using Sprint0.Sprites;
using Sprint0.Sprites.Doors.UnlockdDoorSprites;
using System;
using System.Collections.Generic;
using static Sprint0.Utils;

namespace Sprint0.Player.HUD
{
    public class InventoryMap
    {
        private LevelManager LevelManager;
        private IPlayer Player;
        private ISprite PlayerLocationSprite;

        private int BossRoomID;
        private int CurrentRoomID;

        private Dictionary<ISprite, Vector2> RoomSprites; // Maps sprites to positions where they should be drawn.
        private Dictionary<int, Vector2> PlayerPositions; // Pairs room ids with positions in which to draw the player.

        public int[,] MapArray { get; set; }
        private int MapSize;

        public InventoryMap(LevelManager levelManager, IPlayer player)
        {
            LevelManager = levelManager;
            RoomSprites = new Dictionary<ISprite, Vector2>();
            PlayerPositions = new Dictionary<int, Vector2>();
            MapArray = levelManager.CurrentLevel.Map.MapArray;
            MapSize = levelManager.CurrentLevel.Map.MapSize;
            CurrentRoomID = levelManager.CurrentLevel.CurrentRoom.RoomID;   // Set this on initialization
            PlayerLocationSprite = new PlayerLocationSprite();
            Player = player;

            CreateMap();
        }

        private void CreateMap()
        {
            int roomWidth = 8 * (int)GameScale;
            int roomHeight = 8 * (int)GameScale;
            int roomBuffer = 0 * (int)GameScale;
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (MapArray[i, j] > 0 && LevelManager.CurrentLevel.VisitedRooms.Contains(MapArray[i,j]))
                    {
                        Vector2 RoomPosition = new Vector2(j * roomWidth + j * roomBuffer, i * roomHeight + i * roomBuffer);

                        Room room = null;
                        foreach (var r in LevelManager.CurrentLevel.Rooms) 
                        {
                            if (r.RoomID == MapArray[i, j]) room = r;
                        }

                        ISprite IconSprite = new IconNoDoorsSprite();

                        bool RoomLeft = room.GetAdjacentRoom(Types.RoomTransition.LEFT) != null;
                        bool RoomRight = room.GetAdjacentRoom(Types.RoomTransition.RIGHT) != null;
                        bool RoomUp = room.GetAdjacentRoom(Types.RoomTransition.UP) != null;
                        bool RoomDown = room.GetAdjacentRoom(Types.RoomTransition.DOWN) != null;

                        if (!RoomLeft && !RoomRight && !RoomUp && !RoomDown) IconSprite = new IconNoDoorsSprite();
                        else if (RoomLeft && RoomRight && RoomUp && RoomDown) IconSprite = new IconAllDoorsSprite();
                        else if (RoomLeft && RoomRight && !RoomUp && !RoomDown) IconSprite = new IconHorzDoorsSprite();
                        else if (!RoomLeft && !RoomRight && RoomUp && RoomDown) IconSprite = new IconVertDoorsSprite();

                        else if (RoomLeft && !RoomRight && !RoomUp && !RoomDown) IconSprite = new IconLeftDoorSprite();
                        else if (!RoomLeft && RoomRight && !RoomUp && !RoomDown) IconSprite = new IconRightDoorSprite();
                        else if (!RoomLeft && !RoomRight && RoomUp && !RoomDown) IconSprite = new IconUpDoorSprite();
                        else if (!RoomLeft && !RoomRight && !RoomUp && RoomDown) IconSprite = new IconDownDoorSprite();

                        else if (RoomLeft && !RoomRight && RoomUp && !RoomDown) IconSprite = new IconUpLeftDoorsSprite();
                        else if (!RoomLeft && RoomRight && RoomUp && !RoomDown) IconSprite = new IconUpRightDoorsSprite();
                        else if (RoomLeft && !RoomRight && !RoomUp && RoomDown) IconSprite = new IconDownLeftDoorsSprite();
                        else if (!RoomLeft && RoomRight && !RoomUp && RoomDown) IconSprite = new IconDownRightDoorsSprite();

                        else if (RoomLeft && RoomRight && RoomUp && !RoomDown) IconSprite = new IconNoDownDoorSprite();
                        else if (RoomLeft && RoomRight && !RoomUp && RoomDown) IconSprite = new IconNoUpDoorSprite();
                        else if (RoomLeft && !RoomRight && RoomUp && RoomDown) IconSprite = new IconNoRightDoorSprite();
                        else if (!RoomLeft && RoomRight && RoomUp && RoomDown) IconSprite = new IconNoLeftDoorSprite();


                        RoomSprites.Add(IconSprite, RoomPosition);
                        // Add a new block at this position 
                        Vector2 PlayerPosition = new Vector2(j * roomWidth + j * roomBuffer + 8, i * roomHeight + i * roomBuffer + 8);
                        PlayerPositions.Add(MapArray[i, j], PlayerPosition);
                    }
                }
            }
        }

        public void Update()
        {
            // Get this every tick.
            CurrentRoomID = LevelManager.CurrentLevel.CurrentRoom.RoomID;
            CreateMap();
        }

        public void DrawPlayerLocation(SpriteBatch sb, Rectangle sourceRect)
        {
            if (PlayerPositions.ContainsKey(CurrentRoomID))
            {
                Vector2 position = PlayerPositions[CurrentRoomID];
                position = position + new Vector2(sourceRect.X, sourceRect.Y);
                PlayerLocationSprite.Draw(sb, position, Color.Green, 0.13f);
            }
        }

        public void DrawMap(SpriteBatch sb, Rectangle sourceRect)
        {
            foreach (KeyValuePair<ISprite, Vector2> pair in RoomSprites)
            {
                ISprite sprite = pair.Key;
                Vector2 position = pair.Value;
                position = position + new Vector2(sourceRect.X, sourceRect.Y);
                sprite.Draw(sb, position, Color.White, 0.15f);
            }
        }
    }
}