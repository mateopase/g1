using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Game1 : Game
    {
        private Texture2D guyTexture;
        private Vector2 guyPosition;
        private float guyVelocity = 50;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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
            this._graphics.PreferredBackBufferWidth = 512;
            this._graphics.PreferredBackBufferHeight = 512;
            this._graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this._spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.guyTexture = Content.Load<Texture2D>("space-brain");
            this.guyPosition = new Vector2(200, 50);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                guyPosition += new Vector2(0, 1) * guyVelocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                guyPosition += new Vector2(1, 0) * guyVelocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                guyPosition += new Vector2(-1, 0) * guyVelocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                guyPosition += new Vector2(0, -1) * guyVelocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }


            base.Update(gameTime);
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
