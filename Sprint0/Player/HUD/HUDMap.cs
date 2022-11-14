using Sprint0.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Player.HUD
{
    public class HUDMap
    {
        private LevelManager LevelManager;
        private Player Player;

        public HUDMap(LevelManager levelManager, Player player)
        {
            LevelManager = levelManager;
            Player = player;
        }
    }
}
