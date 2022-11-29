using Microsoft.Xna.Framework.Audio;
using Sprint0.Characters;
using Sprint0.Player.States;
using Sprint0.Sprites;

namespace Sprint0.GameModes
{
    public interface IGameMode
    {
        Types.GameMode Type { get; }

        SoundEffect TransitionSound { get; }
        SoundEffect GameModeMusic { get; }
        SoundEffect PlayerHurtSound { get; }
        SoundEffect PlayerDeathSound { get; }
        SoundEffect CharacterHurtSound { get; }
        SoundEffect CharacterDeathSound { get; }

        ISprite GetPlayerSprite(IPlayerState playerState, Types.Direction facingDirection);

        ISprite GetAquamentusSprite(ICharacterState aquamentusState, Types.Direction facingDirection);

        ISprite GetBatSprite(ICharacterState batState, Types.Direction facingDirection);

        ISprite GetBladeTrapSprite(Types.Direction facingDirection);

        ISprite GetDodongoSprite(ICharacterState dodongoState, Types.Direction facingDirection);

        ISprite GetFlameSprite();

        ISprite GetGelSprite(ICharacterState gelState, Types.Direction facingDirection);

        ISprite GetHandSprite(ICharacterState handState, Types.Direction facingDirection, bool clockwise);

        ISprite GetOldManSprite();

        ISprite GetRedGoriyaSprite(ICharacterState redGoriyaState, Types.Direction facingDirection);

        ISprite GetSkeletonSprite(ICharacterState skeletonState, Types.Direction facingDirection);

        ISprite GetSnakeSprite(ICharacterState snakeState, Types.Direction facingDirection);

        ISprite GetZolSprite(ICharacterState zolState, Types.Direction facingDirection);
    }
}
