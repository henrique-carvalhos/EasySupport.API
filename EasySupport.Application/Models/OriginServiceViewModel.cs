using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class OriginServiceViewModel
    {
        public OriginServiceViewModel(int id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        public static OriginServiceViewModel FromEntity(Enterprise enterprise)
            => new(enterprise.Id, enterprise.Name, enterprise.IsDeleted);
    }
}
