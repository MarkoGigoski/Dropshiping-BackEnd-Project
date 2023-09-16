using Dropshiping.BackEnd.Domain.UserModels;

namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class UserOrder : BaseEntity
    {
        // reletion conections
        public User User { get; set; }
        public string UserId {  get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }
    }
}
