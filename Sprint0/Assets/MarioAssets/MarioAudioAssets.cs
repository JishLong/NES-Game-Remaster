using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets.MarioAssets
{
    public class MarioAudioAssets : IAudioAssets
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

        public void LoadContent(ContentManager c)
        {
            BombExplode = c.Load<SoundEffect>("Audio/Mario/fireworks");
            BombPlace = c.Load<SoundEffect>("Audio/Mario/brickBump");
            BossRoar = c.Load<SoundEffect>("Audio/Mario/bowserFire");
            DoorOpen = c.Load<SoundEffect>("Audio/Mario/brickSmash");
            EnemyDeath = c.Load<SoundEffect>("Audio/Mario/enemyKick");
            EnemyHurt = c.Load<SoundEffect>("Audio/Mario/enemyStomp");
            FlameShoot = c.Load<SoundEffect>("Audio/Mario/fireball");
            ItemAppear = c.Load<SoundEffect>("Audio/Mario/powerUpAppear");
            ItemFound = c.Load<SoundEffect>("Audio/Mario/stageClear");
            MusicGame = c.Load<SoundEffect>("Audio/Mario/castleMusic");
            MusicMenu = c.Load<SoundEffect>("Audio/Default/musicMenu");
            OldManTaunt = c.Load<SoundEffect>("Audio/Mario/marioShow");
            PickupHeartKey = c.Load<SoundEffect>("Audio/Mario/powerUp");
            PickupItem = c.Load<SoundEffect>("Audio/Mario/halfPause");
            PickupRupee = c.Load<SoundEffect>("Audio/Mario/coin");
            PlayerDeath = c.Load<SoundEffect>("Audio/Mario/playerDeath");
            PlayerHurt = c.Load<SoundEffect>("Audio/Mario/pipe");
            PlayerLowHealth = c.Load<SoundEffect>("Audio/Mario/quarterPause");
            ProjectileBlocked = c.Load<SoundEffect>("Audio/Mario/pause");
            ProjectileShoot = FlameShoot;
            SecretFound = c.Load<SoundEffect>("Audio/Mario/oneUp");
            SwordShoot = FlameShoot;
            SwordSwing = c.Load<SoundEffect>("Audio/Mario/bowserFalls");
            TextAppear = PlayerLowHealth;
            WinGame = c.Load<SoundEffect>("Audio/Mario/worldClear");

            GameModeTransition = PickupHeartKey;
        }
    }
}
