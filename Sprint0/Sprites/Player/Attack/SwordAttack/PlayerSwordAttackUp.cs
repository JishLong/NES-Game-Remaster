using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    // NOTE: this class is using new draw logic that is not yet implemented in most other sprite classes
    public class PlayerSwordAttackUp : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackUp instance;

        public static PlayerSwordAttackUp GetInstance(PlayerStateController stateController)
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackUp(stateController);
            }
            return instance;
        }

        private PlayerSwordAttackUp(PlayerStateController stateController) : base(4, 8)
        {
            yOffsetPixels = -12;
            this.stateController = stateController;
        }

        private readonly PlayerStateController stateController;

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordUp;

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
