using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class CoachRepository : ICoachRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public void deleteCoach(int id)
        {
            var coach = context.coach
                .FirstOrDefault(x => x.id == id);
            if (coach != null)
            {
                context.coach.Remove(coach);
                context.SaveChanges();
            }
        }

        public List<CoachDTO> findAll()
        {
            List<CoachDTO> coachsDTO = new List<CoachDTO>();

            var coachs = context.coach
                .Include("user")
                .ToList();

            coachs.ForEach(x => coachsDTO.Add(CoachDTO.from(x)));
            return coachsDTO;
        }

        public CoachDTO findById(int id)
        {
            var x = context.coach
                .Include("user")
                .FirstOrDefault(c => c.id == id);

            if (x == null)
                return null;

            return CoachDTO.from(x);
        }

        public List<CoachDTO> findByName(string name)
        {
            List<CoachDTO> coachsDTO = new List<CoachDTO>();

            var coachs = context.coach
                .Include("user")
                .Where(x => x.user.firstName == name)
                .ToList();

            coachs.ForEach(x => coachsDTO.Add(CoachDTO.from(x)));
            return coachsDTO;
        }

        public void insertCoach(CoachDTO coachDTO)
        {
            context.user.Add(coachDTO.toUser());
            context.SaveChanges();

            context.coach.Add(coachDTO.toCoach());
            context.SaveChanges();
        }

        public void updateCoach(CoachDTO coach)
        {
            var result = context.coach
                .Include("user")
                .FirstOrDefault(x => x.id == coach.id);

            var result2 = context.user
                .FirstOrDefault(x => x.id == coach.userId);

            if (result != null && result2 != null)
            {
                result.edad = coach.edad;
                result.yearsOfExperience = coach.yearsOfExperience;

                result.user.username = coach.username;
                result.user.password = coach.password;
                result.user.user_type = coach.user_type;
                result.user.firstName = coach.firstName;
                result.user.lastName = coach.lastName;
                result.user.cellPhone = coach.cellPhone;
                result.user.address = coach.address;
                result.user.emailAddress = coach.emailAddress;

                context.SaveChanges();
            }
        }
    }
}
