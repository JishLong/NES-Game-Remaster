using Sprint0.Blocks;
using Sprint0.Characters;
using Microsoft.Xna.Framework;
using Sprint0.Npcs;
using Sprint0.Characters.Enemies;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between characters and blocks
    public class CharacterBlockCollisionHandler
    {
        public void HandleCollision(ICharacter character, IBlock block, Types.Direction characterSide) 
        {
            if (block.IsWall && character is not OldMan && character is not Flame && character is not Hand)
            {
                Rectangle PHitbox = character.GetHitbox();
                Rectangle BHitbox = block.GetHitbox();

                switch (characterSide)
                {
                    case (Types.Direction.DOWN):
                        character.Position = new Vector2(PHitbox.X, BHitbox.Y - PHitbox.Height);
                        break;
                    case (Types.Direction.UP):
                        character.Position = new Vector2(PHitbox.X, BHitbox.Y + BHitbox.Height);
                        break;
                    case (Types.Direction.RIGHT):
                        character.Position = new Vector2(BHitbox.X - PHitbox.Width, PHitbox.Y);
                        break;
                    case (Types.Direction.LEFT):
                        character.Position = new Vector2(BHitbox.X + BHitbox.Width, PHitbox.Y);
                        break;
                }
            }
        }
    }
}
