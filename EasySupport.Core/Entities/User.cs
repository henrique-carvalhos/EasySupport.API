namespace EasySupport.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string role, DateTime alteredAt) : base()
        {
            Name = name;
            Email = email;
            Role = role;
            AlteredAt = DateTime.Now;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; } // "Atendente" ou "Solicitante"
        public DateTime AlteredAt { get; private set; }

        public void Update(string name, string email, string role, DateTime alteredAt)
        {
            Name = name;
            Email = email;
            Role = role;
            AlteredAt = DateTime.Now;
        }
    }
}
