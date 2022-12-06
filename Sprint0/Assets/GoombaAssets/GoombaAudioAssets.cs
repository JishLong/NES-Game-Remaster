using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.GoombaAssets
{
    public class GoombaAudioAssets : DefaultAudioAssets
    {
        // Bonus sound for goomba game mode :)
        public SoundEffect WarpPipe { get; private set; }

        public override void LoadContent(ContentManager c)
        {
            BombExplode = c.Load<SoundEffect>("Audio/Goomba/fireworks");
            BombPlace = c.Load<SoundEffect>("Audio/Goomba/brickBump");
            BossRoar = c.Load<SoundEffect>("Audio/Goomba/bowserFire");
            DoorOpen = c.Load<SoundEffect>("Audio/Goomba/brickSmash");
            EnemyDeath = c.Load<SoundEffect>("Audio/Goomba/enemyKick");
            EnemyHurt = c.Load<SoundEffect>("Audio/Goomba/enemyStomp");
            FlameShoot = c.Load<SoundEffect>("Audio/Goomba/fireball");
            ItemAppear = c.Load<SoundEffect>("Audio/Goomba/powerUpAppear");
            ItemFound = c.Load<SoundEffect>("Audio/Goomba/stageClear");
            MusicGame = c.Load<SoundEffect>("Audio/Goomba/overworldMusic");
            MusicMenu = c.Load<SoundEffect>("Audio/Default/musicMenu");
            OldManTaunt = c.Load<SoundEffect>("Audio/Goomba/marioShow");
            PickupHeartKey = c.Load<SoundEffect>("Audio/Goomba/powerUp");
            PickupItem = c.Load<SoundEffect>("Audio/Goomba/halfPause");
            PickupRupee = c.Load<SoundEffect>("Audio/Goomba/coin");
            PlayerDeath = c.Load<SoundEffect>("Audio/Goomba/playerDeath");
            PlayerHurt = c.Load<SoundEffect>("Audio/Goomba/vineBoom");
            PlayerLowHealth = c.Load<SoundEffect>("Audio/Goomba/quarterPause");
            ProjectileBlocked = c.Load<SoundEffect>("Audio/Goomba/pause");
            ProjectileShoot = FlameShoot;
            SecretFound = c.Load<SoundEffect>("Audio/Goomba/oneUp");
            SwordShoot = c.Load<SoundEffect>("Audio/Goomba/goombaLaserHum");
            SwordSwing = c.Load<SoundEffect>("Audio/Goomba/goombaLaserFire");
            TextAppear = PlayerLowHealth;
            WinGame = c.Load<SoundEffect>("Audio/Goomba/worldClear");

            WarpPipe = c.Load<SoundEffect>("Audio/Goomba/pipe");

            GameModeTransition = c.Load<SoundEffect>("Audio/Goomba/bowserFalls");
        }
    }
}
