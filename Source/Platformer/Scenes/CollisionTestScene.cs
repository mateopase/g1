using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;

using Engine.Scenes;

namespace Platformer.Scenes
{
    public class CollisionTestScene : Scene
    {
        private Scene _nextScene;
        private World _ecsWorld;

        public override Scene NextScene
        {
            get => this._nextScene ??= new MovementTestScene(this._game);
        }

        public CollisionTestScene(Game game) : base(game)
        {
            this._ecsWorld = new WorldBuilder().Build();
        }

        protected override void LoadContent()
        {
            Entity player = this._ecsWorld.CreateEntity();
            Entity platform = this._ecsWorld.CreateEntity();
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