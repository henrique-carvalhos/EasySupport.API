namespace EasySupport.Core.Entities
{
    public class Enterprise : BaseEntity
    {
        public Enterprise(string name)
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
