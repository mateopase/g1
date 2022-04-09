using Microsoft.Xna.Framework;

using Engine.Core;
using Engine.Entities;

namespace Engine.Scenes
{
    public abstract class Scene : Drawable
    {
        public abstract Scene NextScene { get; }
        public SceneState State { get; protected set; } = SceneState.INACTIVE;

        protected readonly Camera _camera;
        protected readonly World _world;

        public Scene(Game game) : base(game) { }

        public override void Initialize()
        {
            this.State = SceneState.ACTIVE;

            base.Initialize();
        }
    }
}
