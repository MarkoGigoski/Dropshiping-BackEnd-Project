namespace Dropshiping.BackEnd.Domain.UserModels
{
    public class Card : BaseEntity
    {
        public int CardNumber {  get; set; }
        public string CardHolder {  get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SecurityCode {  get; set; }

        //relation with User
        public User User { get; set; }
        public string UserId {  get; set; }
    }
}
