using System;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public interface IPlayer
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch);

        public PlayerStateController GetStateController();
    }
}

