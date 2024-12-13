namespace EasySupport.Core.Entities
{
    public class SolutionTicket : BaseEntity
    {
        public SolutionTicket(string name) : base()
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
