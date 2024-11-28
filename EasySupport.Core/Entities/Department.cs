namespace EasySupport.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department(string name) : base()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
