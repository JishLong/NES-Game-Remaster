using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint0.Utils;

namespace Sprint0.Player.HUD
{
    public class HUDHearts
    {
        private readonly Player Player;

        public HUDHearts(Player player)
        {
            Player = player; 
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 Life = new((int)(176 * GameWindow.ResolutionScale), (int)(32 * GameWindow.ResolutionScale));

            for (int i = 0; i < 8; i++)
            {
                Rectangle LifeArea = new((int)(Life.X + i * 8 * GameWindow.ResolutionScale), (int)Life.Y, 
                    (int)(8 * GameWindow.ResolutionScale), (int)(8 * GameWindow.ResolutionScale));

                if (Player.Health >= 2 * (i + 1)) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.FullHeart, Color.White,
                    0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                else if (Player.Health == 2 * i + 1) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.HalfHeart, Color.White,
                    0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                else if (Player.MaxHealth >= 2 * (i + 1)) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.EmptyHeart, Color.White,
                    0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            }
            for (int i = 8; i < 16; i++)
            {
                Rectangle LifeArea = new((int)(Life.X + (i - 8) * 8 * GameWindow.ResolutionScale), (int)(Life.Y + 8 * GameWindow.ResolutionScale), 
                    (int)(8 * GameWindow.ResolutionScale), (int)(8 * GameWindow.ResolutionScale));

                if (Player.Health >= 2 * (i + 1)) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.FullHeart, Color.White,
                    0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                else if (Player.Health == 2 * i + 1) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.HalfHeart, Color.White,
                    0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                else if (Player.MaxHealth >= 2 * (i + 1)) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.EmptyHeart, Color.White,
                    0f, Vector2.Zero, SpriteEffects.None, 0.18f);
            }
        }
    }
}
