using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.MarioAssets
{
    public class MarioAudioAssets : DefaultAudioAssets
    {
        public override void LoadContent(ContentManager c)
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
