namespace EasySupport.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category(string name) : base()
        {
            Name = name;
            Subcategories = [];
        }

        public string Name { get; private set; } // "Equipamento", "Programas", etc.
        public List<Subcategory> Subcategories { get; set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
