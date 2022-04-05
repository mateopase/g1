using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Game1 : Game
    {
        private const float MAX_SPEED = 175;
        private const float X_ACCELERATION = 950;
        private const float GRAVITY_ACCELERATION = 900;
        private const float JUMP_VELOCITY = 300;
        private const float Y_ACCELERATION = 950;
        private const float MAX_JUMP_SPEED = 300;
        private const int SCREEN_WIDTH = 512;
        private const int SCREEN_HEIGHT = 128;
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D guyTexture;
        private Vector2 guyPosition;
        private Vector2 guyVelocity;
        private bool guyOnGround = false;

        public Game1()
        {
            this._graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this._graphics.IsFullScreen = false;
            this._graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            this._graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            this._graphics.ApplyChanges();

            this.guyPosition = new Vector2(0, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this._spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.guyTexture = Content.Load<Texture2D>("space-brain");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
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
                this.guyVelocity.X += X_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.guyVelocity.X -= X_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                // Slow down if user lets go of key
                var xDirection = Math.Sign(this.guyVelocity.X);
                this.guyVelocity.X -= xDirection* X_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;
                this.guyVelocity.X = xDirection == -1 ? Math.Min(this.guyVelocity.X, 0f) : Math.Max(this.guyVelocity.X, 0f);
            }

            // Jump
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                // TODO Vary jump height based on how long key was held
                if (this.guyOnGround)
                {
                    this.guyVelocity.Y -= JUMP_VELOCITY;
                    this.guyOnGround = false;
                }
            }

            // Gravity
            this.guyVelocity.Y += GRAVITY_ACCELERATION * (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Velocity limits
            //this.guyVelocity.Y = Math.Clamp(this.guyVelocity.Y, -MAX_JUMP_SPEED, )
            this.guyVelocity.X = Math.Clamp(this.guyVelocity.X, -MAX_SPEED, MAX_SPEED);

            // Update position
            var prevPosition = guyPosition; // This is a copy operation :)
            this.guyPosition += this.guyVelocity * (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Collide with edges
            this.guyPosition.Y = Math.Clamp(guyPosition.Y, 0, SCREEN_HEIGHT-32);
            this.guyPosition.X = Math.Clamp(guyPosition.X, 0, SCREEN_WIDTH-32);

            // Update velocity if wall hit
            if (prevPosition.Y == this.guyPosition.Y)
            {
                this.guyVelocity.Y = 0f;
                this.guyOnGround = true;
            }
            if (prevPosition.X == this.guyPosition.X)
            {
                this.guyVelocity.X = 0f;
            }

            base.Update(gameTime);

            Console.WriteLine(this.guyVelocity);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(guyTexture, guyPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
