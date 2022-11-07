﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Key : AbstractItem
    {
        public Key(Vector2 position) : base(new KeySprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.KEY;
        }
    }
}
