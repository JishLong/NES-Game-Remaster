using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Assets.MinecraftAssets
{
    public class MinecraftAudioAssets : IAudioAssets
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
            BombExplode = c.Load<SoundEffect>("Audio/Minecraft/tntExplode");
            BombPlace = c.Load<SoundEffect>("Audio/Minecraft/tntLit");
            BossRoar = c.Load<SoundEffect>("Audio/Minecraft/witherShoot");
            DoorOpen = c.Load<SoundEffect>("Audio/Minecraft/doorOpen");
            EnemyDeath = c.Load<SoundEffect>("Audio/Minecraft/critAttack");
            EnemyHurt = c.Load<SoundEffect>("Audio/Minecraft/bowDing");
            FlameShoot = c.Load<SoundEffect>("Audio/Minecraft/flintAndSteel");
            ItemAppear = c.Load<SoundEffect>("Audio/Minecraft/anvil");
            ItemFound = c.Load<SoundEffect>("Audio/Minecraft/xpLevelUp");
            MusicGame = c.Load<SoundEffect>("Audio/Minecraft/sweden");
            MusicMenu = c.Load<SoundEffect>("Audio/Default/musicMenu");
            OldManTaunt = c.Load<SoundEffect>("Audio/Minecraft/revenge");
            PickupHeartKey = c.Load<SoundEffect>("Audio/Minecraft/finishEating");
            PickupItem = c.Load<SoundEffect>("Audio/Minecraft/itemPickup");
            PickupRupee = c.Load<SoundEffect>("Audio/Minecraft/xp");
            PlayerDeath = c.Load<SoundEffect>("Audio/Minecraft/oldPlayerHit");
            PlayerHurt = c.Load<SoundEffect>("Audio/Minecraft/playerHurt");
            PlayerLowHealth = c.Load<SoundEffect>("Audio/Minecraft/blockPlace");
            ProjectileBlocked = c.Load<SoundEffect>("Audio/Minecraft/shieldBlock");
            ProjectileShoot = c.Load<SoundEffect>("Audio/Minecraft/bowShoot");
            SecretFound = c.Load<SoundEffect>("Audio/Minecraft/piston");
            SwordShoot = c.Load<SoundEffect>("Audio/Minecraft/tridentThrow");
            SwordSwing = c.Load<SoundEffect>("Audio/Minecraft/swordSwing");
            TextAppear = c.Load<SoundEffect>("Audio/Minecraft/dispenser");
            WinGame = c.Load<SoundEffect>("Audio/Minecraft/achievement");

            GameModeTransition = c.Load<SoundEffect>("Audio/Minecraft/witherDeath"); ;
        }
    }
}
