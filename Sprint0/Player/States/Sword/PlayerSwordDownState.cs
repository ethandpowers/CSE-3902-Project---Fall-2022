﻿using Sprint0.Projectiles.Tools;
using Sprint0.Sprites;
using Sprint0.Sprites.Player.Attack.SwordAttack;
using System;

namespace Sprint0.Player.State.Idle
{
    public class PlayerSwordDownState : AbstractPlayerState
    {
        public PlayerSwordDownState(Player player) : base(player)
        {
            Sprite = new PlayerSwordAttackDown();
            SpawnSwordMelee();
        }

        public PlayerSwordDownState(IPlayerState state) : base(state)
        {
            Sprite = new PlayerSwordAttackDown();
            SpawnSwordMelee();    
        }

        private void SpawnSwordMelee() 
        {
            float SwordX = Player.Position.X;
            float SwordY = Player.Position.Y + Player.GetHitbox().Height;

            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.SWORDMELEE,
                new Microsoft.Xna.Framework.Vector2(SwordX, SwordY), Types.Direction.DOWN);
        }

        public override void Update()
        {
            base.Update();

            /* We don't want the player's sword attack animation to be abruptly cut off, so we switch the state only after a
             * full sword animation has played through
             * 
             * NOTE: potential coupling/abstraction break issue here - we're casting an interface to an extra abstract class,
             * might be something to fix in the future but works okay for now
             */
            if (FramesPassed % ((AnimatedSprite)Sprite).GetAnimationTime() == 0) 
            {
                Player.State = new PlayerFacingDownState(this);
            }
        }
    }
}
