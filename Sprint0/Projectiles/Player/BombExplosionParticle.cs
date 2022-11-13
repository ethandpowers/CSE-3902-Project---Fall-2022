﻿using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Types;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionParticle : AbstractProjectile
    {
        public BombExplosionParticle(ICollidable user, Direction direction) :
            base(new BombExplosionParticleSprite(), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;        
            Damage = 4;
            if (user is BombProjectile)
            {
                Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
                AudioManager.GetInstance().PlayOnce(Resources.BombExplode);

                ProjectileManager PM = ProjectileManager.GetInstance();

                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.LEFT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.RIGHT);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.UP);
                PM.AddProjectile(Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.DOWN);
            }     
        }

        public override bool IsFromPlayer()
        {
            return true;
        }

        public override void DeathAction()
        {
            // Nothing here!
        }
    }
}
