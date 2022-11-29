using Microsoft.Xna.Framework.Audio;
using Sprint0.Characters;
using Sprint0.Player.States;
using Sprint0.Sprites;
using Sprint0.Sprites.Characters.Enemies;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Sprites.Player.Attack.SwordAttack;
using Sprint0.Sprites.Player.Attack.UseItem;
using Sprint0.Sprites.Player.Movement;
using Sprint0.Sprites.Player.Stationary;
using Sprint0.Sprites.Projectiles.Player;
using System;
using static Sprint0.Types;

namespace Sprint0.GameModes.GameModes
{
    internal class NormalMode : IGameMode
    {
        private readonly Random RNG;

        public NormalMode() 
        {
            RNG = new();
        }

        public Types.GameMode Type => Types.GameMode.NORMALMODE;

        public SoundEffect TransitionSound => Resources.NewItem;
        public SoundEffect GameModeMusic => Resources.DungeonMusic;
        public SoundEffect PlayerHurtSound => Resources.PlayerTakeDamage;
        public SoundEffect PlayerDeathSound => Resources.PlayerDeath;
        public SoundEffect CharacterHurtSound => Resources.EnemyTakeDamage;
        public SoundEffect CharacterDeathSound => Resources.EnemyDeath;

        public ISprite GetAquamentusSprite(ICharacterState aquamentusState, Types.Direction facingDirection)
        {
            return new AquamentusSprite();
        }

        public ISprite GetBatSprite(ICharacterState batState, Types.Direction facingDirection)
        {
            return new BatSprite();
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
            return new GelSprite();
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
            return new OldManSprite();
        }

        public ISprite GetPlayerSprite(IPlayerState playerState, Types.Direction facingDirection)
        {
            if (playerState is PlayerMovingState)
            {
                return facingDirection switch
                {
                    Direction.LEFT => new PlayerMovingLeftSprite(),
                    Direction.RIGHT => new PlayerMovingRightSprite(),
                    Direction.UP => new PlayerMovingUpSprite(),
                    _ => new PlayerMovingDownSprite(),
                };
            }
            else if (playerState is PlayerSwordState)
            {
                return facingDirection switch
                {
                    Direction.LEFT => new PlayerSwordLeftSprite(),
                    Direction.RIGHT => new PlayerSwordRightSprite(),
                    Direction.UP => new PlayerSwordUpSprite(),
                    _ => new PlayerSwordDownSprite(),
                };
            }
            else if (playerState is PlayerUseItemState)
            {
                return facingDirection switch
                {
                    Direction.LEFT => new PlayerUseItemLeftSprite(),
                    Direction.RIGHT => new PlayerUseItemRightSprite(),
                    Direction.UP => new PlayerUseItemUpSprite(),
                    _ => new PlayerUseItemDownSprite(),
                };
            }
            else if (playerState is PlayerHoldItemState) return new PlayerHoldItemSprite();
            else if (playerState is PlayerCaptureState) return new PlayerIdleUpSprite();
            else
            {
                return facingDirection switch
                {
                    Direction.LEFT => new PlayerIdleLeftSprite(),
                    Direction.RIGHT => new PlayerIdleRightSprite(),
                    Direction.UP => new PlayerIdleUpSprite(),
                    _ => new PlayerIdleDownSprite(),
                };
            };
        }

        public ISprite GetRedGoriyaSprite(ICharacterState redGoriyaState, Direction facingDirection)
        {
            return facingDirection switch
            {
                Direction.LEFT => new RedGoriyaLeftSprite(),
                Direction.RIGHT => new RedGoriyaRightSprite(),
                Direction.UP => new RedGoriyaUpSprite(),
                _ => new RedGoriyaDownSprite(),
            };
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
            return new ZolSprite();
        }
    }
}
