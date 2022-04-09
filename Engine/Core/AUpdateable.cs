using System;

using Microsoft.Xna.Framework;

namespace Engine.Core
{
    public abstract class AUpdateable : IDisposable
    {
        protected readonly Game _game;
        protected bool _disposed;

        public AUpdateable(Game game)
        {
            this._game = game;
        }

        public abstract void Initialize();

        public abstract void Update(GameTime gameTime);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                // If a class has unmanaged resources, it can implement a finalizer with disposing=false
                if (disposing)
                {
                    this.DisposeManaged();
                }

                this.DisposeUnmanaged();

                this._disposed = true;
            }
        }

        protected virtual void DisposeManaged() { }

        protected virtual void DisposeUnmanaged() { }
    }
    
}
