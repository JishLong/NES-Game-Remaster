using Sprint0.Player.State.Idle;
using Sprint0.Player.State;
using Sprint0.Sprites.Player.Attack.UseItem;
using Microsoft.Xna.Framework;
using Sprint0.Projectiles.Player;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Player.States.BlueArrow
{
    public class PlayerUseItemDownState : AbstractPlayerState
    {
        private readonly int UseFrames;

        public PlayerUseItemDownState(Player player) : base(player)
        {
            Sprite = new PlayerUseItemDownSprite();
            UseFrames = 20;

            SpawnProjectile();
        }

        public PlayerUseItemDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerUseItemDownSprite();
            UseFrames = 20;

            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            Types.Projectile Projectile;
            Rectangle ProjectileDrawbox;

            switch (Player.SecondaryWeapon) 
            {
                case Types.PlayerWeapon.ARROW:
                    Projectile = Types.Projectile.ARROWPROJ;
                    ProjectileDrawbox = Resources.ArrowProjVert;
                    break;
                case Types.PlayerWeapon.BLUEARROW:
                    Projectile = Types.Projectile.BLUEARROWPROJ;
                    ProjectileDrawbox = Resources.BlueArrowProjVert;
                    break;
                case Types.PlayerWeapon.BOOMERANG:
                    Projectile = Types.Projectile.PLAYERBOOMERANGPROJ;
                    ProjectileDrawbox = Resources.BoomerangProj;
                    break;
                case Types.PlayerWeapon.FLAME:
                    Projectile = Types.Projectile.FLAMEPROJ;
                    ProjectileDrawbox = Resources.FlameProj;
                    break;
                case Types.PlayerWeapon.BOMB:
                    Projectile = Types.Projectile.BOMBPROJ;
                    ProjectileDrawbox = Resources.BombProj;
                    break;
                default:
                    Projectile = Types.Projectile.SWORDMELEE;
                    ProjectileDrawbox = Rectangle.Empty;
                    break;
            }

            Rectangle ProjectileHitbox = new Rectangle(ProjectileDrawbox.X, ProjectileDrawbox.Y,
                (int)(ProjectileDrawbox.Width * Utils.GameScale), (int)(ProjectileDrawbox.Height * Utils.GameScale));
            Vector2 ProjectilePosition = Utils.LineUpEdges(GetHitbox(), ProjectileHitbox, Types.Direction.DOWN);

            ProjectileManager.GetInstance().AddProjectile(
                Projectile, ProjectilePosition, Types.Direction.DOWN, Player);
        }

        public override void Update()
        {
            base.Update();

            if (FramesPassed % UseFrames == 0)
            {
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
