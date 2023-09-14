using System.Text;
using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.UserModels;
using Dropshiping.BackEnd.Dtos.UserDtos;
using Dropshiping.BackEnd.Services.UserServices.Interface;
using XSystem.Security.Cryptography;

namespace Dropshiping.BackEnd.Services.UserServices.Implementation
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // Register User
        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            // Validations
            if(string.IsNullOrEmpty(registerUserDto.FirstName) || string.IsNullOrEmpty(registerUserDto.LastName) || string.IsNullOrEmpty(registerUserDto.Username) || string.IsNullOrEmpty(registerUserDto.Password) || string.IsNullOrEmpty(registerUserDto.ConfirmationPassword))
            {
                throw new ArgumentException("FirstName,LastName,Username or password cannot be empty");
            }
            if(registerUserDto.Password != registerUserDto.ConfirmationPassword)
            {
                throw new ArgumentException("Password and ConfirmationPassword must match.");
            }
            if(registerUserDto.FirstName.Length > 50)
            {
                throw new ArgumentException("FirstName canot have more then 50 chars.");
            }
            if (registerUserDto.LastName.Length > 50)
            {
                throw new ArgumentException("LastName canot have more then 50 chars.");
            }
            if (registerUserDto.Password.Length > 50)
            {
                throw new ArgumentException("Password canot have more then 50 chars.");
            }
            if (registerUserDto.Email.Length > 50)
            {
                throw new ArgumentException("Email canot have more then 50 chars.");
            }
            if (registerUserDto.Username.Length > 25)
            {
                throw new ArgumentException("Username canot have more then 25 chars.");
            }

            // hash data encrypting
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerUserDto.Password);
            byte[] hash = md5CryptoServiceProvider.ComputeHash(passwordBytes);

            string stringHash = Convert.ToHexString(hash);

            //save in DB
            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Password = stringHash, //hashed pass in Hexstring
                Email = registerUserDto.Email,
                Age = registerUserDto.Age,
            };

            _userRepository.Add(user);

        }

        // Login User
        public string LoginUser(LoginUsedDto loginUserDto)
        {
            //Validation
            if (string.IsNullOrEmpty(loginUserDto.Username) || string.IsNullOrEmpty(loginUserDto.Password))
            {
                throw new ArgumentException("Username or password cannot be empty");
            }

            // hash data decryption
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] passwordBytes = Encoding.ASCII.GetBytes(loginUserDto.Password);
            byte[] hash = md5CryptoServiceProvider.ComputeHash(passwordBytes);

            string stringHash = Convert.ToHexString(hash);

            // Finding user from data
            var user = _userRepository.GetAll().Where(x => x.Username == loginUserDto.Username && x.Password == stringHash).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentException("Password or username is wrong");
            }

            return $"Welcome {user.FirstName} {user.LastName}";
        }
    }
}
