using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Engine.Scenes;

namespace Engine.Core
{
    public abstract class Core : Game
    {
        protected abstract Scene InitialScene { get; }

        protected SceneManager _sceneManager;

        protected override void Initialize()
        {
            // First initialize the base Game
            base.Initialize();

            // Set up the singletons
            this.Services.AddService<SpriteBatch>(new SpriteBatch(this.GraphicsDevice));
            this._sceneManager = new SceneManager(this, InitialScene);

            // Get going
            this._sceneManager.Initialize();
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