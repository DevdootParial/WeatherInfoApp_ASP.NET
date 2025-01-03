using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        public static bool Register(UserDTO userDto) // For registration
        {
            var user = GetMapper().Map<User>(userDto);
            return DataAccess.UserData().Create(user);
        }

        public static UserDTO Login(string username, string password)
        {
            // Use the repository's Get() method to retrieve all users
            var users = DataAccess.UserData().Get();

            // Validate the credentials
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null ? GetMapper().Map<UserDTO>(user) : null;
        }


        public static List<UserDTO> Get()
        {
            var users = DataAccess.UserData().Get();
            return GetMapper().Map<List<UserDTO>>(users);
        }

        public static UserDTO Get(int id)
        {
            var user = DataAccess.UserData().Get(id);
            return GetMapper().Map<UserDTO>(user);
        }

        public static bool Update(UserDTO obj)
        {
            var user = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Update(user);
        }

        public static bool Delete(int id)
        {
            return DataAccess.UserData().Delete(id);
        }
    }
}
