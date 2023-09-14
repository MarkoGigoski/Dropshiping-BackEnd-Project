namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Catalog : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
       
    }
}
