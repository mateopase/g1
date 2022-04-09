using Microsoft.Xna.Framework;

using Engine.Core;

namespace Engine.Scenes
{
    public abstract class AScene : ADrawable
    {
        public abstract AScene NextScene { get; }
        public SceneState State { get; protected set; } = SceneState.INACTIVE;

        public AScene(Game game) : base(game) { }

        public override void Initialize()
        {
            this.State = SceneState.ACTIVE;

            base.Initialize();
        }
    }
}
