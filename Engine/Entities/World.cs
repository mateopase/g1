using System;
using System.Collections.Generic;

namespace Engine.Entities
{
    public class World
    {
        private IList<Entity> _entities = new List<Entity>();
        private IList<System> _systems = new List<System>();

        private IDictionary<Type, object> _componentsByType = new Dictionary<Type, object>();

        public Entity CreateEntity()
        {
            var entity = new Entity(this) { Id = this._entities.Count };
            this._entities.Add(entity);
            return entity;
        }

        internal void AddComponent<T>(int entityId, T component)
        {
            this._componentsByType[typeof(T)] = component;
        }
    }

    public class Entity
    {
        private World _world;
        public int Id { get; set; }

        internal Entity(World world)
        {
            this._world = world;
        }

        public void AddComponent<T>(T component)
        {
            this._world.AddComponent<T>(this.Id, component);
        }
    }
}