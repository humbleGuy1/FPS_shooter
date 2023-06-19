namespace HittableObjects
{
    public interface IHittableObject
    {
        public ObjectType Type { get; }
        
        public void OnHit();
    }

    public enum ObjectType
    {
        Wood,
        Metal
    }
}





