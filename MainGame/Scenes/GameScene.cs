using Microsoft.Xna.Framework;

using Engine.Scenes;

namespace MainGame.Scenes
{
    public class GameScene : IScene
    {
        private IScene _nextScene;
        public IScene NextScene
        {
            get => this._nextScene ??= new MainMenuScene();
        }

        private SceneState _sceneState = SceneState.COMPLETED;
        public SceneState State
        {
            get => this._sceneState;
            set => this._sceneState = value;
        }

        public GameScene()
        {
            
        }

        public void Initialize()
        {

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