using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class UserRepository : IUserRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public void deleteUser(int id)
        {
            var user = context.user.FirstOrDefault(x => x.id == id);
            if (user != null)
            {
                context.user.Remove(user);
                context.SaveChanges();
            }
        }

        public List<user> findAll()
        {
            return context.user.ToList();
        }

        public user findById(int id)
        {
            return context.user.FirstOrDefault(x => x.id == id);
        }

        public List<user> findByName(string name)
        {
            return context.user.Where(x => x.firstName == name).ToList();
        }

        public void insertUser(user user)
        {
            context.user.Add(user);
            context.SaveChanges();
        }

        public user Login(LoginDTO loginDTO)
        {
            return context.user
                .FirstOrDefault(x => x.username.Equals(loginDTO.userName, StringComparison.OrdinalIgnoreCase)
                                && x.password.Equals(loginDTO.password));
        }

        public void updateUser(user user)
        {
            var result = context.user.FirstOrDefault(x => x.id == user.id);
            if (result != null)
            {
                result.username = user.username;
                result.password = user.password;
                result.firstName = user.firstName;
                result.lastName = user.lastName;
                result.cellPhone = user.cellPhone;
                result.address = user.address;
                result.emailAddress = user.emailAddress;
                context.SaveChanges();
            }
        }
    }
}
