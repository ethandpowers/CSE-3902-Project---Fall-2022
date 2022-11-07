﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items.Items
{
    public class Map : AbstractItem
    {
        public Map(Vector2 position) : base(new MapSprite(), position) { }

        public override Types.Item GetItemType()
        {
            return Types.Item.MAP;
        }
    }
}
