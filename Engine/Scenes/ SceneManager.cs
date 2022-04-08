using Microsoft.Xna.Framework;

namespace Engine.Scenes
{
    public class SceneManager : DrawableGameComponent
    {
        private IScene _currentScene;
        private IScene CurrentScene {
            get => this._currentScene;
            set {
                // TODO Is this the best place to put this stuff? Maybe separate funcs?
                // Unload completed scene
                this._currentScene?.UnloadContent();
                // Set next scene as current scene
                this._currentScene = value;
                // Initialize and load current scene
                this._currentScene.Initialize();
                this._currentScene.LoadContent();
            }
        }

        public SceneManager(Game game, IScene initialScene) : base(game)
        {
            this.CurrentScene = initialScene;
        }

        public override void Update(GameTime gameTime)
        {
            if (this.CurrentScene.State == SceneState.COMPLETED)
            {
                this.CurrentScene = this.CurrentScene.NextScene;
            }

            this.CurrentScene.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.CurrentScene.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            this._currentScene?.UnloadContent();
        }
    }
}