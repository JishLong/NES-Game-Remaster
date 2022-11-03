using Microsoft.Xna.Framework;

namespace Sprint0
{
    public static class Camera
    {
        private static Vector2 Offset = Vector2.Zero;

        public static Vector2 GetOffset() 
        {
            return Offset;
        }

        public static void Move(Types.Direction direction, int amount) 
        {
            Offset -= Utils.DirectionToVector(direction) * amount;
        }

        public static void Reset() 
        {
            Offset = Vector2.Zero;
        }
    }
}
