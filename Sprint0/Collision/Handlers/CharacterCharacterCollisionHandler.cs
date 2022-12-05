using Sprint0.Characters;
using Sprint0.Characters.Enemies;

namespace Sprint0.Collision.Handlers
{
    public class CharacterCharacterCollisionHandler
    {
        public void HandleCollision(ICharacter character1, ICharacter character2)
        {
            if (character1 is BladeTrap && character2 is BladeTrap) 
            {
                (character1 as BladeTrap).RespondToBladeTrap();
                (character2 as BladeTrap).RespondToBladeTrap();
            }
        }
    }
}
