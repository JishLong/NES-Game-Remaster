using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;

namespace Sprint0.Characters.Enemies.Interfaces;

public interface IEnemy : ICharacter
{
    void TakeDamage(int damage);
}
