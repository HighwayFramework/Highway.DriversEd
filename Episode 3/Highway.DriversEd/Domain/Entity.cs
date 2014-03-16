using Highway.Data;

namespace Domain
{
    public class Entity : IIdentifiable<int>
    {
        public int Id { get; set; }
    }
}