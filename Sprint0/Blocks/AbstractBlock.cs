﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace Sprint0.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected ISprite Sprite;
        protected Vector2 Position;
        protected bool Pushable;
        protected bool Walkable;

        protected AbstractBlock (Vector2 position) 
        {
            Position = position;
            Pushable = false;
            Walkable = true;
        }
        public bool IsPushable()
        {
            return Pushable;
        }
        public bool IsWalkable()
        {
            return Walkable;
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

        public void Update()
        {
            Sprite.Update();
        }

        public Rectangle GetHitbox() 
        {
            return Sprite.GetDrawbox(Position);
        }
    }
}
