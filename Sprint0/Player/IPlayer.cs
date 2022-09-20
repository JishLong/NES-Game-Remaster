using System;
using Sprint0.Player.State;

namespace Sprint0.Player
{
    public interface IPlayer
    {
        public void Update();

        public void Draw();

        public PlayerStateController GetStateController();
    }
}

