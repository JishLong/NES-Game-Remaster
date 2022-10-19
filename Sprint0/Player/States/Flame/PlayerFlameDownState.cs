﻿using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.States.Flame
{
    public class PlayerFlameDownState : AbstractPlayerState
    {
        public PlayerFlameDownState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemDownSprite();

            SpawnFlame();
        }

        public PlayerFlameDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemDownSprite();

            SpawnFlame();
        }

        private void SpawnFlame()
        {
            // Magic numbers for position for now
            float FlameX = Player.GetHitbox().Center.X - Resources.FlameProj.Width * Utils.GameScale / 2;
            float FlameY = Player.GetHitbox().Bottom;

            ProjectileManager.GetInstance().AddProjectile(new FlameProjectile(
            new Vector2(FlameX, FlameY), Types.Direction.DOWN));
        }

        public override void Update()
        {
            base.Update();

            /* This "40" is a magic number and is just an arbitrary value I picked for how long link is in his mf stanced up
             * pose for;
             * 
             * Should we make a variable for this so it's not a magic number? Also, is there an actual value for this number that
             * is accurate to the game? 40 seemed to work somewhat well but like I said it's just arbitrary
             */
            if (FramesPassed % 40 == 0)
            {
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
