using Sprint0.Levels;
using Sprint0.Blocks;
using Sprint0.Characters;
using Microsoft.Xna.Framework;
using Sprint0.Commands.Blocks;
using Sprint0.Commands.Character;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between characters and blocks
    public class CharacterBlockCollisionHandler
    {
        // NOTE: not working; characters will need interface refactoring in order to extract needed information to handle collision
        public void HandleCollision(ICharacter character, IBlock block, Types.Direction characterSide, Room room) 
        {
            //types of blocks player cannot walk through
            if (block.IsWall())
            {
                //character.changedirection
                Rectangle PHitbox = character.GetHitbox();
                Rectangle BHitbox = block.GetHitbox();
                int X, Y;

                switch (characterSide)
                {
                    case (Types.Direction.DOWN):
                        X = PHitbox.X;
                        Y = BHitbox.Y - PHitbox.Height;
                        new CharacterRelocate(character, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.UP):
                        X = PHitbox.X;
                        Y = BHitbox.Y + BHitbox.Height;
                        new CharacterRelocate(character, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.RIGHT):
                        X = BHitbox.X - PHitbox.Width;
                        Y = PHitbox.Y;
                        new CharacterRelocate(character, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.LEFT):
                        X = BHitbox.X + BHitbox.Width;
                        Y = PHitbox.Y;
                        new CharacterRelocate(character, new Vector2(X, Y)).Execute();
                        break;
                }
            }
        }
    }
}
