using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Core
{
    public abstract class Drawable : Updateable
    {
        protected readonly SpriteBatch _spriteBatch;
        protected ContentManager _contentManager;

        public Drawable(Game game) : base(game)
        {
            this._spriteBatch = this._game.Services.GetService<SpriteBatch>();
        }

        public override void Initialize()
        {
            this._contentManager = new ContentManager(this._game.Services, "Content");
            this.LoadContent();
        }
        
        protected abstract void LoadContent();

        public abstract void Draw(GameTime gameTime);

        protected override void DisposeManaged()
        {
            this._contentManager.Dispose();
        }
    }
    
}
