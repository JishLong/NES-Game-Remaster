using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;

namespace Sprint0.Assets
{
    public class ImageMappings
    {
        private static ImageMappings Instance;

        private readonly GameModeManager GMM;

        private ImageMappings()
        {
            GMM = GameModeManager.GetInstance();
        }

        public static ImageMappings GetInstance()
        {
            Instance ??= new ImageMappings();
            return Instance;
        }

        // Sprite sheets
        public Texture2D BlocksSpriteSheet => GMM.GameMode.ImageAssets.BlocksSpriteSheet;
        public Texture2D CharactersSpriteSheet => GMM.GameMode.ImageAssets.CharactersSpriteSheet;
        public Texture2D CursorSpriteSheet => GMM.GameMode.ImageAssets.CursorSpriteSheet;
        public Texture2D GuiSpriteSheet => GMM.GameMode.ImageAssets.GuiSpriteSheet;
        public Texture2D GuiElementsSpriteSheet => GMM.GameMode.ImageAssets.GuiElementsSpriteSheet;
        public Texture2D ItemsSpriteSheet => GMM.GameMode.ImageAssets.ItemsSpriteSheet;
        public Texture2D PlayerSpriteSheet => GMM.GameMode.ImageAssets.PlayerSpriteSheet;
        public Texture2D ProjectilesSpriteSheet => GMM.GameMode.ImageAssets.ProjectilesSpriteSheet;
        public Texture2D RoomSpriteSheet => GMM.GameMode.ImageAssets.RoomSpriteSheet;

        // Block sprite sheet positions
        public Rectangle BlueTile => GMM.GameMode.ImageAssets.BlueTile;
        public Rectangle BlueWall => GMM.GameMode.ImageAssets.BlueWall;
        public Rectangle BlueStatueLeft => GMM.GameMode.ImageAssets.BlueStatueLeft;
        public Rectangle BlueStatueRight => GMM.GameMode.ImageAssets.BlueStatueRight;
        public Rectangle BlueStairs => GMM.GameMode.ImageAssets.BlueStairs;
        public Rectangle BlueSand => GMM.GameMode.ImageAssets.BlueSand;
        public Rectangle GreyBricks => GMM.GameMode.ImageAssets.GreyBricks;
        public Rectangle WhiteBars => GMM.GameMode.ImageAssets.WhiteBars;
        public Rectangle Water => GMM.GameMode.ImageAssets.Water;
        public Rectangle Sand => GMM.GameMode.ImageAssets.Sand;
        public Rectangle RedSand => GMM.GameMode.ImageAssets.RedSand;
        public Rectangle RedStatueLeft => GMM.GameMode.ImageAssets.RedStatueLeft;
        public Rectangle RedStatueRight => GMM.GameMode.ImageAssets.RedStatueRight;

        // Character sprite sheet positions
        public Rectangle Aquamentus => GMM.GameMode.ImageAssets.Aquamentus;
        public Rectangle Bat => GMM.GameMode.ImageAssets.Bat;
        public Rectangle BladeTrap => GMM.GameMode.ImageAssets.BladeTrap;
        public Rectangle DodongoDown => GMM.GameMode.ImageAssets.DodongoDown;
        public Rectangle DodongoLeft => GMM.GameMode.ImageAssets.DodongoLeft;
        public Rectangle DodongoRight => GMM.GameMode.ImageAssets.DodongoRight;
        public Rectangle DodongoUp => GMM.GameMode.ImageAssets.DodongoUp;
        public Rectangle Flame => GMM.GameMode.ImageAssets.Flame;
        public Rectangle Gel => GMM.GameMode.ImageAssets.Gel;
        public Rectangle Hand => GMM.GameMode.ImageAssets.Hand;
        public Rectangle OldMan => GMM.GameMode.ImageAssets.OldMan;
        public Rectangle RedGoriyaDown => GMM.GameMode.ImageAssets.RedGoriyaDown;
        public Rectangle RedGoriyaLeft => GMM.GameMode.ImageAssets.RedGoriyaLeft;
        public Rectangle RedGoriyaRight => GMM.GameMode.ImageAssets.RedGoriyaRight;
        public Rectangle RedGoriyaUp => GMM.GameMode.ImageAssets.RedGoriyaUp;
        public Rectangle Skeleton => GMM.GameMode.ImageAssets.Skeleton;
        public Rectangle Snake => GMM.GameMode.ImageAssets.Snake;
        public Rectangle Zol => GMM.GameMode.ImageAssets.Zol;

        // Mouse cursor sprite sheet position
        public Rectangle Cursor => GMM.GameMode.ImageAssets.Cursor;

        // GUI sprite sheet positions
        public Rectangle Hud => GMM.GameMode.ImageAssets.Hud;
        public Rectangle Inventory => GMM.GameMode.ImageAssets.Inventory;

        // GUI element sprite sheet positions
        public Rectangle HeartEmpty => GMM.GameMode.ImageAssets.HeartEmpty;
        public Rectangle HeartFull => GMM.GameMode.ImageAssets.HeartFull;
        public Rectangle HeartHalf => GMM.GameMode.ImageAssets.HeartHalf;
        public Rectangle HudMapPlayer => GMM.GameMode.ImageAssets.HudMapPlayer;
        public Rectangle HudMapRoom => GMM.GameMode.ImageAssets.HudMapRoom;
        public Rectangle MapIconAllDoors => GMM.GameMode.ImageAssets.MapIconAllDoors;
        public Rectangle MapIconDownDoor => GMM.GameMode.ImageAssets.MapIconDownDoor;
        public Rectangle MapIconDownLeftDoors => GMM.GameMode.ImageAssets.MapIconDownLeftDoors;
        public Rectangle MapIconDownRightDoors => GMM.GameMode.ImageAssets.MapIconDownRightDoors;
        public Rectangle MapIconHorizontalDoors => GMM.GameMode.ImageAssets.MapIconHorizontalDoors;
        public Rectangle MapIconLeftDoor => GMM.GameMode.ImageAssets.MapIconLeftDoor;
        public Rectangle MapIconNoDoors => GMM.GameMode.ImageAssets.MapIconNoDoors;
        public Rectangle MapIconNoDownDoor => GMM.GameMode.ImageAssets.MapIconNoDownDoor;
        public Rectangle MapIconNoLeftDoor => GMM.GameMode.ImageAssets.MapIconNoLeftDoor;
        public Rectangle MapIconNoRightDoor => GMM.GameMode.ImageAssets.MapIconNoRightDoor;
        public Rectangle MapIconNoUpDoor => GMM.GameMode.ImageAssets.MapIconNoUpDoor;
        public Rectangle MapIconRightDoor => GMM.GameMode.ImageAssets.MapIconRightDoor;
        public Rectangle MapIconUpDoor => GMM.GameMode.ImageAssets.MapIconUpDoor;
        public Rectangle MapIconUpLeftDoors => GMM.GameMode.ImageAssets.MapIconUpLeftDoors;
        public Rectangle MapIconUpRightDoors => GMM.GameMode.ImageAssets.MapIconUpRightDoors;
        public Rectangle MapIconVerticalDoors => GMM.GameMode.ImageAssets.MapIconVerticalDoors;
        public Rectangle Panel => GMM.GameMode.ImageAssets.Panel;
        public Rectangle SelectedSlot => GMM.GameMode.ImageAssets.SelectedSlot;
        public Rectangle ScreenCover => GMM.GameMode.ImageAssets.ScreenCover;

        // Item sprite sheet positions
        public Rectangle Arrow => GMM.GameMode.ImageAssets.Arrow;
        public Rectangle BlueCandle => GMM.GameMode.ImageAssets.BlueCandle;
        public Rectangle BluePotion => GMM.GameMode.ImageAssets.BluePotion;
        public Rectangle Bomb => GMM.GameMode.ImageAssets.Bomb;
        public Rectangle Bow => GMM.GameMode.ImageAssets.Bow;
        public Rectangle Clock => GMM.GameMode.ImageAssets.Clock;
        public Rectangle Compass => GMM.GameMode.ImageAssets.Compass;
        public Rectangle Fairy => GMM.GameMode.ImageAssets.Fairy;
        public Rectangle Heart => GMM.GameMode.ImageAssets.Heart;
        public Rectangle HeartContainer => GMM.GameMode.ImageAssets.HeartContainer;
        public Rectangle Key => GMM.GameMode.ImageAssets.Key;
        public Rectangle Map => GMM.GameMode.ImageAssets.Map;
        public Rectangle Rupee => GMM.GameMode.ImageAssets.Rupee;
        public Rectangle TriforcePiece => GMM.GameMode.ImageAssets.TriforcePiece;
        public Rectangle WoodenBoomerang => GMM.GameMode.ImageAssets.WoodenBoomerang;

        // Player sprite sheet positions
        public Rectangle PlayerDown => GMM.GameMode.ImageAssets.PlayerDown;
        public Rectangle PlayerHoldItem => GMM.GameMode.ImageAssets.PlayerHoldItem;
        public Rectangle PlayerLeft => GMM.GameMode.ImageAssets.PlayerLeft;
        public Rectangle PlayerRight => GMM.GameMode.ImageAssets.PlayerRight;
        public Rectangle PlayerSwordDown => GMM.GameMode.ImageAssets.PlayerSwordDown;
        public Rectangle PlayerSwordLeft => GMM.GameMode.ImageAssets.PlayerSwordLeft;
        public Rectangle PlayerSwordRight => GMM.GameMode.ImageAssets.PlayerSwordRight;
        public Rectangle PlayerSwordUp => GMM.GameMode.ImageAssets.PlayerSwordUp;
        public Rectangle PlayerUp => GMM.GameMode.ImageAssets.PlayerUp;

        // Projectile sprite sheet positions
        public Rectangle ArrowExplosionProjectile => GMM.GameMode.ImageAssets.ArrowExplosionProjectile;
        public Rectangle ArrowProjectileDown => GMM.GameMode.ImageAssets.ArrowProjectileDown;
        public Rectangle ArrowProjectileLeft => GMM.GameMode.ImageAssets.ArrowProjectileLeft;
        public Rectangle ArrowProjectileRight => GMM.GameMode.ImageAssets.ArrowProjectileRight;
        public Rectangle ArrowProjectileUp => GMM.GameMode.ImageAssets.ArrowProjectileUp;
        public Rectangle BlueArrowProjectileDown => GMM.GameMode.ImageAssets.BlueArrowProjectileDown;
        public Rectangle BlueArrowProjectileLeft => GMM.GameMode.ImageAssets.BlueArrowProjectileLeft;
        public Rectangle BlueArrowProjectileRight => GMM.GameMode.ImageAssets.BlueArrowProjectileRight;
        public Rectangle BlueArrowProjectileUp => GMM.GameMode.ImageAssets.BlueArrowProjectileUp;
        public Rectangle BombExplosionProjectile => GMM.GameMode.ImageAssets.BombExplosionProjectile;
        public Rectangle BombProjectile => GMM.GameMode.ImageAssets.BombProjectile;
        public Rectangle BoomerangProjectile => GMM.GameMode.ImageAssets.BoomerangProjectile;
        public Rectangle BossProjectile => GMM.GameMode.ImageAssets.BossProjectile;
        public Rectangle CharacterDeathProjectile => GMM.GameMode.ImageAssets.CharacterDeathProjectile;
        public Rectangle FlameProjectile => GMM.GameMode.ImageAssets.FlameProjectile;
        public Rectangle SwordFlameProjectileDownLeft => GMM.GameMode.ImageAssets.SwordFlameProjectileDownLeft;
        public Rectangle SwordFlameProjectileDownRight => GMM.GameMode.ImageAssets.SwordFlameProjectileDownRight;
        public Rectangle SwordFlameProjectileUpLeft => GMM.GameMode.ImageAssets.SwordFlameProjectileUpLeft;
        public Rectangle SwordFlameProjectileUpRight => GMM.GameMode.ImageAssets.SwordFlameProjectileUpRight;
        public Rectangle SwordMeleeHorizontal => GMM.GameMode.ImageAssets.SwordMeleeHorizontal;
        public Rectangle SwordMeleeVertical => GMM.GameMode.ImageAssets.SwordMeleeVertical;
        public Rectangle SwordProjectileDown => GMM.GameMode.ImageAssets.SwordProjectileDown;
        public Rectangle SwordProjectileLeft => GMM.GameMode.ImageAssets.SwordProjectileLeft;
        public Rectangle SwordProjectileRight => GMM.GameMode.ImageAssets.SwordProjectileRight;
        public Rectangle SwordProjectileUp => GMM.GameMode.ImageAssets.SwordProjectileUp;

        // Room sprite sheet positions (borders and doors)
        public Rectangle EventLockedDoorDown => GMM.GameMode.ImageAssets.EventLockedDoorDown;
        public Rectangle EventLockedDoorLeft => GMM.GameMode.ImageAssets.EventLockedDoorLeft;
        public Rectangle EventLockedDoorRight => GMM.GameMode.ImageAssets.EventLockedDoorRight;
        public Rectangle EventLockedDoorUp => GMM.GameMode.ImageAssets.EventLockedDoorUp;
        public Rectangle KeyLockedDoorDown => GMM.GameMode.ImageAssets.KeyLockedDoorDown;
        public Rectangle KeyLockedDoorLeft => GMM.GameMode.ImageAssets.KeyLockedDoorLeft;
        public Rectangle KeyLockedDoorRight => GMM.GameMode.ImageAssets.KeyLockedDoorRight;
        public Rectangle KeyLockedDoorUp => GMM.GameMode.ImageAssets.KeyLockedDoorUp;
        public Rectangle Level1Border => GMM.GameMode.ImageAssets.Level1Border;
        public Rectangle SecretDoorWallDown => GMM.GameMode.ImageAssets.SecretDoorWallDown;
        public Rectangle SecretDoorWayDown => GMM.GameMode.ImageAssets.SecretDoorWayDown;
        public Rectangle SecretDoorWallLeft => GMM.GameMode.ImageAssets.SecretDoorWallLeft;
        public Rectangle SecretDoorWayLeft => GMM.GameMode.ImageAssets.SecretDoorWayLeft;
        public Rectangle SecretDoorWallRight => GMM.GameMode.ImageAssets.SecretDoorWallRight;
        public Rectangle SecretDoorWayRight => GMM.GameMode.ImageAssets.SecretDoorWayRight;
        public Rectangle SecretDoorWallUp => GMM.GameMode.ImageAssets.SecretDoorWallUp;
        public Rectangle SecretDoorWayUp => GMM.GameMode.ImageAssets.SecretDoorWayUp;
        public Rectangle UnlockedDoorWallDown => GMM.GameMode.ImageAssets.UnlockedDoorWallDown;
        public Rectangle UnlockedDoorWayDown => GMM.GameMode.ImageAssets.UnlockedDoorWayDown;
        public Rectangle UnlockedDoorWallLeft => GMM.GameMode.ImageAssets.UnlockedDoorWallLeft;
        public Rectangle UnlockedDoorWayLeft => GMM.GameMode.ImageAssets.UnlockedDoorWayLeft;
        public Rectangle UnlockedDoorWallRight => GMM.GameMode.ImageAssets.UnlockedDoorWallRight;
        public Rectangle UnlockedDoorWayRight => GMM.GameMode.ImageAssets.UnlockedDoorWayRight;
        public Rectangle UnlockedDoorWallUp => GMM.GameMode.ImageAssets.UnlockedDoorWallUp;
        public Rectangle UnlockedDoorWayUp => GMM.GameMode.ImageAssets.UnlockedDoorWayUp;
        public Rectangle WallDoorDown => GMM.GameMode.ImageAssets.WallDoorDown;
        public Rectangle WallDoorLeft => GMM.GameMode.ImageAssets.WallDoorLeft;
        public Rectangle WallDoorRight => GMM.GameMode.ImageAssets.WallDoorRight;
        public Rectangle WallDoorUp => GMM.GameMode.ImageAssets.WallDoorUp;
    }
}
