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

            for (int i = 0; i < Player.MaxHealth / 16 + 1; i++) 
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle LifeArea = new((int)(Life.X + j * 8 * GameWindow.ResolutionScale), (int)(Life.Y + 8 * i * GameWindow.ResolutionScale),
                        (int)(8 * GameWindow.ResolutionScale), (int)(8 * GameWindow.ResolutionScale));

                    if (Player.Health >= 2 * (j + 1) + (i * 16)) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.FullHeart, Color.White,
                        0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                    else if (Player.Health == 2 * j + 1 + (i * 16)) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.HalfHeart, Color.White,
                        0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                    else if (Player.MaxHealth >= 2 * (j + 1) + (i * 16) - 1) sb.Draw(Resources.GuiElementsSpriteSheet, LinkToCamera(LifeArea), Resources.EmptyHeart, Color.White,
                        0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                }
            }
        }
    }
}
