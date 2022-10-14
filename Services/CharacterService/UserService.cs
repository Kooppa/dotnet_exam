using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using exam.Dtos.User;

namespace exam.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> Users = new List<User> {
            new User(),
            new User{ Id = 1, Name = "Gabriel"}
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            User User = _mapper.Map<User>(newUser);
            User.Id = Users.Max(c => c.Id)+1;
            Users.Add(User);
            // Users.Add(_mapper.Map<User>(newUser));
            serviceResponse.Data = Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> response = new ServiceResponse<List<GetUserDto>>();

            try 
            {
                User User = Users.First(c => c.Id == id);

                Users.Remove(User);
                response.Data = Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();

        
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUser()
        {
            return new ServiceResponse<List<GetUserDto>> {
                Data = Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList()
                };
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var User = Users.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(User);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updateUser)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();

            try {
            User User = Users.FirstOrDefault(c => c.Id == updateUser.Id);

            _mapper.Map(updateUser, User);
            // User.Name = updateUser.Name;
            // User.UserType = updateUser.UserType;
            // User.Email = updateUser.Email;
            // User.Phone = updateUser.Phone;
            // User.Directory = updateUser.Directory;
            // User.Class = updateUser.Class;

            response.Data = _mapper.Map<GetUserDto>(User);
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}