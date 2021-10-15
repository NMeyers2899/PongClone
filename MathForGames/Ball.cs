using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Ball : Actor
    {
        private float _speed;
        private Vector2 _velocity;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Ball(char icon, float x, float y, float speed, string name = "Player",
            ConsoleColor color = ConsoleColor.White) : base(icon, x, y, name, color)
        {
            _speed = speed;
        }

        public override void Start()
        {
            base.Start();
            Velocity = new Vector2 { X = -1, Y = 1 };
        }

        public override void Update()
        {
            Position += Velocity;
        }

        public override void Draw()
        {
            Engine.TryRender(Icon, Position);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor.Name == "Wall")
                Velocity = new Vector2 { X = Velocity.X, Y = -Velocity.Y };
            else if (actor.Name == "Player" || actor.Name == "Player2")
                Velocity = new Vector2 { X = -Velocity.X, Y = Velocity.Y };
            else if (actor.Name == "Red Goal")
            {
                Engine.IncrementScore("Red");
                ResetPositon();
            }
            else if (actor.Name == "Blue Goal")
            {
                Engine.IncrementScore("Blue");
                ResetPositon();
            }
        }

        /// <summary>
        /// Resets the position of the ball to its original position.
        /// </summary>
        public void ResetPositon()
        {
            Position = new Vector2 { X = 10, Y = 5 };
        }
    }
}
