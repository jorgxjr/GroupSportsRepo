using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class AthleteDTO
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
        public float speedTestProm { get; set; }

        //athlete
        public string disciplineName { get; set; }
        public int disciplineId { get; set; }
        public int userId { get; set; }

        public athelete toAthlete()
        {
            return new athelete()
            {
                disciplineId = disciplineId,
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
        public static AthleteDTO from(athelete x)
        {
            return new AthleteDTO()
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
                disciplineName = x.discipline.disciplineName,
                disciplineId = x.disciplineId,
                userId = x.userId,
                pictureUrl = x.user.pictureUrl,
                birthDate = x.user.birthDate
            };
        }
    }
}
