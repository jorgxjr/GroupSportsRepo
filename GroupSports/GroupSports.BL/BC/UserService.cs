using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class UserService : IUserService
    {
        IUserRepository userRepository = new UserRepository();
        public void deleteUser(int user)
        {
            userRepository.deleteUser(user);
        }

        public List<user> findAll()
        {
            return userRepository.findAll();
        }

        public user findById(int id)
        {
            return userRepository.findById(id);
        }

        public List<user> findByName(string name)
        {
            return userRepository.findByName(name);
        }

        public void insertUser(user user)
        {
            userRepository.insertUser(user);
        }

        public user Login(LoginDTO loginDTO)
        {
            return userRepository.Login(loginDTO);
        }

        public int getUserLoggedTypeId(int userId)
        {
            return userRepository.getUserLoggedTypeId(userId);
        }

        public void updateUser(user id)
        {
            userRepository.updateUser(id);
        }
    }
}
