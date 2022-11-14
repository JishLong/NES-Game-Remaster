using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class Camera
    {
        private static Camera Instance;

        private Vector2 Origin;
        public Vector2 Position { get; private set; }

        private Camera(Vector2 origin)
        {
            Origin = origin;
            Position = origin;
        }

        public void Move(Types.Direction direction, int amount)
        {
            Position += Utils.DirectionToVector(direction) * amount;
        }

        public void Reset()
        {
            Position = Origin;
        }

        public static Camera GetInstance()
        {
            Instance ??= new Camera(new(0, 44 * Utils.GameScale));
            return Instance;
        }
    }
}
