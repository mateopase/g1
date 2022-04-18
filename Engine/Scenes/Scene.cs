using Microsoft.Xna.Framework;

using Engine.Core;

namespace Engine.Scenes
{
    public abstract class Scene : Drawable
    {
        public abstract Scene NextScene { get; }
        public SceneState State { get; protected set; } = SceneState.Inactive;

        protected readonly Camera _camera;

        public Scene(Game game) : base(game) { }

        public override void Initialize()
        {
            this.State = SceneState.Active;

            base.Initialize();
        }
    }
}
