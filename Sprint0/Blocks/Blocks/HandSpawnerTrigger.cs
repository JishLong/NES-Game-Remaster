using Microsoft.Xna.Framework;
using Sprint0.Levels;
using Sprint0.Sprites.Blocks;
using System;
using static Sprint0.Types;

namespace Sprint0.Blocks.Blocks
{
    /* NOTE: this block is used to trigger a potential hand enemy spawn;
     * The implementation of this trigger can be explored in the collision handling system
     */
    public class HandSpawnerTrigger : AbstractBlock
    {
        private static readonly Random RNG = new();
        private static readonly float SpawnChance = 0.01f;

        public HandSpawnerTrigger(Vector2 position) : base(new BlueTileSprite(), position, false) { }

        public void SpawnHand(Room room) 
        {
            float BlockUnits = 16 * Sprint0.Utils.GameScale;
            Vector2 Offset = Camera.GetInstance().Position;

            if (RNG.NextDouble() < SpawnChance) 
            {
                if (Position.X < 3 * BlockUnits + Offset.X && Position.Y < 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position - new Vector2(2 * BlockUnits, 0), Direction.RIGHT, false);
                else if (Position.X < 3 * BlockUnits + Offset.X && Position.Y > 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position - new Vector2(2 * BlockUnits, 0), Direction.RIGHT, true);
                else if (Position.X < 7 * BlockUnits + Offset.X && Position.Y < 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position - new Vector2(0, 2 * BlockUnits), Direction.DOWN, true);
                else if (Position.X < 7 * BlockUnits + Offset.X && Position.Y > 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position + new Vector2(0, 2 * BlockUnits), Direction.UP, false);
                else if (Position.X < 13 * BlockUnits + Offset.X && Position.Y < 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position - new Vector2(0, 2 * BlockUnits), Direction.DOWN, false);
                else if (Position.X < 13 * BlockUnits + Offset.X && Position.Y > 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position + new Vector2(0, 2 * BlockUnits), Direction.UP, true);
                else if (Position.X < 15 * BlockUnits + Offset.X && Position.Y < 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position + new Vector2(2 * BlockUnits, 0), Direction.LEFT, true);
                else if (Position.X < 15 * BlockUnits + Offset.X && Position.Y > 4 * BlockUnits + Offset.Y)
                    room.AddCharacterToRoom(Character.HAND, Position + new Vector2(2 * BlockUnits, 0), Direction.LEFT, false);
            }
        }
    }
}
