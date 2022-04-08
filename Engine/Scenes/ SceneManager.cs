using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine.Scenes
{
    public class SceneManager : DrawableGameComponent
    {
        private readonly Stack<AScene> _scenes = new Stack<AScene>();

        public SceneManager(Game game) : base(game) { }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void OnDrawOrderChanged(object sender, EventArgs args)
        {
            base.OnDrawOrderChanged(sender, args);
        }

        protected override void OnEnabledChanged(object sender, EventArgs args)
        {
            base.OnEnabledChanged(sender, args);
        }

        protected override void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            base.OnUpdateOrderChanged(sender, args);
        }

        protected override void OnVisibleChanged(object sender, EventArgs args)
        {
            base.OnVisibleChanged(sender, args);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}