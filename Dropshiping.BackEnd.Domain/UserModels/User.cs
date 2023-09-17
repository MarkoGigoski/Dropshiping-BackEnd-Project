using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Enums;

namespace Dropshiping.BackEnd.Domain.UserModels
{
    public class User : BaseEntity
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; } // hash
        public string Email { get; set; }
        public int Age {  get; set; }
        public int PhoneNumber { get; set; }
        public string Address {  get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        //Need extra code for  assining tokens on create/ login/ how to do it?
        public RoleEnum Role { get; set; }

        // Relations for products-cart
        public virtual ICollection<UserOrder> UserOrders { get; set; }
        public virtual ICollection<Raiting> Raitings { get; set; } // Kako ova? so e klasata raitings i kako da se izveda za da se smetnuva samoto? bez dodaten kod zoso vleche property on creat
        public virtual ICollection<Card> Cards { get; set; }
    }
}
