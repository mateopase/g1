using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Engine.Core;
using Engine.Scenes;

using MainGame.Scenes;

namespace MainGame
{
    public class MainGame : AGameBase
    {

        protected override AScene InitialScene => new MainMenuScene(this);

        private GraphicsDeviceManager _graphics;

        public MainGame()
        {
            this._graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Load saved settings, and grab below values from settings
            this._graphics.IsFullScreen = false;
            this._graphics.PreferredBackBufferWidth = 256;
            this._graphics.PreferredBackBufferHeight = 256;
            this._graphics.ApplyChanges();

            // Clear the screen
            GraphicsDevice.Clear(Color.Black);

            base.Initialize();
        }
    }
}
