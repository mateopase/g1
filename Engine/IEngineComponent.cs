using System;
using Microsoft.Xna.Framework;

namespace Engine
{
    public interface IEngineComponent
    {
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);

        void LoadContent();
        void UnloadContent();
    }
}
