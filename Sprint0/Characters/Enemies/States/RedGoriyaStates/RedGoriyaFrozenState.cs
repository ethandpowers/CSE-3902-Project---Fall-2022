using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.RedGoriyaStates;
using Sprint0.GameModes;
using static Sprint0.Types;

namespace Sprint0.Characters.Enemies.States.RedGoriyaStates
{
    public class RedGoriyaFrozenState : AbstractCharacterState
    {
        private bool FrozenForever;
        private readonly Types.Direction ResumeMovementDirection;

        private double FrozenTimer;
        private readonly double FrozenDelay = 5000;  // Stay frozen for this many milliseconds.

        public RedGoriyaFrozenState(AbstractCharacter character, Types.Direction direction, bool frozenForever) : base(character)
        {
            ResumeMovementDirection = direction;
            FrozenForever = frozenForever;

            FrozenTimer = 0;
        }
        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            // Can't change direction while frozen
        }

        public override void Freeze(bool frozenForever)
        {
            // If a goriya is frozen from a boomerang, picking up a clock will keep it frozen forever
            // On the other hand, if a goriya is frozen from a clock, we don't want the boomerang to "unfreeze" it
            if (frozenForever) FrozenForever = frozenForever;
        }

        public override void Unfreeze()
        {
            Character.State = new RedGoriyaMovingState(Character, ResumeMovementDirection);
        }

        public override void Update(GameTime gameTime)
        {
            if (!FrozenForever) FrozenTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if ((FrozenTimer - FrozenDelay) > 0) Unfreeze();

            Character.Sprite.Update();
        }
    }
}
