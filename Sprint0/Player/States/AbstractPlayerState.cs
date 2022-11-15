﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using static Sprint0.Utils;
using static Sprint0.Types;
using Sprint0.Commands.GameStates;
using Sprint0.Items;
using Sprint0.Player.State.Idle;
using Sprint0.Player.States;
using Sprint0.Commands;

namespace Sprint0.Player.State
{
    public abstract class AbstractPlayerState : IPlayerState
    {
        protected Player Player;
        protected ISprite Sprite;

        // Constant values
        private static readonly Vector2 Knockback = new(16 * GameScale, 16 * GameScale);
        private static readonly int InvincibilityFrames = 40;
        private static readonly int KnockbackFrames = InvincibilityFrames / 5;
        private static readonly int LowHealthFrames = 20;

        // Helpful variables to check for certain conditions
        private static bool IsTakingDamage;
        private static int DamageFramesPassed;
        private static int LowHealthFramesPassed;

        private Types.Direction KnockbackDirection;

        protected AbstractPlayerState(Player player, bool isNewPlayer = false) 
        {
            Player = player;
            if (isNewPlayer) 
            {
                IsTakingDamage = false;
                DamageFramesPassed = 0;
                LowHealthFramesPassed = 0;
            }
        }

        public virtual void Capture(ICommand goToBeginningCommand) 
        {
            Player.State = new PlayerCaptureState(Player, goToBeginningCommand);
        }

        public virtual void ChangeHealth(int healthAmount, int maxHealthAmount, Game1 game, Types.Direction direction)
        {
            // Change the max health; if it increases, the player is set to full health
            Player.MaxHealth += maxHealthAmount;
            if (maxHealthAmount > 0) Player.Health = Player.MaxHealth;

            // If the health change is negative, the player takes damage
            if (healthAmount < 0 && !IsTakingDamage)
            {
                IsTakingDamage = true;
                KnockbackDirection = direction;
                AudioManager.GetInstance().PlayOnce(Resources.PlayerTakeDamage);
                Player.Health += healthAmount;
                if (Player.Health <= 0)
                {
                    Player.State = new PlayerDeadState(Player);
                    new LoseGameCommand(game).Execute();
                }
            }
            // If the health change is positive, the player gains health
            else if (healthAmount > 0) Player.Health += healthAmount;

            // The player cannot have more than the max health
            if (Player.Health > Player.MaxHealth) Player.Health = Player.MaxHealth;
        }

        public abstract void DoPrimaryAttack();

        public abstract void DoSecondaryAttack();

        public virtual void Draw(SpriteBatch sb, Vector2 position)
        {
            Color PlayerColor = (IsTakingDamage) ? Color.Red : Color.White;
            Sprite.Draw(sb, position, PlayerColor, PlayerLayerDepth);
        }

        public virtual Rectangle GetHitbox()
        {
            /* It's a little nicer if the player's hitbox is slightly smaller than it cosmetically appears;
             * This makes it easier to run in between tight spaces of blocks
             */
            Rectangle ActualHitbox = new((int)Player.Position.X, (int)Player.Position.Y,
                (int)(Resources.LinkDown.Width * GameScale), (int)(Resources.LinkDown.Height * GameScale));

            int ReducedWidth = ActualHitbox.Width * 2 / 3;
            int ReducedHeight = ActualHitbox.Height * 2 / 3;
            Vector2 ReducedHitboxPosition = CenterRectangles(ActualHitbox, ReducedWidth, ReducedHeight);

            return new Rectangle((int)(ReducedHitboxPosition.X), (int)(ReducedHitboxPosition.Y), ReducedWidth, ReducedHeight);
        }

        public abstract void HoldItem(IItem item);

        public abstract void Move(Direction direction);

        public abstract void StopAction();

        public virtual void Update() 
        {
            Sprite.Update();
            Player.HUD.Update();

            if (IsTakingDamage) 
            {
                // Take knockback
                if (DamageFramesPassed < KnockbackFrames) 
                {
                    Player.Position += DirectionToVector(KnockbackDirection) * Knockback / (KnockbackFrames);
                }

                // Check to see if the player should no longer be damaged
                DamageFramesPassed = (DamageFramesPassed + 1) % InvincibilityFrames;
                if (DamageFramesPassed == 0) 
                {
                    IsTakingDamage = false;
                }
            }

            // Low health sound effect (annoying and scary D: )
            if (Player.Health == 1 && ++LowHealthFramesPassed % LowHealthFrames == 0) 
            {
                AudioManager.GetInstance().PlayOnce(Resources.LowHealth);
                LowHealthFramesPassed = 0;
            }
        }
    }
}
