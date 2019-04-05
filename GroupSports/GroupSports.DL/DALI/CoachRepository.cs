using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class CoachRepository : ICoachRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public void deleteCoach(int id)
        {
            var coach = context.coach.FirstOrDefault(x => x.id == id);
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
                .Where(c => c.available)
                .ToList();

            coachs.ForEach(x => coachsDTO.Add(CoachDTO.from(x)));
            return coachsDTO;
        }

        public List<CoachDTO> findByAthleteId(int athleteId)
        {
            List<CoachDTO> coachsDTO = new List<CoachDTO>();

            var coachsByAth = context.coachByAthelete
                .Include("coach")
                .Where(c => c.available && c.atheleteId == athleteId)
                .ToList();

            coachsByAth.ForEach(x => coachsDTO.Add(CoachDTO.from(x.coach)));
            return coachsDTO;
        }

        public CoachDTO findById(int id)
        {
            var x = context.coach
                .Include("user")
                .FirstOrDefault(c => c.id == id && c.available);

            if (x == null)
                return null;

            return CoachDTO.from(x);
        }

        public List<CoachDTO> findByName(string name)
        {
            List<CoachDTO> coachsDTO = new List<CoachDTO>();

            var coachs = context.coach
                .Include("user")
                .Where(x => x.user.firstName == name && x.available)
                .ToList();

            coachs.ForEach(x => coachsDTO.Add(CoachDTO.from(x)));
            return coachsDTO;
        }

        public void insertAthleteOnCoach(int athleteId, int coachId)
        {
            coachByAthelete coachByAthl = new coachByAthelete();
            coachByAthl.coachId = coachId;
            coachByAthl.atheleteId = athleteId;
            coachByAthl.available = true;

            context.coachByAthelete.Add(coachByAthl);
            context.SaveChanges();
        }

        public void insertCoach(CoachDTO coachDTO)
        {
            var userAdded = context.user.Add(coachDTO.toUser());
            context.SaveChanges();
            coachDTO.userId = userAdded.id;

            context.coach.Add(coachDTO.toCoach());
            context.SaveChanges();
        }

        public string PostByAtheleteNameOnCoach(int coachId, string athleteName)
        {
            athelete athleteFinded = context.athelete.Include("user").FirstOrDefault(a => a.user.username == athleteName);

            if (athleteFinded != null)
            {
                coachByAthelete coachByAthl = new coachByAthelete();
                coachByAthl.coachId = coachId;
                coachByAthl.atheleteId = athleteFinded.id;
                context.coachByAthelete.Add(coachByAthl);
                context.SaveChanges();
                return "Atleta encontrado";
            }
            else
            {
                return "Atleta no encontrado";
            }
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
                result.user.userType = coach.userType;
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
