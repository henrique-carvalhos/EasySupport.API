using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string email, string role, DateTime alteredAt, DateTime createdAt, string enterprise, string department)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            AlteredAt = alteredAt;
            CreatedAt = createdAt;
            Enterprise = enterprise;
            Department = department;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public DateTime AlteredAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Enterprise { get; private set; }
        public string Department { get; private set; }

        public static UserViewModel FromEntity(User user)
        => new(user.Id, user.Name, user.Email, user.Role, user.AlteredAt, user.CreatedAt, user.Enterprise.Name, user.Department.Name);
    }
}
