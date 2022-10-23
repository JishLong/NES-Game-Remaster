using Sprint0.Commands.Player;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Blocks;
using Microsoft.Xna.Framework;

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
                player.StopAction();
                Rectangle PHitbox = player.GetHitbox();
                Rectangle BHitbox = block.GetHitbox();
                int X, Y;
                
                switch (playerSide)
                {
                    case (Types.Direction.DOWN):
                        X = PHitbox.X;
                        Y = BHitbox.Y - PHitbox.Height;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.UP):
                        X = PHitbox.X;
                        Y = BHitbox.Y + BHitbox.Height;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.RIGHT):
                        X = BHitbox.X - PHitbox.Width;
                        Y = PHitbox.Y;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                    case (Types.Direction.LEFT):
                        X = BHitbox.X + BHitbox.Width;
                        Y = PHitbox.Y;
                        new PlayerRelocate(player, new Vector2(X, Y)).Execute();
                        break;
                        //block: if pushable -> block.push
                }
            }
        }
    }
}
