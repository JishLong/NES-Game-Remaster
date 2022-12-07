using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets
{
    public interface IImageAssets
    {
        void LoadContent(ContentManager c);

        // Sprite sheets
        Texture2D BlocksSpriteSheet { get; }
        Texture2D CharactersSpriteSheet { get; }
        Texture2D CursorSpriteSheet { get; }
        Texture2D GuiSpriteSheet { get; }
        Texture2D GuiElementsSpriteSheet { get; }
        Texture2D ItemsSpriteSheet { get; }
        Texture2D PlayerSpriteSheet { get; }
        Texture2D ProjectilesSpriteSheet { get; }
        Texture2D RoomSpriteSheet { get; }

        // Block sprite sheet positions
        Rectangle BlueTile { get; }
        Rectangle BlueWall { get; }
        Rectangle BlueStatueLeft { get; }
        Rectangle BlueStatueRight { get; }
        Rectangle BlueStairs { get; }
        Rectangle BlueSand { get; }
        Rectangle GreyBricks { get; }
        Rectangle WhiteBars { get; }
        Rectangle Water { get; }
        Rectangle Sand { get; }
        Rectangle RedSand { get; }
        Rectangle RedStatueLeft { get; }
        Rectangle RedStatueRight { get; }

        // Character sprite sheet positions
        Rectangle Aquamentus { get; }
        Rectangle Bat { get; }
        Rectangle BladeTrap { get; }
        Rectangle DodongoDown { get; }
        Rectangle DodongoLeft { get; }
        Rectangle DodongoRight { get; }
        Rectangle DodongoUp { get; }
        Rectangle Flame { get; }
        Rectangle Gel { get; }
        Rectangle Hand { get; }
        Rectangle OldMan { get; }
        Rectangle RedGoriyaDown { get; }
        Rectangle RedGoriyaLeft { get; }
        Rectangle RedGoriyaRight { get; }
        Rectangle RedGoriyaUp { get; }
        Rectangle Skeleton { get; }
        Rectangle Snake { get; }
        Rectangle Zol { get; }

        // Mouse cursor sprite sheet position
        Rectangle Cursor { get; }

        // GUI sprite sheet positions
        Rectangle Hud { get; }
        Rectangle Inventory { get; }

        // GUI element sprite sheet positions
        Rectangle HeartEmpty { get; }
        Rectangle HeartFull { get; }
        Rectangle HeartHalf { get; }
        Rectangle HudMapPlayer { get; }
        Rectangle HudMapRoom { get; }
        Rectangle MapIconAllDoors { get; }
        Rectangle MapIconDownDoor { get; }
        Rectangle MapIconDownLeftDoors { get; }
        Rectangle MapIconDownRightDoors { get; }
        Rectangle MapIconHorizontalDoors { get; }
        Rectangle MapIconLeftDoor { get; }
        Rectangle MapIconNoDoors { get; }
        Rectangle MapIconNoDownDoor { get; }
        Rectangle MapIconNoLeftDoor { get; }
        Rectangle MapIconNoRightDoor { get; }
        Rectangle MapIconNoUpDoor { get; }
        Rectangle MapIconRightDoor { get; }
        Rectangle MapIconUpDoor { get; }
        Rectangle MapIconUpLeftDoors { get; }
        Rectangle MapIconUpRightDoors { get; }
        Rectangle MapIconVerticalDoors { get; }
        Rectangle Panel { get; }
        Rectangle SelectedSlot { get; }
        Rectangle ScreenCover { get; }

        // Item sprite sheet positions
        Rectangle Compass { get; }
        Rectangle Map { get; }
        Rectangle Key { get; }
        Rectangle HeartContainer { get; }
        Rectangle WoodenBoomerang { get; }
        Rectangle Bow { get; }
        Rectangle Arrow { get; }
        Rectangle Bomb { get; }
        Rectangle Clock { get; }
        Rectangle BlueCandle { get; }
        Rectangle BluePotion { get; }
        Rectangle Fairy { get; }
        Rectangle Heart { get; }
        Rectangle Rupee { get; }
        Rectangle TriforcePiece { get; }

        // Player sprite sheet positions
        Rectangle PlayerDown { get; }
        Rectangle PlayerHoldItem { get; }
        Rectangle PlayerLeft { get; }
        Rectangle PlayerRight { get; }
        Rectangle PlayerSwordDown { get; }
        Rectangle PlayerSwordLeft { get; }
        Rectangle PlayerSwordRight { get; }
        Rectangle PlayerSwordUp { get; }
        Rectangle PlayerUp { get; }

        // Projectile sprite sheet positions
        Rectangle ArrowExplosionProjectile { get; }
        Rectangle ArrowProjectileDown { get; }
        Rectangle ArrowProjectileLeft { get; }
        Rectangle ArrowProjectileRight { get; }
        Rectangle ArrowProjectileUp { get; }
        Rectangle BlueArrowProjectileDown { get; }
        Rectangle BlueArrowProjectileLeft { get; }
        Rectangle BlueArrowProjectileRight { get; }
        Rectangle BlueArrowProjectileUp { get; }
        Rectangle BombExplosionProjectile { get; }
        Rectangle BombProjectile { get; }
        Rectangle BoomerangProjectile { get; }
        Rectangle BossProjectile { get; }
        Rectangle CharacterDeathProjectile { get; }
        Rectangle FlameProjectile { get; }
        Rectangle SwordFlameProjectileUpLeft { get; }
        Rectangle SwordFlameProjectileUpRight { get; }
        Rectangle SwordFlameProjectileDownLeft { get; }
        Rectangle SwordFlameProjectileDownRight { get; }
        Rectangle SwordMeleeHorizontal { get; }
        Rectangle SwordMeleeVertical { get; }
        Rectangle SwordProjectileDown { get; }
        Rectangle SwordProjectileLeft { get; }
        Rectangle SwordProjectileRight { get; }
        Rectangle SwordProjectileUp { get; }

        // Room sprite sheet positions (borders and doors)
        Rectangle EventLockedDoorDown { get; }
        Rectangle EventLockedDoorLeft { get; }
        Rectangle EventLockedDoorRight { get; }
        Rectangle EventLockedDoorUp { get; }
        Rectangle KeyLockedDoorDown { get; }
        Rectangle KeyLockedDoorLeft { get; }
        Rectangle KeyLockedDoorRight { get; }
        Rectangle KeyLockedDoorUp { get; }
        Rectangle Level1Border { get; }
        Rectangle SecretDoorWallDown { get; }
        Rectangle SecretDoorWayDown { get; }
        Rectangle SecretDoorWallLeft { get; }
        Rectangle SecretDoorWayLeft { get; }
        Rectangle SecretDoorWallRight { get; }
        Rectangle SecretDoorWayRight { get; }
        Rectangle SecretDoorWallUp { get; }
        Rectangle SecretDoorWayUp { get; }
        Rectangle UnlockedDoorWallDown { get; }
        Rectangle UnlockedDoorWayDown { get; }
        Rectangle UnlockedDoorWallLeft { get; }
        Rectangle UnlockedDoorWayLeft { get; }
        Rectangle UnlockedDoorWallRight { get; }
        Rectangle UnlockedDoorWayRight { get; }
        Rectangle UnlockedDoorWallUp { get; }
        Rectangle UnlockedDoorWayUp { get; }
        Rectangle WallDoorDown { get; }
        Rectangle WallDoorLeft { get; }
        Rectangle WallDoorRight { get; }
        Rectangle WallDoorUp { get; }
    }
}
