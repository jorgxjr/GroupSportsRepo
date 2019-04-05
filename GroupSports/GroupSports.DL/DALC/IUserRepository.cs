using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IUserRepository
    {
        List<user> findAll();
        user findById(int id);
        List<user> findByName(string name);
        void insertUser(user user);
        void updateUser(user user);
        void deleteUser(int id);
        user Login(LoginDTO loginDTO);
    }
}
