using Sprint0.Items;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player.Stationary;
using Sprint0.Commands;
using Sprint0.Sprites.GoombaMode.Goomba;
using Microsoft.Xna.Framework.Audio;
using Sprint0.Sprites;

namespace Sprint0.Player.States
{
    public class PlayerGoombaTransitionState : AbstractPlayerState
    {  
        private static readonly int FlashingFrames = 7;
        private static readonly int NumFlashes = 6;
        private readonly ISprite PrevSprite;
        private readonly ISprite NewSprite;
        private readonly SoundEffect PowerUpAudio;
        private readonly SoundEffect NewMusic;

        private int FramesPassed;
        private int FlashesPassed;

       

        public PlayerGoombaTransitionState(Player player, ISprite prevSprite) : base(player)
        {
            PrevSprite = prevSprite;
            Sprite = prevSprite;

            if (Player.Gamemode == Types.Gamemode.GOOMBAMODE)
            {
                PowerUpAudio = Resources.MarioPowerUp;
                NewMusic = Resources.MarioMusic;
                NewSprite = new GoombaIdleSprite();
            }
            else 
            { 
                PowerUpAudio = Resources.MarioPowerDown;
                NewMusic = Resources.DungeonMusic;
                switch (Player.FacingDirection)
                {
                    case Types.Direction.UP:
                        NewSprite = new PlayerIdleUpSprite();
                        break;
                    case Types.Direction.LEFT:
                        NewSprite = new PlayerIdleLeftSprite();
                        break;
                    case Types.Direction.RIGHT:
                        NewSprite = new PlayerIdleRightSprite();
                        break;
                    default:
                        NewSprite = new PlayerIdleDownSprite();
                        break;

                }
            }

            FramesPassed = 0;
            FlashesPassed = 0;
        }

        public override void Capture(ICommand goToBeginningCommand)
        {
            // Nothing happens; goomba transition effect must complete itself
        }

        public override Rectangle GetHitbox()
        {
            return Rectangle.Empty;
        }

        public override void Update()
        {
            base.Update();

            if (FramesPassed == 0) AudioManager.GetInstance().PlayOnce(PowerUpAudio);
            
            FramesPassed++;

            if (FramesPassed % FlashingFrames == 0)
            {
                if (Sprite == NewSprite) Sprite = PrevSprite;
                else if (Sprite == PrevSprite) Sprite = NewSprite;

                FlashesPassed++;
                if (FlashesPassed > NumFlashes) 
                {
                    AudioManager.GetInstance().StopAudio();
                    AudioManager.GetInstance().PlayLooped(NewMusic);
                    Sprite = NewSprite;
                    Player.State = new PlayerIdleState(Player);
                }
            }
        }

        public override void Move(Types.Direction direction)
        {
            // Nothing happens; goomba transition effect must complete itself
        }

        public override void StopAction()
        {
            // Nothing happens; goomba transition effect must complete itself
        }

        public override void DoPrimaryAttack()
        {
            // Nothing happens; goomba transition effect must complete itself
        }

        public override void DoSecondaryAttack()
        {
            // Nothing happens; goomba transition effect must complete itself
        }

        public override void HoldItem(IItem item)
        {
            // Nothing happens; goomba transition effect must complete itself
        }
    }
}
