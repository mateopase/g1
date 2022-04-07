using System.Collections.Generic;

namespace Engine.Entities
{
    public class Entity
    {
        private int _id;
        private World _world;

        public Entity(World world) {
            this._world = world;
        }
    }

    public interface IComponent { }

    public interface ISystem<T> where T : IComponent
    {
        void Process();
    }

    public class VelocityComponent : IComponent
    {

    }

    public class PositionComponent : IComponent
    {

    }

    public class InputSystem : ISystem<InputComponent>
    {
        public void Process()
        {
            foreach (var inputComponent in this.world

        }
    }

    public class World
    {
        private IList<ISystem<IComponent>> systems;

        public World()
        {
            this.systems = new List<ISystem<IComponent>>();
        }

        public void AddSystem(ISystem<IComponent> system)
        {
            this.systems.Add(system);
        }

        public Entity CreateEntity()
        {
            return null;
        }
    }
}