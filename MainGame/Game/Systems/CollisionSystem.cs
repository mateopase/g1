using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace MainGame.Systems
{
    public class PositionComponent
    {
        public Vector2 Postition;
        public Vector2 Destination;
    }

    public class PhysicsComponent
    {
        public Vector2 Velocity;
    }

    public class CollisionSystem : EntityUpdateSystem
    {
        private ComponentMapper<PositionComponent> _positions;
        private ComponentMapper<PhysicsComponent> _physics;

        public CollisionSystem() : base(Aspect.All(typeof(PositionComponent), typeof(PhysicsComponent)).One(typeof(BoundingBox), typeof(BoundingSphere)))
        {

        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            this._positions = mapperService.GetMapper<PositionComponent>();
            this._physics = mapperService.GetMapper<PhysicsComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entityId in ActiveEntities)
            {
                
            }
        }
    }
}