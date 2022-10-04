using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class ArrowProjectileSprite : AnimatedSprite
    {
        public ArrowProjectileSprite() : base(4, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.ItemsSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.ArrowWeapon;
    }
}
