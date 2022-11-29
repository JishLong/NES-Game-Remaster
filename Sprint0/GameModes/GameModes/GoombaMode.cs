using Microsoft.Xna.Framework.Audio;
using Sprint0.Characters;
using Sprint0.Player.States;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Sprites.GoombaMode.Goomba;
using Sprint0.Sprites.GoombaMode.Mario;
using Sprint0.Sprites.Projectiles.Player;
using System;

namespace Sprint0.GameModes.GameModes
{
    internal class GoombaMode : IGameMode
    {
        private readonly Random RNG;

        public GoombaMode()
        {
            RNG = new();
        }

        public Types.GameMode Type => Types.GameMode.GOOMBAMODE;

        public SoundEffect TransitionSound => Resources.MarioPowerUpAppears;
        public SoundEffect GameModeMusic => Resources.MarioMusic;
        public SoundEffect PlayerHurtSound => Resources.VineBoom;
        public SoundEffect PlayerDeathSound => Resources.BowserFalls;
        public SoundEffect CharacterHurtSound => Resources.MarioPowerDown;
        public SoundEffect CharacterDeathSound => Resources.MarioDieShort;

        public ISprite GetAquamentusSprite(ICharacterState aquamentusState, Types.Direction facingDirection)
        {
            return new MarioMovingLeftSprite();
        }

        public ISprite GetBatSprite(ICharacterState batState, Types.Direction facingDirection)
        {
            if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
            else return new MarioMovingRightSprite();
        }

        public ISprite GetBladeTrapSprite(Types.Direction facingDirection)
        {
            if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
            else return new MarioMovingRightSprite();
        }

        public ISprite GetDodongoSprite(ICharacterState dodongoState, Types.Direction facingDirection)
        {
            if (facingDirection == Types.Direction.LEFT) return new MarioMovingLeftSprite();
            else if (facingDirection == Types.Direction.RIGHT) return new MarioMovingRightSprite();
            else
            {
                if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
                else return new MarioMovingRightSprite();
            }
        }

        public ISprite GetFlameSprite()
        {
            if (RNG.Next(2) > 0) return new MarioIdleLeftSprite();
            else return new MarioIdleRightSprite();
        }

        public ISprite GetGelSprite(ICharacterState gelState, Types.Direction facingDirection)
        {
            if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
            else return new MarioMovingRightSprite();
        }

        public ISprite GetHandSprite(ICharacterState handState, Types.Direction facingDirection, bool clockwise)
        {
            if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
            else return new MarioMovingRightSprite();
        }

        public ISprite GetOldManSprite()
        {
            if (RNG.Next(2) > 0) return new MarioIdleLeftSprite();
            else return new MarioIdleRightSprite();
        }

        public ISprite GetPlayerSprite(IPlayerState playerState, Types.Direction facingDirection)
        {
            if (playerState is PlayerMovingState) return new GoombaMovingSprite();
            else return new GoombaIdleSprite();
        }

        public ISprite GetRedGoriyaSprite(ICharacterState redGoriyaState, Types.Direction facingDirection)
        {
            if (facingDirection == Types.Direction.LEFT) return new MarioMovingLeftSprite();
            else if (facingDirection == Types.Direction.RIGHT) return new MarioMovingRightSprite();
            else
            {
                if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
                else return new MarioMovingRightSprite();
            }
        }

        public ISprite GetSkeletonSprite(ICharacterState skeletonState, Types.Direction facingDirection)
        {
            if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
            else return new MarioMovingRightSprite();
        }

        public ISprite GetSnakeSprite(ICharacterState snakeState, Types.Direction facingDirection)
        {
            if (facingDirection == Types.Direction.LEFT) return new MarioMovingLeftSprite();
            else if (facingDirection == Types.Direction.RIGHT) return new MarioMovingRightSprite();
            else
            {
                if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
                else return new MarioMovingRightSprite();
            }
        }

        public ISprite GetZolSprite(ICharacterState zolState, Types.Direction facingDirection)
        {
            if (RNG.Next(2) > 0) return new MarioMovingLeftSprite();
            else return new MarioMovingRightSprite();
        }
    }
}
