using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine.Scenes;

namespace MainGame.Scenes
{
    public class GameScene : Scene
    {
        private Scene _nextScene;
        private SpriteFont _font;

        public override Scene NextScene
        {
            get => this._nextScene ??= new MainMenuScene(this._game);
        }

        public GameScene(Game game) : base(game) { }

        protected override void LoadContent()
        {
            this._font = this._contentManager.Load<SpriteFont>("Font");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                this.State = SceneState.INACTIVE;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            this._spriteBatch.DrawString(this._font, "in game", new Vector2(0, 0), Color.White);
        }
    }
}