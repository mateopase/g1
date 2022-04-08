using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Engine.Scenes;

using MainGame.Scenes;

namespace MainGame
{
    public class MainGame : Game
    {
        private const int SCREEN_WIDTH = 256;
        private const int SCREEN_HEIGHT = 256;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager _sceneManager;

        public MainGame()
        {
            this._graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Load settings here, and grab values from settings
            this._graphics.IsFullScreen = false;
            this._graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            this._graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            this._graphics.ApplyChanges();

            // Clear the screen
            GraphicsDevice.Clear(Color.Black);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create the sprite batch singleton
            this._spriteBatch = new SpriteBatch(GraphicsDevice);

            // Add the main scene manager
            Components.Add(new SceneManager(this, new MainMenuScene()));

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            this._sceneManager.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            this._sceneManager.Draw(gameTime);
        }
    }
}
