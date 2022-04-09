using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Engine.Core;

namespace Engine.Scenes
{
    public class SceneManager : Drawable
    {
        private Scene _activeScene;
        private Scene ActiveScene {
            get => this._activeScene;
            set {
                // Unload old scene
                this._activeScene?.Dispose();
                // Set next scene as current scene
                this._activeScene = value;
                // Initialize current scene for drawing
                this._activeScene.Initialize();
            }
        }

        public SceneManager(Game game, Scene initialScene) : base(game)
        {
            this.ActiveScene = initialScene;
        }

        public override void Initialize() { }

        protected override void LoadContent() { }

        public override void Update(GameTime gameTime)
        {
            if (this.ActiveScene.State == SceneState.INACTIVE)
            {
                this.ActiveScene = this.ActiveScene.NextScene;
            }

            this.ActiveScene.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this._game.GraphicsDevice.Clear(Color.Black);

            this._spriteBatch.Begin();
            this.ActiveScene.Draw(gameTime);
            this._spriteBatch.End();
        }

        protected override void DisposeManaged()
        {
            this.ActiveScene?.Dispose();
        }
    }
}