﻿using Microsoft.Xna.Framework;
using Sprint0.Characters.Enemies.States.GelStates;

namespace Sprint0.Characters.Enemies
{
    public class Gel : AbstractCharacter
    {
        private double DirectionTimer = 0;
        private readonly double DirectionDelay = 1000;    // Change direction every this many milliseconds.
        public float MovementSpeed { get; set; }
        public Gel(Vector2 position)
        {
            // State
            State = new GelMovingUpState(this);
            // Combat
            Health = 1;
            Damage = 1;

            // Movement
            Position = position;
            MovementSpeed = 2;
        }

        public override void Update(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            DirectionTimer += elapsedTime; 
            if ((DirectionTimer - DirectionDelay) > 0)
            {
                DirectionTimer = 0;
                State.ChangeDirection();
            }

            base.Update(gameTime);
        }
    }
}
