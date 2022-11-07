using Microsoft.Xna.Framework;

namespace Sprint0
{
    public static class Camera
    {
        private static Vector2 Offset = new Vector2(0, 44 * Utils.GameScale);

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
            Offset = new Vector2(0, 44 * Utils.GameScale);
        }
    }
}
