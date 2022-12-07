using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets.DefaultAssets
{
    public class DefaultAudioAssets : IAudioAssets
    {
        public virtual void LoadContent(ContentManager c)
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

        public SoundEffect BombExplode { get; protected set; }
        public SoundEffect BombPlace { get; protected set; }
        public SoundEffect BossRoar { get; protected set; }
        public SoundEffect DoorOpen { get; protected set; }
        public SoundEffect EnemyDeath { get; protected set; }
        public SoundEffect EnemyHurt { get; protected set; }
        public SoundEffect FlameShoot { get; protected set; }
        public SoundEffect GameModeTransition { get; protected set; }
        public SoundEffect ItemAppear { get; protected set; }
        public SoundEffect ItemFound { get; protected set; }
        public SoundEffect MusicGame { get; protected set; }
        public SoundEffect MusicMenu { get; protected set; }
        public SoundEffect OldManTaunt { get; protected set; }
        public SoundEffect PickupHeartKey { get; protected set; }
        public SoundEffect PickupItem { get; protected set; }
        public SoundEffect PickupRupee { get; protected set; }
        public SoundEffect PlayerDeath { get; protected set; }
        public SoundEffect PlayerHurt { get; protected set; }
        public SoundEffect PlayerLowHealth { get; protected set; }
        public SoundEffect ProjectileBlocked { get; protected set; }
        public SoundEffect ProjectileShoot { get; protected set; }
        public SoundEffect SecretFound { get; protected set; }
        public SoundEffect SwordShoot { get; protected set; }
        public SoundEffect SwordSwing { get; protected set; }
        public SoundEffect TextAppear { get; protected set; }
        public SoundEffect WinGame { get; protected set; }
    }
}
