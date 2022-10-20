﻿using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.Utils;
using Sprint0.Sprites.Characters.Enemies;

namespace Sprint0.Characters.Enemies.States.SkeletonStates
{
    public class SkeletonMovingRightState : AbstractCharacterState
    {
        private Skeleton Skeleton;
        private Types.Direction StateDirection;
        private Vector2 DirectionVector;
        public SkeletonMovingRightState(Skeleton skeleton)
        {
            Skeleton = skeleton;
            StateDirection = Types.Direction.RIGHT;
            DirectionVector = Sprint0.Utils.DirectionToVector(StateDirection);
            Sprite = new SkeletonSprite();
        }

        public override void Attack()
        {
            // Does not attack.
        }

        public override void ChangeDirection()
        {
            Types.Direction direction = CharacterUtils.RandOrthogDirection(StateDirection);
            switch (direction)
            {
                case Types.Direction.LEFT:
                    Skeleton.State = new SkeletonMovingLeftState(Skeleton);
                    break;
                case Types.Direction.DOWN:
                    Skeleton.State = new SkeletonMovingDownState(Skeleton);
                    break;
                case Types.Direction.UP:
                    Skeleton.State = new SkeletonMovingUpState(Skeleton);
                    break;
            }
        }

        public override void Freeze()
        {
            Skeleton.State = new SkeletonFrozenState(Skeleton, StateDirection);
        }

        public override void Move()
        {
            Skeleton.Position += DirectionVector * Skeleton.MovementSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            Sprite.Update();
        }
    }
}
