using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets.DefaultAssets
{
    public class DefaultAudioAssets : IAudioAssets
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
            BombExplode = c.Load<SoundEffect>("Audio/Default/bombExplode");
            BombPlace = c.Load<SoundEffect>("Audio/Default/bombPlace");
            BossRoar = c.Load<SoundEffect>("Audio/Default/bossRoar");
            DoorOpen = c.Load<SoundEffect>("Audio/Default/doorOpen");
            EnemyDeath = c.Load<SoundEffect>("Audio/Default/enemyDeath");
            EnemyHurt = c.Load<SoundEffect>("Audio/Default/enemyHurt");
            FlameShoot = c.Load<SoundEffect>("Audio/Default/flameShoot");
            ItemAppear = c.Load<SoundEffect>("Audio/Default/itemAppear");
            ItemFound = c.Load<SoundEffect>("Audio/Default/itemFound");
            MusicGame = c.Load<SoundEffect>("Audio/Default/musicGame");
            MusicMenu = c.Load<SoundEffect>("Audio/Default/musicMenu");
            OldManTaunt = c.Load<SoundEffect>("Audio/Default/oldManTaunt");
            PickupHeartKey = c.Load<SoundEffect>("Audio/Default/pickupHeartKey");
            PickupItem = c.Load<SoundEffect>("Audio/Default/pickupItem");
            PickupRupee = c.Load<SoundEffect>("Audio/Default/pickupRupee");
            PlayerDeath = c.Load<SoundEffect>("Audio/Default/playerDeath");
            PlayerHurt = c.Load<SoundEffect>("Audio/Default/playerHurt");
            PlayerLowHealth = c.Load<SoundEffect>("Audio/Default/playerLowHealth");
            ProjectileBlocked = c.Load<SoundEffect>("Audio/Default/projectileBlocked");
            ProjectileShoot = c.Load<SoundEffect>("Audio/Default/projectileShoot");
            SecretFound = c.Load<SoundEffect>("Audio/Default/secretFound");
            SwordShoot = c.Load<SoundEffect>("Audio/Default/swordShoot");
            SwordSwing = c.Load<SoundEffect>("Audio/Default/swordSwing");
            TextAppear = c.Load<SoundEffect>("Audio/Default/textAppear");
            WinGame = c.Load<SoundEffect>("Audio/Default/winGame");

            GameModeTransition = ItemFound;
        }
    }
}
