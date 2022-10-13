using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    public class PlayerSwordAttackRight : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackRight instance;

        public static PlayerSwordAttackRight GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackRight(stateController);
            }
            return instance;
        }

        private PlayerSwordAttackRight(PlayerStateController stateController) : base(4, 8)
        {
            this.stateController = stateController;
        }

        private readonly PlayerStateController stateController;

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordRight;

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
