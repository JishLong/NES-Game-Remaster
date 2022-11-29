using Sprint0.Items;
using Microsoft.Xna.Framework;
using Sprint0.Commands;
using Sprint0.GameModes;

namespace Sprint0.Player.States
{
    public class PlayerGameModeTransitionState : AbstractPlayerState
    {  
        private static readonly int FlashingFrames = 7;
        private static readonly int NumFlashes = 6;
        private readonly IGameMode OldGameMode;
        private readonly IGameMode NewGameMode;

        private int FramesPassed;
        private int FlashesPassed;

        public PlayerGameModeTransitionState(Player player, IGameMode oldGameMode, IGameMode newGameMode) : base(player)
        {
            OldGameMode = oldGameMode;
            NewGameMode = newGameMode;

            Sprite = oldGameMode.GetPlayerSprite(this, Player.FacingDirection);
            Player.GameMode = newGameMode.Type;

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

            if (FramesPassed == 0) AudioManager.GetInstance().PlayOnce(NewGameMode.TransitionSound);
            
            FramesPassed++;

            if (FramesPassed % FlashingFrames == 0)
            {
                if (FlashesPassed % 2 == 0) Sprite = NewGameMode.GetPlayerSprite(this, Player.FacingDirection);
                else Sprite = OldGameMode.GetPlayerSprite(this, Player.FacingDirection);

                FlashesPassed++;
                if (FlashesPassed > NumFlashes) 
                {
                    AudioManager.GetInstance().StopAudio();
                    AudioManager.GetInstance().PlayLooped(NewGameMode.GameModeMusic);
                    Sprite = NewGameMode.GetPlayerSprite(this, Player.FacingDirection);
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
