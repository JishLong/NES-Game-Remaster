using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Levels;
using Sprint0.Entities;
using Sprint0.GameModes;

namespace Sprint0.Characters
{
    public interface ICharacter : ICollidable, IEntity
    {
        Vector2 Position { get; set; }

        Types.GameMode GameMode { get; set; }

        int Damage { get; }

        void Draw(SpriteBatch sb);

        void Freeze(bool frozenForever);

        void TakeDamage(Types.Direction damageSide, int damage, Room room);

        void TransitionGameModes(IGameMode oldGameMode, IGameMode newGameMode, bool inCurrentRoom);

        void Unfreeze();

        void Update(GameTime gameTime);
    }
}
