using Sprint0.Commands.Player;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Blocks;
using Microsoft.Xna.Framework;
using Sprint0.Commands.Blocks;
using System.Security.Principal;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and blocks
    public class PlayerBlockCollisionHandler
    {
        public void HandleCollision(IPlayer player, IBlock block, Types.Direction playerSide, Room room)
        {
            //types of blocks player cannot walk through
            if (!block.IsWalkable())
            {
                if (block is AbstractPushableBlock && playerSide == (block as AbstractPushableBlock).Direction) 
                {
                    new PushPushableBlockCommand(block as AbstractPushableBlock).Execute();
                }
                
                player.StopAction();
                Rectangle PHitbox = player.GetHitbox();
                Rectangle BHitbox = block.GetHitbox();
                Vector2 PHitboxOffset = new Vector2((int)PHitbox.X - player.GetPosition().X, (int)PHitbox.Y - player.GetPosition().Y);
                int X, Y;
                
                switch (playerSide)
                {
                    case (Types.Direction.DOWN):
                        X = PHitbox.X - (int)PHitboxOffset.X;
                        Y = BHitbox.Y - PHitbox.Height - (int)PHitboxOffset.Y;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.UP):
                        X = PHitbox.X - (int)PHitboxOffset.X;
                        Y = BHitbox.Y + BHitbox.Height - (int)PHitboxOffset.Y;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.RIGHT):
                        X = BHitbox.X - PHitbox.Width - (int)PHitboxOffset.X;
                        Y = PHitbox.Y - (int)PHitboxOffset.Y;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.LEFT):
                        X = BHitbox.X + BHitbox.Width - (int)PHitboxOffset.X;
                        Y = PHitbox.Y - (int)PHitboxOffset.Y;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                        //block: if pushable -> block.push
                }
            }
        }
    }
}
