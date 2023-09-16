using System.Security.Cryptography.X509Certificates;
using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.Domain
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }    
        //public string Shiping {  get; set; } // Of what type?
        public virtual ICollection<Product> Products { get; set; }
    }
}
