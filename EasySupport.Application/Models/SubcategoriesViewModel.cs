using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class SubcategoriesViewModel
    {
        public SubcategoriesViewModel(int id, string name, bool isDeleted, int categoryId, string category)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
            CategoryId = categoryId;
            Category = category;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public int CategoryId { get; private set; }
        public string Category { get; private set; }

        public static SubcategoriesViewModel FromEntity(Subcategory subcategory)
            => new(subcategory.Id, subcategory.Name, subcategory.IsDeleted, subcategory.Category.Id, subcategory.Category.Name);
    }
}
