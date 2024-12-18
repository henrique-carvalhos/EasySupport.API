namespace EasySupport.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string role, string password,DateTime alteredAt, int enterpriseId, int departmentId) : base()
        {
            Name = name;
            Email = email;
            Role = role;
            Password = password;
            AlteredAt = DateTime.Now;
            EnterpriseId = enterpriseId;
            DepartmentId = departmentId;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; } // "Atendente" ou "Solicitante"
        public string Password { get; private set; }
        public DateTime AlteredAt { get; private set; }

        public int EnterpriseId { get; private set; }
        public Enterprise Enterprise { get; set; }

        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }

        public void Update(string name, string email, string role, DateTime alteredAt, int enterpriseId, int departmentId)
        {
            Name = name;
            Email = email;
            Role = role;
            AlteredAt = DateTime.Now;
            EnterpriseId = enterpriseId;
            DepartmentId = departmentId;
        }
    }
}
