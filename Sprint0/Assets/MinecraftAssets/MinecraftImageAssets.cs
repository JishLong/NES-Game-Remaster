using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets.DefaultAssets;

namespace Sprint0.Assets.MinecraftAssets
{
    public class MinecraftImageAssets : DefaultImageAssets
    {
        public override void LoadContent(ContentManager c)
        {
            // Sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("Images/Minecraft/blocks");
            CharactersSpriteSheet = c.Load<Texture2D>("Images/Minecraft/characters");
            CursorSpriteSheet = c.Load<Texture2D>("Images/Minecraft/cursor");
            GuiSpriteSheet = c.Load<Texture2D>("Images/Minecraft/gui");
            GuiElementsSpriteSheet = c.Load<Texture2D>("Images/Minecraft/guiElements");
            ItemsSpriteSheet = c.Load<Texture2D>("Images/Minecraft/items");
            PlayerSpriteSheet = c.Load<Texture2D>("Images/Minecraft/player");
            ProjectilesSpriteSheet = c.Load<Texture2D>("Images/Minecraft/projectiles");
            RoomSpriteSheet = c.Load<Texture2D>("Images/Minecraft/room");

            // Sprite sheet positions for blocks
            BlueTile = new(0, 0, 16, 16);
            BlueWall = new(16, 0, 16, 16);
            BlueStatueLeft = new(32, 0, 16, 16);
            BlueStatueRight = new(32, 0, 16, 16);
            BlueStairs = new(0, 16, 16, 16);
            BlueSand = BlueTile;
            GreyBricks = new(64, 0, 16, 16);
            WhiteBars = new(48, 0, 16, 16);
            Water = new(0, 32, 16, 16);
            Sand = BlueSand;
            RedSand = BlueSand;
            RedStatueLeft = BlueStatueLeft;
            RedStatueRight = BlueStatueRight;

            // Sprite sheet positions for characters
            Aquamentus = new(50, 48, 26, 24);
            Bat = new(30, 0, 16, 12);
            BladeTrap = new(0, 90, 16, 16);
            DodongoDown = new(104, 32, 14, 16);
            DodongoLeft = new(52, 32, 26, 16);
            DodongoRight = new(0, 32, 26, 16);
            DodongoUp = new(132, 32, 14, 16);
            Flame = new(0, 74, 16, 16);
            Gel = new(94, 0, 10, 10);
            Hand = new(0, 48, 25, 26);
            OldMan = new(144, 0, 16, 16);
            RedGoriyaDown = new(64, 16, 14, 16);
            RedGoriyaLeft = new(32, 16, 16, 16);
            RedGoriyaRight = new(0, 16, 16, 16);
            RedGoriyaUp = new(92, 16, 14, 16);
            Skeleton = new(0, 0, 14, 16);
            Snake = new(114, 0, 15, 16);
            Zol = new(62, 0, 16, 16);

            // Sprite sheet positions for mouse cursor
            Cursor = new(0, 0, 9, 9);

            // Sprite sheet positions for GUI
            Hud = new(0, 176, 256, 56);
            Inventory = new(0, 0, 256, 176);

            // Sprite sheet positions for gui elements     
            HeartEmpty = new(56, 102, 9, 9);
            HeartFull = new(65, 102, 9, 9);
            HeartHalf = new(74, 102, 9, 9);
            HudMapPlayer = new(90, 102, 4, 4);
            HudMapRoom = new(83, 102, 7, 3);
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
            SelectedSlot = new(32, 102, 24, 24);
            ScreenCover = new(94, 102, 16, 16);

            // Sprite sheet positions for items
            Arrow = new(80, 0, 16, 16);
            BlueCandle = new(112, 0, 16, 16);
            BluePotion = new(128, 0, 16, 16);
            Bomb = new(96, 0, 16, 16);
            Bow = new(64, 0, 16, 16);
            Clock = new(64, 16, 16, 16);
            Compass = new(0, 16, 16, 16);
            Fairy = new(128, 16, 16, 16);
            Heart = new(144, 0, 16, 16);
            HeartContainer = new(32, 0, 16, 16);
            Key = new(16, 0, 16, 16);
            Map = new(0, 0, 16, 16);
            Rupee = new(160, 0, 16, 16);
            TriforcePiece = new(176, 0, 16, 16);
            WoodenBoomerang = new(48, 0, 16, 16);

            // Sprite sheet positions for player
            PlayerDown = new(0, 0, 16, 16);
            PlayerHoldItem = new(108, 44, 14, 16);
            PlayerLeft = new(96, 0, 16, 16);
            PlayerRight = new(64, 0, 16, 16);
            PlayerSwordDown = new(0, 16, 16, 27);
            PlayerSwordLeft = new(0, 60, 27, 16);
            PlayerSwordRight = new(0, 44, 27, 16);
            PlayerSwordUp = new(64, 16, 16, 28);
            PlayerUp = new(32, 0, 16, 16);

            // Sprite sheet positions for projectiles
            ArrowExplosionProjectile = new(0, 48, 7, 7);
            ArrowProjectileDown = new(4, 0, 4, 16);
            ArrowProjectileLeft = new(8, 4, 16, 4);
            ArrowProjectileRight = new(8, 0, 16, 4);
            ArrowProjectileUp = new(0, 0, 4, 16);
            BlueArrowProjectileDown = ArrowProjectileDown;
            BlueArrowProjectileLeft = ArrowProjectileLeft;
            BlueArrowProjectileRight = ArrowProjectileRight;
            BlueArrowProjectileUp = ArrowProjectileUp;
            BombExplosionProjectile = new(16, 48, 16, 16);
            BombProjectile = new(24, 0, 16, 16);
            BoomerangProjectile = new(0, 16, 16, 16);
            BossProjectile = new(0, 96, 16, 10);
            CharacterDeathProjectile = new(0, 64, 16, 16);
            FlameProjectile = new(0, 80, 16, 16);
            SwordFlameProjectileDownLeft = ArrowExplosionProjectile;
            SwordFlameProjectileDownRight = ArrowExplosionProjectile;
            SwordFlameProjectileUpLeft = ArrowExplosionProjectile;
            SwordFlameProjectileUpRight = ArrowExplosionProjectile;
            SwordMeleeHorizontal = new(73, 97, 12, 7);
            SwordMeleeVertical = new(65, 97, 7, 12);
            SwordProjectileDown = new(16, 32, 8, 16);
            SwordProjectileLeft = new(32, 40, 16, 8);
            SwordProjectileRight = new(32, 32, 16, 8);
            SwordProjectileUp = new(0, 32, 8, 16);

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
