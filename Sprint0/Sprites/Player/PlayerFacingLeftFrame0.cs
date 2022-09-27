﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class PlayerFacingLeftFrame0 : ISprite
    {
        private readonly int spriteScale = 3;
        private readonly Vector2 position;

        public PlayerFacingLeftFrame0(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(35, 11, 15, 16);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, spriteScale * 15, spriteScale * 16);

            sb.Begin(samplerState: SamplerState.PointClamp);
            sb.Draw(LinkSpriteSheet.GetSpriteSheet(), destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            sb.End();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

