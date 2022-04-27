using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;

using Engine.Scenes;

namespace Platformer.Scenes
{
    public class BallScene : Scene
    {
        private Scene _nextScene;
        private World _ecsWorld;

        public override Scene NextScene
        {
            get => this._nextScene ??= new GameScene(this._game);
        }

        public BallScene(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.State = SceneState.Inactive;
            }
        }

        public override void Draw(GameTime gameTime)
        {
        }
    }
}