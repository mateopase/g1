using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine.Scenes;

namespace Platformer.Scenes
{
    public class MovementTestScene : Scene
    {
        private Scene _nextScene;

        public override Scene NextScene
        {
            get => this._nextScene ??= new MainMenuScene(this._game);
        }

        private const float MAX_SPEED = 175;
        private const float X_ACCELERATION = 950;
        private const float GRAVITY_ACCELERATION = 900;
        private const float JUMP_VELOCITY = 300;
        private const float Y_ACCELERATION = 950;
        private const float MAX_JUMP_SPEED = 300;

        private Texture2D _guyTexture;
        private Vector2 _guyPosition;
        private Vector2 _guyVelocity;
        private bool guyOnGround = false;

        public MovementTestScene(Game game) : base(game) { }

        protected override void LoadContent()
        {
            this._guyTexture = _contentManager.Load<Texture2D>("space-brain");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.State = SceneState.Inactive;
            }

            // Movement
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                /* Here we can check if the player is changing direction
                 * That way the player can skid and turn more quickly than 
                 * just deccelerating down to 0 then back up to speed
                 * Maybe adding some kind of conditional acceleration scaling is good?
                if (Math.Sign(this.guyVelocity.X) == -1)
                {
                    this.guyVelocity.X = 0f;
                }
                */
                this._guyVelocity.X += X_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this._guyVelocity.X -= X_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                // Slow down if user lets go of key
                var xDirection = Math.Sign(this._guyVelocity.X);
                this._guyVelocity.X -= xDirection* X_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;
                this._guyVelocity.X = xDirection == -1 ? Math.Min(this._guyVelocity.X, 0f) : Math.Max(this._guyVelocity.X, 0f);
            }

            // Jump
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                // TODO Vary jump height based on how long key was held
                if (this.guyOnGround)
                {
                    this._guyVelocity.Y -= JUMP_VELOCITY;
                    this.guyOnGround = false;
                }
            }

            // Gravity
            this._guyVelocity.Y += GRAVITY_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Velocity limits
            //this.guyVelocity.Y = Math.Clamp(this.guyVelocity.Y, -MAX_JUMP_SPEED, )
            this._guyVelocity.X = Math.Clamp(this._guyVelocity.X, -MAX_SPEED, MAX_SPEED);

            // Update position
            var prevPosition = _guyPosition; // This is a copy operation :)
            this._guyPosition += this._guyVelocity * (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Collide with edges
            this._guyPosition.Y = Math.Clamp(_guyPosition.Y, 0, 256-32);
            this._guyPosition.X = Math.Clamp(_guyPosition.X, 0, 256-32);

            // Update velocity if wall hit
            if (prevPosition.Y == this._guyPosition.Y)
            {
                this._guyVelocity.Y = 0f;
                this.guyOnGround = true;
            }
            if (prevPosition.X == this._guyPosition.X)
            {
                this._guyVelocity.X = 0f;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            this._spriteBatch.Draw(_guyTexture, _guyPosition, Color.White);
        }
    }
}