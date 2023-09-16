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

        //Need extra code for  assining tokens on creat/ how to do it?
        public Role Role { get; set; }
        public string RoleId {  get; set; }

        // Relations for products-cart
        public virtual ICollection<UserOrder> UserOrders { get; set; }
        public virtual ICollection<Raiting> Raitings { get; set; }

    }
}
