using Dropshiping.BackEnd.Domain.UserModels;
using Dropshiping.BackEnd.Enums;

namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Order : BaseEntity
    {
        public string Address { get; set; } 
       
        public string PostalCode{  get; set; }   
        public string City { get; set; }
        public int PhoneNumber {  get; set; }
        public string Note {  get; set; }
        public decimal TotalPrice { get; set; } 
        public StatusEnum Status { get; set; }

        //Relation conections
        public virtual ICollection<Orderitem> Orderitems { get; set; }
        public User User { get; set; }
        public string UserId {  get; set; }
    }
}
