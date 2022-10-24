using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Levels;
using Sprint0.Sprites.Characters.Npcs;

namespace Sprint0.Npcs
{
    public class Flame : AbstractCharacter
    {
        public Flame(Vector2 position, int updateTimer = 1000)
        {
            Health = 1;
            Position = position;
            Sprite = new FlameSprite();
        }

        public override void TakeDamage(Types.Direction damageSide, int damage, Room room)
        {
            // You can't kill fire :D
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

        public override Rectangle GetHitbox()
        {
            return Sprite.GetDrawbox(Position);
        }
    }
}
