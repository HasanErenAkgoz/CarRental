using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Brand : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }

        public Brand() { }
        public Brand(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
