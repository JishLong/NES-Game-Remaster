﻿using Sprint0.Player.State.Idle;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.State.Bow
{
    public class PlayerBowLeftState : AbstractPlayerState
    {
        public PlayerBowLeftState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemLeftSprite();

            SpawnArrow();
        }

        public PlayerBowLeftState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemLeftSprite();

            SpawnArrow();
        }

        private void SpawnArrow()
        {
            float ArrowX = Player.GetHitbox().Left;
            float ArrowY = Player.GetHitbox().Center.Y;

            ProjectileManager.GetInstance().AddProjectile(new ArrowProjectile(
            new Vector2(ArrowX, ArrowY), Types.Direction.LEFT));
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
            if ((FramesPassed + 1) % 40 == 0)
            {
                Player.State = new PlayerFacingLeftState(this);
            }
        }
    }
}