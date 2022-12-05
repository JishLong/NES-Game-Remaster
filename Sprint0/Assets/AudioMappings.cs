using Microsoft.Xna.Framework.Audio;
using Sprint0.GameModes;

namespace Sprint0.Assets
{
    public class AudioMappings
    {
        private static AudioMappings Instance;

        private readonly GameModeManager GMM;

        private AudioMappings() 
        {
            GMM = GameModeManager.GetInstance();
        }

        public static AudioMappings GetInstance()
        {
            Instance ??= new AudioMappings();
            return Instance;
        }

        public SoundEffect BombExplode => GMM.GameMode.AudioAssets.BombExplode;

        public SoundEffect BombPlace => GMM.GameMode.AudioAssets.BombPlace;

        public SoundEffect BossRoar => GMM.GameMode.AudioAssets.BossRoar;

        public SoundEffect DoorOpen => GMM.GameMode.AudioAssets.DoorOpen;

        public SoundEffect EnemyDeath => GMM.GameMode.AudioAssets.EnemyDeath;

        public SoundEffect EnemyHurt => GMM.GameMode.AudioAssets.EnemyHurt;

        public SoundEffect FlameShoot => GMM.GameMode.AudioAssets.FlameShoot;
        public SoundEffect GameModeTransition => GMM.GameMode.AudioAssets.GameModeTransition;

        public SoundEffect ItemAppear => GMM.GameMode.AudioAssets.ItemAppear;

        public SoundEffect ItemFound => GMM.GameMode.AudioAssets.ItemFound;

        public SoundEffect MusicGame => GMM.GameMode.AudioAssets.MusicGame;

        public SoundEffect MusicMenu => GMM.GameMode.AudioAssets.MusicMenu;

        public SoundEffect OldManTaunt => GMM.GameMode.AudioAssets.OldManTaunt;

        public SoundEffect PickupHeartKey => GMM.GameMode.AudioAssets.PickupHeartKey;

        public SoundEffect PickupItem => GMM.GameMode.AudioAssets.PickupItem;

        public SoundEffect PickupRupee => GMM.GameMode.AudioAssets.PickupRupee;

        public SoundEffect PlayerDeath => GMM.GameMode.AudioAssets.PlayerDeath;

        public SoundEffect PlayerHurt => GMM.GameMode.AudioAssets.PlayerHurt;

        public SoundEffect PlayerLowHealth => GMM.GameMode.AudioAssets.PlayerLowHealth;

        public SoundEffect ProjectileBlocked => GMM.GameMode.AudioAssets.ProjectileBlocked;

        public SoundEffect ProjectileShoot => GMM.GameMode.AudioAssets.ProjectileShoot;

        public SoundEffect SecretFound => GMM.GameMode.AudioAssets.SecretFound;

        public SoundEffect SwordShoot => GMM.GameMode.AudioAssets.SwordShoot;

        public SoundEffect SwordSwing => GMM.GameMode.AudioAssets.SwordSwing;

        public SoundEffect TextAppear => GMM.GameMode.AudioAssets.TextAppear;

        public SoundEffect WinGame => GMM.GameMode.AudioAssets.WinGame;
    }
}
