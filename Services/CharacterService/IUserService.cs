using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exam.Dtos.User;

namespace exam.Services.UserService
{
    public interface IUserService
    {   
        Task <ServiceResponse<List<GetUserDto>>> GetAllUser();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateUserDto);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}