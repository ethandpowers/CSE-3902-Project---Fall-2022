﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Player;

namespace Sprint0.Items
{
    public class Bow : AbstractItem
    {
        public Bow(Vector2 position) : base(position)
        {
            Sprite = new BowSprite();
        }
    }
}
