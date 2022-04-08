using Microsoft.Xna.Framework;

using Engine.Scenes;

namespace MainGame.Scenes
{
    public class MainMenuScene : IScene
    {
        private IScene _nextScene;
        public IScene NextScene
        {
            get => this._nextScene ??= new GameScene();
        }

        private SceneState _sceneState = SceneState.COMPLETED;
        public SceneState State
        {
            get => this._sceneState;
            set => this._sceneState = value;
        }

        public MainMenuScene()
        {

        }

        public void Initialize()
        {
            this.State = SceneState.ACTIVE;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {

        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }
    }
}