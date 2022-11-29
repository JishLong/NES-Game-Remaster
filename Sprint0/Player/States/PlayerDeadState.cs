using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameModes;
using Sprint0.Items;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Player.States
{
    public class PlayerDeadState : AbstractPlayerState
    {
        private static readonly int AnimationFrames = 4;
        private static readonly int NumSpins = 4;
        private static readonly int WaitFrames = 32;
        private readonly ISprite[] Sprites;

        private int AnimationStage;
        private int FramesPassed;
        private int CurrentSprite;

        public PlayerDeadState(Player player) : base(player)
        {
            IGameMode GameMode = GameModeManager.GetInstance().GameMode;
            Sprites = new ISprite[]
            {
                GameMode.GetPlayerSprite(this, Types.Direction.DOWN),
                GameMode.GetPlayerSprite(this, Types.Direction.LEFT),
                GameMode.GetPlayerSprite(this, Types.Direction.UP),
                GameMode.GetPlayerSprite(this, Types.Direction.RIGHT),
                new DeathParticleSprite()
            };

            Player.IsStationary = false;

            AnimationStage = 0;
            CurrentSprite = 0;
            FramesPassed = 0;
        }

        public override void Draw(SpriteBatch sb, Vector2 position)
        {
            if (AnimationStage < 3)
            {
                Sprites[CurrentSprite].Draw(sb, position, Color.White, 0.09f);
            }
        }

        public override void HoldItem(IItem item)
        {
            // Too bad you're dead
        }

        public override void Move(Types.Direction direction)
        {
            // Can't move when you're dead
        }

        public override void DoPrimaryAttack()
        {
            // Can't attack when you're dead
        }

        public override void DoSecondaryAttack()
        {
            // Can't attack when you're dead
        }

        public override void StopAction()
        {
            // Oh no you're dead
        }

        public override void Update()
        {
            FramesPassed++;
            Sprites[CurrentSprite].Update();

            switch (AnimationStage) 
            {
                // Link spins in a circle
                case 0:
                    if (FramesPassed >= AnimationFrames * Sprites.Length * NumSpins)
                    {
                        FramesPassed = 0;
                        AnimationStage++;
                    }
                    else if (FramesPassed % AnimationFrames == 0) 
                    {
                        CurrentSprite = (CurrentSprite + 1) % (Sprites.Length - 1);
                    } 
                    break;
                // Link stops spinning, we wait for a short delay
                case 1:
                    if (FramesPassed >= WaitFrames) 
                    {                     
                        CurrentSprite = Sprites.Length - 1;
                        AudioManager.GetInstance().PlayOnce(Resources.Text);
                        FramesPassed = 0;
                        AnimationStage++;
                    }                   
                    break;
                // A character death particle is shown
                case 2:
                    if (FramesPassed >= Sprites[CurrentSprite].GetAnimationTime()) 
                    {
                        FramesPassed = 0;
                        AnimationStage++;
                    }
                    break;
                // Character death particle is gone, we wait for another short delay
                case 3:
                    if (FramesPassed >= WaitFrames)
                    {
                        FramesPassed = 0;
                        AnimationStage++;
                    }
                    break;
                // Full animation is done
                default:
                    // Do nothing
                    break;
            }
        }
    }
}
