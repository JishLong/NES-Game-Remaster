using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace Sprint0.Enemies.Utils
{
    public static class EnemyUtils
    {
        public static Random RNG = new Random();

        public static Vector2 RotateByAngle(Vector2 vector, float angle)
        {
            angle = MathHelper.ToRadians(angle);
            Matrix rotationMatrix = Matrix.CreateRotationZ(angle);
            return Vector2.Transform(vector, rotationMatrix);
        }
        
        public static Dictionary<string, Vector2> DirectionVectors = new Dictionary<string, Vector2>()
        {
            {"UP", new Vector2(0,-1)},
            {"UP_RIGHT", new Vector2(1,-1)},
            {"RIGHT", new Vector2(1,0)},
            {"DOWN_RIGHT", new Vector2(1,1)},
            {"DOWN", new Vector2(0,1) },
            {"LEFT_DOWN", new Vector2(-1,1) },
            {"LEFT", new Vector2(-1,0) },
            {"UP_LEFT", new Vector2(-1,-1) },
        };

        public static Dictionary<string, Vector2> OrthogonalVectors = new Dictionary<string, Vector2>()
        {
            {"UP", new Vector2(0,-1)},
            {"RIGHT", new Vector2(1,0)},
            {"DOWN", new Vector2(0,1) },
            {"LEFT", new Vector2(-1,0) },
        };

        /// <summary>
        /// Picks a random direction other than the one passed as a parameter.
        /// </summary>
        /// <param name="currDirectName">The name of the current direction of the calling object.</param>
        /// <remarks>Updates: currDirectName to the new random direction name.</remarks>
        /// <returns>A random direction.</returns>
        public static Vector2 RandDirection(ref string currDirectName)
        {
            // Save pair before removing.
            Vector2 currDirectVect = DirectionVectors[currDirectName];
            DirectionVectors.Remove(currDirectName);

            // Pick a new random direction.
            int index = RNG.Next(0, DirectionVectors.Count);
            KeyValuePair<string, Vector2> pair = DirectionVectors.ElementAt(index);

            // Add pair back in.
            string keyName = currDirectName;
            DirectionVectors.Add(keyName, currDirectVect);

            // Set direction and name with new random values.
            Vector2 randDirection = pair.Value; // Set the new direction
            currDirectName = pair.Key; // Update the direction name

            return randDirection;

        }
        /// <summary>
        /// Picks a random orthogonal direction other than the one passed as a parameter.
        /// </summary>
        /// <param name="currDirectName">The name of the current direction of the calling object.</param>
        /// <remarks>Updates: currDirectName to the new random direction name.</remarks>
        /// <returns>A random orthogonal direction.</returns>
        public static Vector2 RandOrthogDirection(ref string currDirectName)
        {
            // Save pair before removing.
            Vector2 currDirectVect = OrthogonalVectors[currDirectName];
            OrthogonalVectors.Remove(currDirectName);

            // Pick a new random direction.
            int index = RNG.Next(0, OrthogonalVectors.Count);
            KeyValuePair<string, Vector2> pair = OrthogonalVectors.ElementAt(index);

            // Add pair back in.
            string keyName = currDirectName;
            OrthogonalVectors.Add(keyName, currDirectVect);

            // Set direction and name with new random values.
            Vector2 randDirection = pair.Value; // Set the new direction
            currDirectName = pair.Key; // Update the direction name

            return randDirection;
        }
    }
}
