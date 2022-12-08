using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets.DefaultAssets
{
    public class MoonAudioAssets: DefaultAudioAssets
    {
        public override void LoadContent(ContentManager c)
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
