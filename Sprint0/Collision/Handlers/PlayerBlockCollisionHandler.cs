using Sprint0.Commands.Player;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Blocks;
using Microsoft.Xna.Framework;
using Sprint0.Commands.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Commands.Levels;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and blocks
    public class PlayerBlockCollisionHandler
    {
        public void HandleCollision(IPlayer player, IBlock block, Types.Direction playerSide, Game1 game)
        {
            //types of blocks player cannot walk through
            if (block.IsWall())
            {
                // If the block is a PushableBlock, try and push it
                if (block is PushableBlock)
                {
                    new PushPushableBlockCommand(block as PushableBlock, playerSide).Execute();
                }
                player.StopAction();
                Rectangle PHitbox = player.GetHitbox();
                Rectangle BHitbox = block.GetHitbox();

                /* The player from everything else in the game in that it has a different size hitbox (relative to its sprite)
                 * and can also move. As a result of this, some extra math needs to be done so that collision works properly.
                 */
                Vector2 PHitboxOffset = new Vector2((int)PHitbox.X - player.Position.X, (int)PHitbox.Y - player.Position.Y);
                int X, Y;
                
                switch (playerSide)
                {
                    case (Types.Direction.DOWN):
                        X = PHitbox.X - (int)PHitboxOffset.X;
                        Y = BHitbox.Y - PHitbox.Height - (int)PHitboxOffset.Y;
                        new PlayerRelocateCommand(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.UP):
                        X = PHitbox.X - (int)PHitboxOffset.X;
                        Y = BHitbox.Y + BHitbox.Height - (int)PHitboxOffset.Y;
                        new PlayerRelocateCommand(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.RIGHT):
                        X = BHitbox.X - PHitbox.Width - (int)PHitboxOffset.X;
                        Y = PHitbox.Y - (int)PHitboxOffset.Y;
                        new PlayerRelocateCommand(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.LEFT):
                        X = BHitbox.X + BHitbox.Width - (int)PHitboxOffset.X;
                        Y = PHitbox.Y - (int)PHitboxOffset.Y;
                        new PlayerRelocateCommand(player, new Vector2(X, Y)).Execute();
                        break;
                }
                if (block is RoomTransitionBlock)
                {
                    new RoomTransitionCommand(game, playerSide).Execute();
                } else if (block is BlueStairs)
                {
                    new SecretRoomTransitionCommand(game).Execute();
                } else if (block is SecretRoomTransitionBlock)
                {
                    new ExitSecretRoomTransitionCommand(game).Execute();
                }
            } 
        }
    }
}
