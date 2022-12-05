﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Items;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class WoodenBoomerang : AbstractItem
    {
        public WoodenBoomerang(Vector2 position) : base(new WoodenBoomerangSprite(), position, Types.Item.WOODENBOOMERANG) { }
    }
}
