using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets.GoombaAssets
{
    public class GoombaAudioAssets : IAudioAssets
    {
        public SoundEffect BombExplode { get; private set; }
        public SoundEffect BombPlace { get; private set; }
        public SoundEffect BossRoar { get; private set; }
        public SoundEffect DoorOpen { get; private set; }
        public SoundEffect EnemyDeath { get; private set; }
        public SoundEffect EnemyHurt { get; private set; }
        public SoundEffect FlameShoot { get; private set; }
        public SoundEffect GameModeTransition { get; private set; }
        public SoundEffect ItemAppear { get; private set; }
        public SoundEffect ItemFound { get; private set; }
        public SoundEffect MusicGame { get; private set; }
        public SoundEffect MusicMenu { get; private set; }
        public SoundEffect OldManTaunt { get; private set; }
        public SoundEffect PickupHeartKey { get; private set; }
        public SoundEffect PickupItem { get; private set; }
        public SoundEffect PickupRupee { get; private set; }
        public SoundEffect PlayerDeath { get; private set; }
        public SoundEffect PlayerHurt { get; private set; }
        public SoundEffect PlayerLowHealth { get; private set; }
        public SoundEffect ProjectileBlocked { get; private set; }
        public SoundEffect ProjectileShoot { get; private set; }
        public SoundEffect SecretFound { get; private set; }
        public SoundEffect SwordShoot { get; private set; }
        public SoundEffect SwordSwing { get; private set; }
        public SoundEffect TextAppear { get; private set; }
        public SoundEffect WinGame { get; private set; }

        // Bonus sound
        public SoundEffect WarpPipe { get; private set; }

        public void LoadContent(ContentManager c)
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

            GameModeTransition = PickupHeartKey;
        }
    }
}
