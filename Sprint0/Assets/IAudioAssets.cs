using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets
{
    public interface IAudioAssets
    {
        void LoadContent(ContentManager c);

        SoundEffect BombExplode { get; }
        SoundEffect BombPlace { get; }
        SoundEffect BossRoar { get; }
        SoundEffect DoorOpen { get; }
        SoundEffect EnemyDeath { get; }
        SoundEffect EnemyHurt { get; }
        SoundEffect FlameShoot { get; }
        SoundEffect GameModeTransition { get; }
        SoundEffect ItemAppear { get; }
        SoundEffect ItemFound { get; }
        SoundEffect MusicGame { get; }
        SoundEffect MusicMenu { get; }
        SoundEffect OldManTaunt { get; }
        SoundEffect PickupHeartKey { get; }
        SoundEffect PickupItem { get; }
        SoundEffect PickupRupee { get; }
        SoundEffect PlayerDeath { get; }
        SoundEffect PlayerHurt { get; }
        SoundEffect PlayerLowHealth { get; }
        SoundEffect ProjectileBlocked { get; }
        SoundEffect ProjectileShoot { get; }
        SoundEffect SecretFound { get; }
        SoundEffect SwordShoot { get; }
        SoundEffect SwordSwing { get; }
        SoundEffect TextAppear { get; }
        SoundEffect WinGame { get; }
    }
}
