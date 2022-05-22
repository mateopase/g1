using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine.Scenes;

namespace Platformer.Scenes
{
    public class MainMenuScene : Scene
    {
        private SpriteFont _font;
        private Scene _nextScene;

        public override Scene NextScene
        {
            get => this._nextScene ??= new MovementTestScene(this._game);
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
                this.State = SceneState.Inactive;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            this._spriteBatch.DrawString(this._font, "Press space to start!", new Vector2(100, 10), Color.White);
        }
    }
}