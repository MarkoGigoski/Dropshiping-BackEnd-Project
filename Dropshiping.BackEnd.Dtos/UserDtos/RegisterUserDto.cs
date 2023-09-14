namespace Dropshiping.BackEnd.Dtos.UserDtos
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // hash
        public string ConfirmationPassword {  get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
