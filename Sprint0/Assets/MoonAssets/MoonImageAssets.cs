using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Assets.DefaultAssets
{
    public class MoonImageAssets: IImageAssets
    {
        public virtual void LoadContent(ContentManager c)
        {
            // Sprite sheets
            BlocksSpriteSheet = c.Load<Texture2D>("Images/Moon/blocks");
            CharactersSpriteSheet = c.Load<Texture2D>("Images/Default/characters");
            CursorSpriteSheet = c.Load<Texture2D>("Images/Default/cursor");
            GuiSpriteSheet = c.Load<Texture2D>("Images/Default/gui");
            GuiElementsSpriteSheet = c.Load<Texture2D>("Images/Default/guiElements");
            Invisible = c.Load<Texture2D>("Images/Default/invisible");
            ItemsSpriteSheet = c.Load<Texture2D>("Images/Default/items");
            PlayerSpriteSheet = c.Load<Texture2D>("Images/Default/player");
            ProjectilesSpriteSheet = c.Load<Texture2D>("Images/Default/projectiles");
            RoomSpriteSheet = c.Load<Texture2D>("Images/Moon/room");

            // Block sprite sheet positions
            BlueTile = new(0, 0, 16, 16);
            BlueWall = new(16, 0, 16, 16);
            BlueStatueLeft = new(32, 0, 16, 16);
            BlueStatueRight = new(0, 16, 16, 16);
            BlueStairs = new(0, 32, 16, 16);
            BlueSand = new(16, 16, 16, 16);
            GreyBricks = new(32, 32, 16, 16);
            WhiteBars = new(16, 32, 16, 16);
            Water = new(32, 16, 16, 16);
            Sand = new(16, 32, 16, 16);
            RedSand = new(32, 32, 16, 16);
            RedStatueLeft = new(48, 32, 16, 16);
            RedStatueRight = new(64, 32, 16, 16);


            // Character sprite sheet positions
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

            // Mouse cursor sprite sheet position
            Cursor = new(0, 0, 12, 12);

            // GUI sprite sheet positions
            Hud = new(0, 176, 256, 56);
            Inventory = new(0, 0, 256, 176);

            // GUI element sprite sheet positions 
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

            // Item sprite sheet positions
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

            // Player sprite sheet positions
            PlayerDown = new(0, 0, 16, 16);
            PlayerHoldItem = new(108, 44, 14, 16);
            PlayerLeft = new(96, 0, 16, 16);
            PlayerRight = new(64, 0, 16, 16);
            PlayerSwordDown = new(0, 16, 16, 27);
            PlayerSwordLeft = new(0, 60, 27, 16);
            PlayerSwordRight = new(0, 44, 27, 16);
            PlayerSwordUp = new(64, 16, 16, 28);
            PlayerUp = new(32, 0, 16, 16);

            // Projectile sprite sheet positions
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

            // Room sprite sheet positions (borders and doors)
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

        // Sprite sheets
        public Texture2D BlocksSpriteSheet { get; protected set; }
        public Texture2D CharactersSpriteSheet { get; protected set; }
        public Texture2D CursorSpriteSheet { get; protected set; }
        public Texture2D GuiSpriteSheet { get; protected set; }
        public Texture2D GuiElementsSpriteSheet { get; protected set; }
        public Texture2D Invisible { get; protected set; }
        public Texture2D ItemsSpriteSheet { get; protected set; }
        public Texture2D PlayerSpriteSheet { get; protected set; }
        public Texture2D ProjectilesSpriteSheet { get; protected set; }
        public Texture2D RoomSpriteSheet { get; protected set; }

        // Block sprite sheet positions
        public Rectangle BlueTile { get; protected set; }
        public Rectangle BlueWall { get; protected set; }
        public Rectangle BlueStatueLeft { get; protected set; }
        public Rectangle BlueStatueRight { get; protected set; }
        public Rectangle BlueStairs { get; protected set; }
        public Rectangle BlueSand { get; protected set; }
        public Rectangle GreyBricks { get; protected set; }
        public Rectangle WhiteBars { get; protected set; }
        public Rectangle Water { get; protected set; }
        public Rectangle Sand { get; protected set; }
        public Rectangle RedSand{ get; protected set; }
        public Rectangle RedStatueLeft{ get; protected set; }
        public Rectangle RedStatueRight{ get; protected set; }

        // Character sprite sheet positions
        public Rectangle Aquamentus { get; protected set; }
        public Rectangle Bat { get; protected set; }
        public Rectangle BladeTrap { get; protected set; }
        public Rectangle DodongoDown { get; protected set; }
        public Rectangle DodongoLeft { get; protected set; }
        public Rectangle DodongoRight { get; protected set; }
        public Rectangle DodongoUp { get; protected set; }
        public Rectangle Flame { get; protected set; }
        public Rectangle Gel { get; protected set; }
        public Rectangle Hand { get; protected set; }
        public Rectangle OldMan { get; protected set; }
        public Rectangle RedGoriyaDown { get; protected set; }
        public Rectangle RedGoriyaLeft { get; protected set; }
        public Rectangle RedGoriyaRight { get; protected set; }
        public Rectangle RedGoriyaUp { get; protected set; }
        public Rectangle Skeleton { get; protected set; }
        public Rectangle Snake { get; protected set; }
        public Rectangle Zol { get; protected set; }

        // Mouse cursor sprite sheet position
        public Rectangle Cursor { get; protected set; }

        // GUI sprite sheet positions
        public Rectangle Hud { get; protected set; }
        public Rectangle Inventory { get; protected set; }

        // GUI element sprite sheet positions    
        public Rectangle HeartEmpty { get; protected set; }
        public Rectangle HeartFull { get; protected set; }
        public Rectangle HeartHalf { get; protected set; }
        public Rectangle HudMapPlayer { get; protected set; }
        public Rectangle HudMapRoom { get; protected set; }
        public Rectangle MapIconAllDoors { get; protected set; }
        public Rectangle MapIconDownDoor { get; protected set; }
        public Rectangle MapIconDownLeftDoors { get; protected set; }
        public Rectangle MapIconDownRightDoors { get; protected set; }
        public Rectangle MapIconHorizontalDoors { get; protected set; }
        public Rectangle MapIconLeftDoor { get; protected set; }
        public Rectangle MapIconNoDoors { get; protected set; }
        public Rectangle MapIconNoDownDoor { get; protected set; }
        public Rectangle MapIconNoLeftDoor { get; protected set; }
        public Rectangle MapIconNoRightDoor { get; protected set; }
        public Rectangle MapIconNoUpDoor { get; protected set; }
        public Rectangle MapIconRightDoor { get; protected set; }
        public Rectangle MapIconUpDoor { get; protected set; }
        public Rectangle MapIconUpLeftDoors { get; protected set; }
        public Rectangle MapIconUpRightDoors { get; protected set; }
        public Rectangle MapIconVerticalDoors { get; protected set; }
        public Rectangle Panel { get; protected set; }
        public Rectangle SelectedSlot { get; protected set; }
        public Rectangle ScreenCover { get; protected set; }

        // Item sprite sheet positions
        public Rectangle Arrow { get; protected set; }
        public Rectangle BlueCandle { get; protected set; }
        public Rectangle BluePotion { get; protected set; }
        public Rectangle Bomb { get; protected set; }
        public Rectangle Bow { get; protected set; }
        public Rectangle Clock { get; protected set; }
        public Rectangle Compass { get; protected set; }
        public Rectangle Fairy { get; protected set; }
        public Rectangle Heart { get; protected set; }
        public Rectangle HeartContainer { get; protected set; }
        public Rectangle Key { get; protected set; }
        public Rectangle Map { get; protected set; }
        public Rectangle Rupee { get; protected set; }
        public Rectangle TriforcePiece { get; protected set; }
        public Rectangle WoodenBoomerang { get; protected set; }

        // Player sprite sheet positions
        public Rectangle PlayerDown { get; protected set; }
        public Rectangle PlayerHoldItem { get; protected set; }
        public Rectangle PlayerLeft { get; protected set; }
        public Rectangle PlayerRight { get; protected set; }
        public Rectangle PlayerSwordDown { get; protected set; }
        public Rectangle PlayerSwordLeft { get; protected set; }
        public Rectangle PlayerSwordRight { get; protected set; }
        public Rectangle PlayerSwordUp { get; protected set; }
        public Rectangle PlayerUp { get; protected set; }

        // Projectile sprite sheet positions
        public Rectangle ArrowExplosionProjectile { get; protected set; }
        public Rectangle ArrowProjectileDown { get; protected set; }
        public Rectangle ArrowProjectileLeft { get; protected set; }
        public Rectangle ArrowProjectileRight { get; protected set; }
        public Rectangle ArrowProjectileUp { get; protected set; }
        public Rectangle BlueArrowProjectileDown { get; protected set; }
        public Rectangle BlueArrowProjectileLeft { get; protected set; }
        public Rectangle BlueArrowProjectileRight { get; protected set; }
        public Rectangle BlueArrowProjectileUp { get; protected set; }
        public Rectangle BombExplosionProjectile { get; protected set; }
        public Rectangle BombProjectile { get; protected set; }
        public Rectangle BoomerangProjectile { get; protected set; }
        public Rectangle BossProjectile { get; protected set; }
        public Rectangle CharacterDeathProjectile { get; protected set; }
        public Rectangle FlameProjectile { get; protected set; }
        public Rectangle SwordFlameProjectileDownLeft { get; protected set; }
        public Rectangle SwordFlameProjectileDownRight { get; protected set; }
        public Rectangle SwordFlameProjectileUpLeft { get; protected set; }
        public Rectangle SwordFlameProjectileUpRight { get; protected set; }
        public Rectangle SwordMeleeHorizontal { get; protected set; }
        public Rectangle SwordMeleeVertical { get; protected set; }
        public Rectangle SwordProjectileDown { get; protected set; }
        public Rectangle SwordProjectileLeft { get; protected set; }
        public Rectangle SwordProjectileRight { get; protected set; }
        public Rectangle SwordProjectileUp { get; protected set; }

        // Room sprite sheet positions (borders and doors)
        public Rectangle EventLockedDoorDown { get; protected set; }
        public Rectangle EventLockedDoorLeft { get; protected set; }
        public Rectangle EventLockedDoorRight { get; protected set; }
        public Rectangle EventLockedDoorUp { get; protected set; }
        public Rectangle KeyLockedDoorDown { get; protected set; }
        public Rectangle KeyLockedDoorLeft { get; protected set; }
        public Rectangle KeyLockedDoorRight { get; protected set; }
        public Rectangle KeyLockedDoorUp { get; protected set; }
        public Rectangle Level1Border { get; protected set; }
        public Rectangle SecretDoorWallDown { get; protected set; }
        public Rectangle SecretDoorWayDown { get; protected set; }
        public Rectangle SecretDoorWallLeft { get; protected set; }
        public Rectangle SecretDoorWayLeft { get; protected set; }
        public Rectangle SecretDoorWallRight { get; protected set; }
        public Rectangle SecretDoorWayRight { get; protected set; }
        public Rectangle SecretDoorWallUp { get; protected set; }
        public Rectangle SecretDoorWayUp { get; protected set; }
        public Rectangle UnlockedDoorWallDown { get; protected set; }
        public Rectangle UnlockedDoorWayDown { get; protected set; }
        public Rectangle UnlockedDoorWallLeft { get; protected set; }
        public Rectangle UnlockedDoorWayLeft { get; protected set; }
        public Rectangle UnlockedDoorWallRight { get; protected set; }
        public Rectangle UnlockedDoorWayRight { get; protected set; }
        public Rectangle UnlockedDoorWallUp { get; protected set; }
        public Rectangle UnlockedDoorWayUp { get; protected set; }
        public Rectangle WallDoorDown { get; protected set; }
        public Rectangle WallDoorLeft { get; protected set; }
        public Rectangle WallDoorRight { get; protected set; }
        public Rectangle WallDoorUp { get; protected set; }
    }
}
