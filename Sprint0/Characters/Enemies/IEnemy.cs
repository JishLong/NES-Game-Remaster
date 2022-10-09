using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters.Enemies;

public interface IEnemy : ICharacter
{
    void TakeDamage(int damage);
}
