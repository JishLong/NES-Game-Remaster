using Microsoft.Xna.Framework.Audio;
using Sprint0.Characters;
using Sprint0.Player.States;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Sprites.GoombaMode;
using Sprint0.Sprites.GoombaMode.Goomba;
using Sprint0.Sprites.GoombaMode.HammerBro;
using Sprint0.Sprites.GoombaMode.Mario;
using Sprint0.Sprites.GoombaMode.Parakoopa;
using Sprint0.Sprites.Player.Attack.SwordAttack;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Sprites.Player.Movement;
using Sprint0.Sprites.Player.Stationary;
using Sprint0.Sprites.Projectiles.Player;
using System;
using static Sprint0.Types;

namespace Sprint0.GameModes.GameModes
{
    internal class MarioMode : IGameMode
    {
        private readonly Random RNG;

        public MarioMode()
        {
            RNG = new();
        }

        public Types.GameMode Type => Types.GameMode.MARIOMODE;

        public SoundEffect TransitionSound => Resources.MarioPowerUp;
        public SoundEffect GameModeMusic => Resources.MarioMusic;
        public SoundEffect PlayerHurtSound => Resources.MarioPowerDown;
        public SoundEffect PlayerDeathSound => Resources.MarioDieLong;
        public SoundEffect CharacterHurtSound => Resources.VineBoom;
        public SoundEffect CharacterDeathSound => Resources.MarioStomp;

        public ISprite GetAquamentusSprite(ICharacterState aquamentusState, Types.Direction facingDirection)
        {
            return new BowserSprite();
        }

        public ISprite GetBatSprite(ICharacterState batState, Types.Direction facingDirection)
        {
            if (RNG.Next(2) > 0) return new ParakoopaLeftSprite();
            else return new ParakoopaRightSprite();
        }

        public ISprite GetBladeTrapSprite(Types.Direction facingDirection)
        {
            return new BladeTrapSprite();
        }

        public ISprite GetDodongoSprite(ICharacterState dodongoState, Types.Direction facingDirection)
        {
            return facingDirection switch
            {
                Direction.LEFT => new DodongoLeftSprite(),
                Direction.RIGHT => new DodongoRightSprite(),
                Direction.UP => new DodongoUpSprite(),
                _ => new DodongoDownSprite(),
            };
        }

        public ISprite GetFlameSprite()
        {
            return new FlameSprite();
        }

        public ISprite GetGelSprite(ICharacterState gelState, Types.Direction facingDirection)
        {
            return new GoombaMovingSprite();
        }

        public ISprite GetHandSprite(ICharacterState handState, Types.Direction facingDirection, bool clockwise)
        {
            if (clockwise == true && facingDirection == Types.Direction.DOWN) return new HandDownRightSprite();
            else if (clockwise == false && facingDirection == Types.Direction.RIGHT) return new HandDownRightSprite();
            else if (clockwise == false && facingDirection == Types.Direction.DOWN) return new HandDownLeftSprite();
            else if (clockwise == true && facingDirection == Types.Direction.LEFT) return new HandDownLeftSprite();
            else if (clockwise == false && facingDirection == Types.Direction.UP) return new HandUpRightSprite();
            else if (clockwise == true && facingDirection == Types.Direction.RIGHT) return new HandUpRightSprite();
            else return new HandUpLeftSprite();
        }

        public ISprite GetOldManSprite()
        {
            return new ToadSprite();
        }

        public ISprite GetPlayerSprite(IPlayerState playerState, Types.Direction facingDirection)
        {
            if (playerState is PlayerMovingState)
            {
                if (facingDirection == Direction.LEFT) return new MarioMovingLeftSprite();
                else if (facingDirection == Direction.RIGHT) return new MarioMovingRightSprite();
                else
                {
                    if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
                    else return new MarioMovingRightSprite();
                }
            }
            else if (playerState is PlayerSwordState || playerState is PlayerUseItemState)
            {
                if (facingDirection == Direction.LEFT) return new MarioUseItemLeftSprite();
                else if (facingDirection == Direction.RIGHT) return new MarioUseItemRightSprite();
                else
                {
                    if (RNG.Next(2) > 0) return new MarioUseItemLeftSprite();
                    else return new MarioUseItemRightSprite();
                }
            }
            else if (playerState is PlayerDeadState) return new MarioIdleRightSprite();
            else
            {
                if (facingDirection == Direction.LEFT) return new MarioIdleLeftSprite();
                else if (facingDirection == Direction.RIGHT) return new MarioIdleRightSprite();
                else
                {
                    if (RNG.Next(2) > 0) return new MarioIdleLeftSprite();
                    else return new MarioIdleRightSprite();
                }
            }
        }

        public ISprite GetRedGoriyaSprite(ICharacterState redGoriyaState, Types.Direction facingDirection)
        {
            if (facingDirection == Types.Direction.LEFT) return new HammerBroLeftSprite();
            else if (facingDirection == Types.Direction.RIGHT) return new HammerBroRightSprite();
            else
            {
                if (RNG.Next(2) > 0) return new HammerBroLeftSprite();
                else return new HammerBroRightSprite();
            }
        }

        public ISprite GetSkeletonSprite(ICharacterState skeletonState, Types.Direction facingDirection)
        {
            return new SkeletonSprite();
        }

        public ISprite GetSnakeSprite(ICharacterState snakeState, Types.Direction facingDirection)
        {
            if (facingDirection == Types.Direction.LEFT) return new SnakeLeftSprite();
            else if (facingDirection == Types.Direction.RIGHT) return new SnakeRightSprite();
            else
            {
                if (RNG.Next(2) > 0) return new SnakeLeftSprite();
                else return new SnakeRightSprite();
            }
        }

        public ISprite GetZolSprite(ICharacterState zolState, Types.Direction facingDirection)
        {
            return new BlueGoombaSprite();
        }
    }
}
