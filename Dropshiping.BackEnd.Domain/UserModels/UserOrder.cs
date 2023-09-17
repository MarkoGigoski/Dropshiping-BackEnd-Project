using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.Domain.UserModels
{
    public class UserOrder : BaseEntity
    {
        // reletion conections
        public User User { get; set; }
        public string UserId { get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }
    }
}
