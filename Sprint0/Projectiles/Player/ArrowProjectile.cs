using Microsoft.Xna.Framework;
using Sprint0.Sprites.Characters.Npcs;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowProjectile : AbstractProjectile
    {
        public ArrowProjectile(Vector2 position, Vector2 velocity) : base(position, velocity)
        {
            FramesAlive = 60;
            FramesPassed = 0;

            Sprite = new ArrowProjectileSprite();
        }
    }
}
