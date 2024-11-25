namespace EasySupport.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department(string name)
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
