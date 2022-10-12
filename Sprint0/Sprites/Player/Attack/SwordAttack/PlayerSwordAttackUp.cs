﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.SwordAttack
{
    // NOTE: this class is using new draw logic that is not yet implemented in most other sprite classes
    public class PlayerSwordAttackUp : AnimatedSprite
    {
        // Singleton instance
        private static PlayerSwordAttackUp instance;

        public static PlayerSwordAttackUp GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSwordAttackUp();
            }
            return instance;
        }

        private PlayerSwordAttackUp() : base(4, 8)
        {
            yOffsetPixels = -12;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.LinkSwordUp;
    }
}
