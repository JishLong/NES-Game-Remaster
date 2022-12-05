namespace Sprint0.Entities
{
    public interface IEntity
    {
        IEntity Parent { get; set; }

        string Name { get; set; }
    }
}
