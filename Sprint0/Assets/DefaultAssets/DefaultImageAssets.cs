using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets.DefaultAssets
{
    public class DefaultImageAssets : IImageAssets
    {
        // Sprite sheets
        public Texture2D BlocksSpriteSheet { get; private set; }
        public Texture2D CharactersSpriteSheet { get; private set; }
        public Texture2D CursorSpriteSheet { get; private set; }
        public Texture2D GuiSpriteSheet { get; private set; }
        public Texture2D GuiElementsSpriteSheet { get; private set; }
        public Texture2D Invisible { get; private set; }
        public Texture2D ItemsSpriteSheet { get; private set; }
        public Texture2D PlayerSpriteSheet { get; private set; }
        public Texture2D ProjectilesSpriteSheet { get; private set; }
        public Texture2D RoomSpriteSheet { get; private set; }

        // Sprite sheet positions for blocks
        public Rectangle BlueTile { get; private set; }
        public Rectangle BlueWall { get; private set; }
        public Rectangle BlueStatueLeft { get; private set; }
        public Rectangle BlueStatueRight { get; private set; }
        public Rectangle BlueStairs { get; private set; }
        public Rectangle BlueSand { get; private set; }
        public Rectangle GreyBricks { get; private set; }
        public Rectangle WhiteBars { get; private set; }
        public Rectangle Water { get; private set; }

        // Sprite sheet positions for characters
        public Rectangle Aquamentus { get; private set; }
        public Rectangle Bat { get; private set; }
        public Rectangle BladeTrap { get; private set; }
        public Rectangle DodongoDown { get; private set; }
        public Rectangle DodongoLeft { get; private set; }
        public Rectangle DodongoRight { get; private set; }
        public Rectangle DodongoUp { get; private set; }
        public Rectangle Flame { get; private set; }
        public Rectangle Gel { get; private set; }
        public Rectangle Hand { get; private set; }
        public Rectangle OldMan { get; private set; }
        public Rectangle RedGoriyaDown { get; private set; }
        public Rectangle RedGoriyaLeft { get; private set; }
        public Rectangle RedGoriyaRight { get; private set; }
        public Rectangle RedGoriyaUp { get; private set; }
        public Rectangle Skeleton { get; private set; }
        public Rectangle Snake { get; private set; }
        public Rectangle Zol { get; private set; }

        // Sprite sheet positions for mouse cursor
        public Rectangle Cursor { get; private set; }

        // Sprite sheet positions for GUI
        public Rectangle Hud { get; private set; }
        public Rectangle Inventory { get; private set; }

        // Sprite sheet positions for gui elements     
        public Rectangle HeartEmpty { get; private set; }
        public Rectangle HeartFull { get; private set; }
        public Rectangle HeartHalf { get; private set; }
        public Rectangle HudMapPlayer { get; private set; }
        public Rectangle HudMapRoom { get; private set; }
        public Rectangle MapIconAllDoors { get; private set; }
        public Rectangle MapIconDownDoor { get; private set; }
        public Rectangle MapIconDownLeftDoors { get; private set; }
        public Rectangle MapIconDownRightDoors { get; private set; }
        public Rectangle MapIconHorizontalDoors { get; private set; }
        public Rectangle MapIconLeftDoor { get; private set; }
        public Rectangle MapIconNoDoors { get; private set; }
        public Rectangle MapIconNoDownDoor { get; private set; }
        public Rectangle MapIconNoLeftDoor { get; private set; }
        public Rectangle MapIconNoRightDoor { get; private set; }
        public Rectangle MapIconNoUpDoor { get; private set; }
        public Rectangle MapIconRightDoor { get; private set; }
        public Rectangle MapIconUpDoor { get; private set; }
        public Rectangle MapIconUpLeftDoors { get; private set; }
        public Rectangle MapIconUpRightDoors { get; private set; }
        public Rectangle MapIconVerticalDoors { get; private set; }
        public Rectangle Panel { get; private set; }
        public Rectangle SelectedSlot { get; private set; }
        public Rectangle ScreenCover { get; private set; }

        // Sprite sheet positions for items
        public Rectangle Arrow { get; private set; }
        public Rectangle BlueCandle { get; private set; }
        public Rectangle BluePotion { get; private set; }
        public Rectangle Bomb { get; private set; }
        public Rectangle Bow { get; private set; }
        public Rectangle Clock { get; private set; }
        public Rectangle Compass { get; private set; }
        public Rectangle Fairy { get; private set; }
        public Rectangle Heart { get; private set; }
        public Rectangle HeartContainer { get; private set; }
        public Rectangle Key { get; private set; }
        public Rectangle Map { get; private set; }
        public Rectangle Rupee { get; private set; }
        public Rectangle TriforcePiece { get; private set; }
        public Rectangle WoodenBoomerang { get; private set; }

        // Sprite sheet positions for player
        public Rectangle PlayerDown { get; private set; }
        public Rectangle PlayerHoldItem { get; private set; }
        public Rectangle PlayerLeft { get; private set; }
        public Rectangle PlayerRight { get; private set; }
        public Rectangle PlayerSwordDown { get; private set; }
        public Rectangle PlayerSwordLeft { get; private set; }
        public Rectangle PlayerSwordRight { get; private set; }
        public Rectangle PlayerSwordUp { get; private set; }
        public Rectangle PlayerUp { get; private set; }

        // Sprite sheet positions for projectiles
        public Rectangle ArrowExplosionProjectile { get; private set; }
        public Rectangle ArrowProjectileDown { get; private set; }
        public Rectangle ArrowProjectileLeft { get; private set; }
        public Rectangle ArrowProjectileRight { get; private set; }
        public Rectangle ArrowProjectileUp { get; private set; }
        public Rectangle BlueArrowProjectileDown { get; private set; }
        public Rectangle BlueArrowProjectileLeft { get; private set; }
        public Rectangle BlueArrowProjectileRight { get; private set; }
        public Rectangle BlueArrowProjectileUp { get; private set; }
        public Rectangle BombExplosionProjectile { get; private set; }
        public Rectangle BombProjectile { get; private set; }
        public Rectangle BoomerangProjectile { get; private set; }
        public Rectangle BossProjectile { get; private set; }
        public Rectangle CharacterDeathProjectile { get; private set; }
        public Rectangle FlameProjectile { get; private set; }
        public Rectangle SwordFlameProjectileDownLeft { get; private set; }
        public Rectangle SwordFlameProjectileDownRight { get; private set; }
        public Rectangle SwordFlameProjectileUpLeft { get; private set; }
        public Rectangle SwordFlameProjectileUpRight { get; private set; }
        public Rectangle SwordMeleeHorizontal { get; private set; }
        public Rectangle SwordMeleeVertical { get; private set; }
        public Rectangle SwordProjectileDown { get; private set; }
        public Rectangle SwordProjectileLeft { get; private set; }
        public Rectangle SwordProjectileRight { get; private set; }
        public Rectangle SwordProjectileUp { get; private set; }

        // Sprite sheet positions for the room (borders and doors)
        public Rectangle EventLockedDoorDown { get; private set; }
        public Rectangle EventLockedDoorLeft { get; private set; }
        public Rectangle EventLockedDoorRight { get; private set; }
        public Rectangle EventLockedDoorUp { get; private set; }
        public Rectangle KeyLockedDoorDown { get; private set; }
        public Rectangle KeyLockedDoorLeft { get; private set; }
        public Rectangle KeyLockedDoorRight { get; private set; }
        public Rectangle KeyLockedDoorUp { get; private set; }
        public Rectangle Level1Border { get; private set; }
        public Rectangle SecretDoorWallDown { get; private set; }
        public Rectangle SecretDoorWayDown { get; private set; }
        public Rectangle SecretDoorWallLeft { get; private set; }
        public Rectangle SecretDoorWayLeft { get; private set; }
        public Rectangle SecretDoorWallRight { get; private set; }
        public Rectangle SecretDoorWayRight { get; private set; }
        public Rectangle SecretDoorWallUp { get; private set; }
        public Rectangle SecretDoorWayUp { get; private set; }
        public Rectangle UnlockedDoorWallDown { get; private set; }
        public Rectangle UnlockedDoorWayDown { get; private set; }
        public Rectangle UnlockedDoorWallLeft { get; private set; }
        public Rectangle UnlockedDoorWayLeft { get; private set; }
        public Rectangle UnlockedDoorWallRight { get; private set; }
        public Rectangle UnlockedDoorWayRight { get; private set; }
        public Rectangle UnlockedDoorWallUp { get; private set; }
        public Rectangle UnlockedDoorWayUp { get; private set; }
        public Rectangle WallDoorDown { get; private set; }
        public Rectangle WallDoorLeft { get; private set; }
        public Rectangle WallDoorRight { get; private set; }
        public Rectangle WallDoorUp { get; private set; }

        public void LoadContent(ContentManager c)
        {
            // Sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("Images/Default/blocks");
            CharactersSpriteSheet = c.Load<Texture2D>("Images/Default/characters");
            CursorSpriteSheet = c.Load<Texture2D>("Images/Default/cursor");
            GuiSpriteSheet = c.Load<Texture2D>("Images/Default/gui");
            GuiElementsSpriteSheet = c.Load<Texture2D>("Images/Default/guiElements");
            Invisible = c.Load<Texture2D>("Images/Default/invisible");
            ItemsSpriteSheet = c.Load<Texture2D>("Images/Default/items");
            PlayerSpriteSheet = c.Load<Texture2D>("Images/Default/player");
            ProjectilesSpriteSheet = c.Load<Texture2D>("Images/Default/projectiles");
            RoomSpriteSheet = c.Load<Texture2D>("Images/Default/room");

            // Sprite sheet positions for blocks
            BlueTile = new(0, 0, 16, 16);
            BlueWall = new(16, 0, 16, 16);
            BlueStatueLeft = new(32, 0, 16, 16);
            BlueStatueRight = new(0, 16, 16, 16);
            BlueStairs = new(0, 32, 16, 16);
            BlueSand = new(16, 16, 16, 16);
            GreyBricks = new(32, 32, 16, 16);
            WhiteBars = new(16, 32, 16, 16);
            Water = new(32, 16, 16, 16);

            // Sprite sheet positions for characters
            Aquamentus = new(0, 48, 24, 32);
            Bat = new(0, 0, 16, 10);
            BladeTrap = new(96, 48, 16, 16);
            DodongoDown = new(0, 32, 15, 16);
            DodongoLeft = new(116, 32, 28, 16);
            DodongoRight = new(60, 32, 28, 16);
            DodongoUp = new(30, 32, 15, 16);
            Flame = new(112, 48, 16, 16);
            Gel = new(32, 0, 8, 9);
            Hand = new(48, 0, 16, 16);
            OldMan = new(144, 48, 16, 16);
            RedGoriyaDown = new(0, 16, 13, 16);
            RedGoriyaLeft = new(78, 16, 13, 16);
            RedGoriyaRight = new(52, 16, 13, 16);
            RedGoriyaUp = new(26, 16, 13, 16);
            Skeleton = new(80, 0, 15, 16);
            Snake = new(104, 16, 15, 15);
            Zol = new(110, 0, 14, 16);

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
            Arrow = new(53, 0, 5, 16);
            BlueCandle = new(77, 0, 8, 16);
            BluePotion = new(85, 0, 8, 16);
            Bomb = new(58, 0, 8, 14);
            Bow = new(45, 0, 8, 16);
            Clock = new(66, 0, 11, 16);
            Compass = new(0, 0, 11, 12);
            Fairy = new(0, 16, 8, 16);
            Heart = new(16, 16, 7, 8);
            HeartContainer = new(27, 0, 13, 13);
            Key = new(19, 0, 8, 16);
            Map = new(11, 0, 8, 16);
            Rupee = new(30, 16, 8, 16);
            TriforcePiece = new(46, 16, 10, 10);
            WoodenBoomerang = new(40, 0, 5, 8);

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
            ArrowExplosionProjectile = new(52, 26, 7, 8);
            ArrowProjectileDown = new(10, 26, 5, 16);
            ArrowProjectileLeft = new(36, 26, 16, 5);
            ArrowProjectileRight = new(20, 26, 16, 5);
            ArrowProjectileUp = new(0, 26, 5, 16);
            BlueArrowProjectileDown = new(15, 26, 5, 16);
            BlueArrowProjectileLeft = new(36, 31, 16, 5);
            BlueArrowProjectileRight = new(20, 31, 16, 5);
            BlueArrowProjectileUp = new(5, 26, 5, 16);
            BombExplosionProjectile = new(0, 72, 16, 16);
            BombProjectile = new(0, 42, 8, 14);
            BoomerangProjectile = new(8, 42, 8, 8);
            BossProjectile = new(22, 58, 8, 10);
            CharacterDeathProjectile = new(0, 88, 15, 16);
            FlameProjectile = new(32, 42, 16, 16);
            SwordFlameProjectileDownLeft = new(16, 16, 8, 10);
            SwordFlameProjectileDownRight = new(48, 16, 8, 10);
            SwordFlameProjectileUpLeft = new(0, 16, 8, 10);
            SwordFlameProjectileUpRight = new(32, 16, 8, 10);
            SwordMeleeHorizontal = new(69, 32, 12, 7);
            SwordMeleeVertical = new(61, 32, 7, 12);
            SwordProjectileDown = new(14, 0, 7, 16);
            SwordProjectileLeft = new(28, 7, 16, 7);
            SwordProjectileRight = new(28, 0, 16, 7);
            SwordProjectileUp = new(0, 0, 7, 16);

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
