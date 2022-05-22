namespace Engine.Physics
{
    public enum BoundingBoxType
    {
        StopMovement = 0,
        Sensor
        
    }

    public class BoundingBox2
    {
        public Transform2 RelativeTransform { get; set; }
        public Rectangle2 Rectangle { get; set; }
        public BoundingBoxType BoxType { get; set; }
        public int EntityId { get; set; }
    }
}
