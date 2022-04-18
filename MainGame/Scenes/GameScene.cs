using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine.Scenes;

using MainGame;

namespace MainGame.Scenes
{
    public class GameScene : Scene
    {
        private Scene _nextScene;
        private EntityNode _mainNode;

        public override Scene NextScene
        {
            get => this._nextScene ??= new MainMenuScene(this._game);
        }

        public GameScene(Game game) : base(game) { }

        protected override void LoadContent()
        {
            this._circle = _contentManager.Load<Texture2D>("body-test");
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
            this._spriteBatch.Draw(this._circle, new Vector2(16, 16), Color.White);
        }
    }
}