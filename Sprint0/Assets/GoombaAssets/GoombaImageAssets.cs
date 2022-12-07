using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.GoombaAssets
{
    public class GoombaImageAssets : DefaultImageAssets
    {
        public override void LoadContent(ContentManager c)
        {
            // Sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("Images/Goomba/blocks");
            CharactersSpriteSheet = c.Load<Texture2D>("Images/Goomba/characters");
            CursorSpriteSheet = c.Load<Texture2D>("Images/Goomba/cursor");
            GuiSpriteSheet = c.Load<Texture2D>("Images/Goomba/gui");
            GuiElementsSpriteSheet = c.Load<Texture2D>("Images/Goomba/guiElements");
            ItemsSpriteSheet = c.Load<Texture2D>("Images/Goomba/items");
            PlayerSpriteSheet = c.Load<Texture2D>("Images/Goomba/player");
            ProjectilesSpriteSheet = c.Load<Texture2D>("Images/Goomba/projectiles");
            RoomSpriteSheet = c.Load<Texture2D>("Images/Goomba/room");

            // Sprite sheet positions for blocks
            BlueTile = new(0, 0, 16, 16);
            BlueWall = new(16, 0, 16, 16);
            BlueStatueLeft = new(32, 0, 16, 16);
            BlueStatueRight = new(32, 0, 16, 16);
            BlueStairs = new(32, 16, 16, 16);
            BlueSand = BlueTile;
            GreyBricks = new(0, 16, 16, 16);
            WhiteBars = new(48, 16, 16, 16);
            Water = new(16, 16, 16, 16);

            // Sprite sheet positions for characters
            Aquamentus = new(0, 48, 16, 32);
            Bat = new(0, 32, 16, 16);
            BladeTrap = new(0, 112, 16, 16);
            DodongoDown = new(0, 32, 16, 16);
            DodongoLeft = new(0, 16, 16, 16);
            DodongoRight = new(0, 0, 16, 16);
            DodongoUp = new(32, 32, 16, 16);
            Flame = new(16, 112, 16, 16);
            Gel = Bat;
            Hand = Bat;
            OldMan = new(48, 112, 22, 22);
            RedGoriyaDown = DodongoDown;
            RedGoriyaLeft = DodongoLeft;
            RedGoriyaRight = DodongoRight;
            RedGoriyaUp = DodongoUp;
            Skeleton = Bat;
            Snake = DodongoRight;
            Zol = new(0, 80, 16, 32);

            // Sprite sheet positions for mouse cursor
            Cursor = new(0, 0, 12, 12);

            // Sprite sheet positions for GUI
            Hud = new(0, 176, 256, 56);
            Inventory = new(0, 0, 256, 176);

            // Sprite sheet positions for gui elements     
            HeartEmpty = new(64, 102, 8, 8);
            HeartFull = new(80, 102, 8, 8);
            HeartHalf = new(72, 102, 8, 8);
            HudMapPlayer = new(95, 102, 3, 3);
            HudMapRoom = new(88, 102, 7, 3);
            MapIconAllDoors = new(8, 102, 8, 8);
            MapIconDownDoor = new(24, 110, 8, 8);
            MapIconDownLeftDoors = new(16, 118, 8, 8);
            MapIconDownRightDoors = new(24, 118, 8, 8);
            MapIconHorizontalDoors = new(16, 102, 8, 8);
            MapIconLeftDoor = new(0, 110, 8, 8);
            MapIconNoDoors = new(0, 102, 8, 8);
            MapIconNoDownDoor = new(0, 126, 8, 8);
            MapIconNoLeftDoor = new(24, 126, 8, 8);
            MapIconNoRightDoor = new(16, 126, 8, 8);
            MapIconNoUpDoor = new(8, 126, 8, 8);
            MapIconRightDoor = new(8, 110, 8, 8);
            MapIconUpDoor = new(16, 110, 8, 8);
            MapIconUpLeftDoors = new(0, 118, 8, 8);
            MapIconUpRightDoors = new(8, 118, 8, 8);
            MapIconVerticalDoors = new(24, 102, 8, 8);
            Panel = new(0, 0, 206, 102);
            SelectedSlot = new(32, 102, 16, 16);
            ScreenCover = new(98, 102, 16, 16);

            // Sprite sheet positions for items
            Arrow = new(66, 0, 12, 8);
            BlueCandle = new(105, 0, 16, 16);
            BluePotion = new(121, 0, 8, 16);
            Bomb = new(78, 0, 16, 16);
            Bow = new(58, 0, 8, 16);
            Clock = new(94, 0, 11, 16);
            Compass = new(0, 0, 11, 12);
            Fairy = new(0, 16, 16, 16);
            Heart = new(129, 0, 16, 16);
            HeartContainer = new(33, 0, 16, 16);
            Key = new(19, 0, 14, 16);
            Map = new(11, 0, 8, 16);
            Rupee = new(32, 16, 10, 14);
            TriforcePiece = new(145, 0, 16, 16);
            WoodenBoomerang = new(49, 0, 9, 16);

            // Sprite sheet positions for player
            PlayerDown = new(0, 0, 16, 16);
            PlayerHoldItem = PlayerDown;
            PlayerLeft = PlayerDown;
            PlayerRight = PlayerDown;
            PlayerSwordDown = PlayerDown;
            PlayerSwordLeft = PlayerDown;
            PlayerSwordRight = PlayerDown;
            PlayerSwordUp = PlayerDown;
            PlayerUp = PlayerDown;

            // Sprite sheet positions for projectiles
            ArrowExplosionProjectile = new(0, 32, 16, 16);
            ArrowProjectileDown = new(32, 8, 8, 12);
            ArrowProjectileLeft = new(0, 8, 12, 8);
            ArrowProjectileRight = new(12, 8, 12, 8);
            ArrowProjectileUp = new(24, 8, 8, 12);
            BlueArrowProjectileDown = ArrowProjectileDown;
            BlueArrowProjectileLeft = ArrowProjectileLeft;
            BlueArrowProjectileRight = ArrowProjectileRight;
            BlueArrowProjectileUp = ArrowProjectileUp;
            BombExplosionProjectile = ArrowExplosionProjectile;
            BombProjectile = new(0, 16, 16, 16);
            BoomerangProjectile = new(0, 48, 16, 16);
            BossProjectile = new(0, 0, 8, 8);
            CharacterDeathProjectile = ArrowExplosionProjectile;
            FlameProjectile = new(16, 32, 16, 16);
            SwordFlameProjectileDownLeft = BossProjectile;
            SwordFlameProjectileDownRight = BossProjectile;
            SwordFlameProjectileUpLeft = BossProjectile;
            SwordFlameProjectileUpRight = BossProjectile;
            SwordMeleeHorizontal = new(49, 1, 12, 7);
            SwordMeleeVertical = new(41, 1, 7, 12);
            SwordProjectileDown = new(56, 20, 10, 10);
            SwordProjectileLeft = new(16, 20, 10, 10);
            SwordProjectileRight = SwordProjectileLeft;
            SwordProjectileUp = SwordProjectileDown;

            // Sprite sheet positions for the room (borders and doors)
            EventLockedDoorDown = new(99, 276, 32, 32);
            EventLockedDoorLeft = new(99, 210, 32, 32);
            EventLockedDoorRight = new(99, 243, 32, 32);
            EventLockedDoorUp = new(99, 177, 32, 32);
            KeyLockedDoorDown = new(66, 276, 32, 32);
            KeyLockedDoorLeft = new(66, 210, 32, 32);
            KeyLockedDoorRight = new(66, 243, 32, 32);
            KeyLockedDoorUp = new(66, 177, 32, 32);
            Level1Border = new(0, 0, 256, 176);
            SecretDoorWallDown = new(132, 292, 32, 16);
            SecretDoorWayDown = new(132, 276, 32, 16);
            SecretDoorWallLeft = new(132, 210, 16, 32);
            SecretDoorWayLeft = new(148, 210, 16, 32);
            SecretDoorWallRight = new(148, 243, 16, 32);
            SecretDoorWayRight = new(132, 243, 16, 32);
            SecretDoorWallUp = new(132, 177, 32, 16);
            SecretDoorWayUp = new(132, 193, 32, 16);
            UnlockedDoorWallDown = new(33, 292, 32, 16);
            UnlockedDoorWayDown = new(33, 276, 32, 16);
            UnlockedDoorWallLeft = new(33, 210, 16, 32);
            UnlockedDoorWayLeft = new(49, 210, 16, 32);
            UnlockedDoorWallRight = new(49, 243, 16, 32);
            UnlockedDoorWayRight = new(33, 243, 16, 32);
            UnlockedDoorWallUp = new(33, 177, 32, 16);
            UnlockedDoorWayUp = new(33, 193, 32, 16);
            WallDoorDown = new(0, 276, 32, 32);
            WallDoorLeft = new(0, 210, 32, 32);
            WallDoorRight = new(0, 243, 32, 32);
            WallDoorUp = new(0, 177, 32, 32);
        }
    }
}
