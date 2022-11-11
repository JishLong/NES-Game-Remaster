﻿using Sprint0.Player;
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
            if (block.IsWall)
            {            
                Rectangle PHitbox = player.GetHitbox();
                Rectangle BHitbox = block.GetHitbox();

                /* The player from everything else in the game in that it has a different size hitbox (relative to its sprite)
                 * and can also move. As a result of this, some extra math needs to be done so that collision works properly.
                 */
                Vector2 PHitboxOffset = new Vector2((int)PHitbox.X - player.Position.X, (int)PHitbox.Y - player.Position.Y);
                
                switch (playerSide)
                {
                    case (Types.Direction.DOWN):
                        player.Position = new Vector2(PHitbox.X - (int)PHitboxOffset.X, BHitbox.Y - PHitbox.Height - (int)PHitboxOffset.Y);
                        break;
                    case (Types.Direction.UP):
                        player.Position = new Vector2(PHitbox.X - (int)PHitboxOffset.X, BHitbox.Y + BHitbox.Height - (int)PHitboxOffset.Y);
                        break;
                    case (Types.Direction.RIGHT):
                        player.Position = new Vector2(BHitbox.X - PHitbox.Width - (int)PHitboxOffset.X, PHitbox.Y - (int)PHitboxOffset.Y);
                        break;
                    case (Types.Direction.LEFT):
                        player.Position = new Vector2(BHitbox.X + BHitbox.Width - (int)PHitboxOffset.X, PHitbox.Y - (int)PHitboxOffset.Y);
                        break;
                }

                // If the block is a PushableBlock, try and push it
                if (block is PushableBlock)
                {
                    new PushPushableBlockCommand(block as PushableBlock, playerSide).Execute();
                }

                // If the block is some sort of room transition trigger, trigger the room transition
                if (block is RoomTransitionBlock)
                {
                    new RoomTransitionCommand(game, playerSide).Execute();
                    player.StopAction();
                }
                else if (block is BlueStairs)
                {
                    new SecretRoomTransitionCommand(game).Execute();
                    player.StopAction();
                }
                else if (block is SecretRoomTransitionBlock)
                {
                    new ExitSecretRoomTransitionCommand(game).Execute();
                    player.StopAction();
                }
            } 
        }
    }
}
