using Dropshiping.BackEnd.Dtos.UserDtos;

namespace Dropshiping.BackEnd.Services.UserServices.Interface
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginUsedDto loginUserDto);
    }
}
