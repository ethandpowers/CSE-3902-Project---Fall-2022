using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Items
{
    public class WoodenBoomerangSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ItemsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().WoodenBoomerang;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.WoodenBoomerang;
    }
}
