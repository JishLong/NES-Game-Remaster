using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.MinecraftAssets
{
    public class MinecraftAudioAssets : DefaultAudioAssets
    {
        public override void LoadContent(ContentManager c)
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
