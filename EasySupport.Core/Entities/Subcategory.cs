namespace EasySupport.Core.Entities
{
    public class Subcategory : BaseEntity
    {
        public Subcategory(string name, int categoryId) : base()
        {
            Name = name;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        public void Update(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
