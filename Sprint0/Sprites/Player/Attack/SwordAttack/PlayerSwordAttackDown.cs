using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackDown : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackDown instance;

        public static PlayerSwordAttackDown GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackDown(stateController);
            }
            return instance;
        }

        private PlayerSwordAttackDown(PlayerStateController stateController) : base(4, 8)
        {
            this.stateController = stateController;
        }

        private readonly PlayerStateController stateController;

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordDown;

        public override void Update()
        {
            Timer = (Timer + 1) % Speed;
            if (Timer == 0)
            {
                CurrentFrame++;
                if (CurrentFrame == NumFrames - 1)
                {
                    CurrentFrame = 0;
                    stateController.GetState().StopAttacking();
                }
            }
        }
    }
}
