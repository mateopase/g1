using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine.Scenes;

namespace MainGame.Scenes
{
    public class MainMenuScene : AScene
    {
        private SpriteFont _font;
        private AScene _nextScene;

        public override AScene NextScene
        {
            get => this._nextScene ??= new GameScene(this._game);
        }

        public MainMenuScene(Game game) : base(game) { }

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
            this._spriteBatch.DrawString(this._font, "in menu", new Vector2(0, 0), Color.White);
        }
    }
}