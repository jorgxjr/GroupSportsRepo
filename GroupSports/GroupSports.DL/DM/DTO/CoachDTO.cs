using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM
{
    public class CoachDTO
    {
        //user
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cellPhone { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public string pictureUrl { get; set; }
        public DateTime birthDate { get; set; }

        //coach
        public int edad { get; set; }
        public int yearsOfExperience { get; set; }
        public int userId { get; set; }

        public coach toCoach()
        {
            return new coach()
            {
                edad = edad,
                yearsOfExperience = yearsOfExperience,
                userId = userId,
                available = true
            };
        }
        public user toUser()
        {
            return new user()
            {
                username = username,
                password = password,
                userType = userType,
                firstName = firstName,
                lastName = lastName,
                cellPhone = cellPhone,
                address = address,
                emailAddress = emailAddress,
                pictureUrl = pictureUrl,
                birthDate = birthDate,
                available = true
            };
        }
        public static CoachDTO from(coach x)
        {
            return new CoachDTO()
            {
                id = x.id,
                username = x.user.username,
                password = x.user.password,
                userType = x.user.userType,
                firstName = x.user.firstName,
                lastName = x.user.lastName,
                cellPhone = x.user.cellPhone,
                address = x.user.address,
                emailAddress = x.user.emailAddress,
                edad = x.edad,
                yearsOfExperience = x.yearsOfExperience,
                userId = x.userId,
                pictureUrl = x.user.pictureUrl,
                birthDate = x.user.birthDate
            };
        }
    }
}
