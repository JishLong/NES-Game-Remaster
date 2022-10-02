﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Key : AbstractItem
    {
        public Key(Vector2 Position) : base(Position)
        {
            sprite = new KeySprite();
        }
    }
}
