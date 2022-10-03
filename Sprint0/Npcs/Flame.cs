using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Sprint0.Sprites.Npcs;

namespace Sprint0.Npcs
{
    public class Flame : AbstractNpc
    {
        // milliseconds
        int ElapsedTime;
        int UpdateTimer;
        bool isProjectile;

        public Flame(Vector2 position, int updateTimer = 1000)
        {
            this.Health = 1;
            //this.IsProjectile = true;
            this.Position = position;
            this.Direction = new Vector2(0, 0); // Starts standing still.
            this.UpdateTimer = updateTimer;
            this.sprite = new Sprites.Blocks.FireBlockSprite();
        }

        // public override bool IsProjectile()
        // {
        //      return this.IsProjectile;
        // }
        public override void Destroy()
        {
            // no functionality 
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            ElapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (ElapsedTime > UpdateTimer)
            {
                ElapsedTime = 0;
            }
            sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, Position);
        }
    }
}