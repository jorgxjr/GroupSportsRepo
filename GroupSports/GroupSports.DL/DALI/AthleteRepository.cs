using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class AthleteRepository : IAthleteRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public void deleteAthlete(int id)
        {
            var athlete = context.athelete.FirstOrDefault(x => x.id == id);
            if (athlete != null)
            {
                context.athelete.Remove(athlete);
                context.SaveChanges();
            }
        }

        public List<AthleteDTO> findAll()
        {
            List<AthleteDTO> athletesDTO = new List<AthleteDTO>();

            var athletes = context.athelete
                .Include("user")
                .Where(a => a.available)
                .ToList();

            athletes.ForEach(x => athletesDTO.Add(AthleteDTO.from(x)));
            return athletesDTO;
        }

        public AthleteDTO findById(int id)
        {
            var x = context.athelete
                .Include("user")
                .FirstOrDefault(c => c.id == id && c.available);

            if (x == null)
                return null;

            return AthleteDTO.from(x);
        }

        public List<AthleteDTO> findByName(string name)
        {
            List<AthleteDTO> athletesDTO = new List<AthleteDTO>();

            var athletes = context.athelete
                .Include("user")
                .Where(x => x.user.firstName == name && x.available)
                .ToList();

            athletes.ForEach(x => athletesDTO.Add(AthleteDTO.from(x)));
            return athletesDTO;
        }

        public List<AthleteDTO> atheletesByCoachId(int id)
        {
            List<AthleteDTO> athletesDTO = new List<AthleteDTO>();

            var athletesByCoach = context.coachByAthelete
                .Include("coach")
                .Include("athelete")
                .Where(a => a.coachId == id && a.available)
                .ToList();

            athletesByCoach.ForEach(x => athletesDTO.Add(AthleteDTO.from(x.athelete)));
            return athletesDTO;
        }

        public List<AthleteDTO> atheletesByCoachIdSubAge(int id, int edadInicio, int edadFin)
        {
            List<AthleteDTO> athletesDTO = new List<AthleteDTO>();

            var athletesByCoach = context.coachByAthelete
                .Include("coach")
                .Include("athelete")
                .Where(a => a.coachId == id && a.available)
                .ToList();

            athletesByCoach.ForEach(a => athletesDTO.Add(AthleteDTO.from(a.athelete)));

            List<AthleteDTO> athletesDTOSubAge = new List<AthleteDTO>();
            athletesDTO.ForEach(a => {
                int age = DateTime.Now.Year - a.birthDate.Year;
                if (age >= edadInicio && age <= edadFin)
                    athletesDTOSubAge.Add(a);
            });

            return athletesDTOSubAge;
        }

        public NewAthleteResponseDTO insertAthlete(AthleteDTO athleteDTO)
        {
            if (context.user.FirstOrDefault(u => u.username == athleteDTO.username) != null)
            {
                return new NewAthleteResponseDTO() { response = "El nombre de usuario ya existe", id = 0 };
            }
            else
            {
                var userAdded = context.user.Add(athleteDTO.toUser());
                context.SaveChanges();
                athleteDTO.userId = userAdded.id;

                var athleteAdded = context.athelete.Add(athleteDTO.toAthlete());
                context.athleteDetails.Add(new athleteDetails() {
                    athleteId = athleteAdded.id,
                    available = true
                    //dateOfDetailInserted = DateTime.UtcNow.Date
                });
                context.SaveChanges();
                return new NewAthleteResponseDTO() { response = "Usuario agregado", id = athleteAdded.id };
            }
        }

        public void updateAthlete(AthleteDTO athlete)
        {
            var result = context.athelete
                .Include("user")
                .FirstOrDefault(x => x.id == athlete.id);

            var result2 = context.user
                .FirstOrDefault(x => x.id == athlete.userId);

            if (result != null && result2 != null)
            {
                result.disciplineId = athlete.disciplineId;

                result.user.username = athlete.username;
                result.user.password = athlete.password;
                result.user.userType = athlete.userType;
                result.user.firstName = athlete.firstName;
                result.user.lastName = athlete.lastName;
                result.user.cellPhone = athlete.cellPhone;
                result.user.address = athlete.address;
                result.user.emailAddress = athlete.emailAddress;

                context.SaveChanges();
            }
        }

        public List<AthleteDTO> atheletesByCoachIdUnderAge(int id, int edadFin)
        {
            List<AthleteDTO> athletesDTO = new List<AthleteDTO>();

            var athletesByCoach = context.coachByAthelete
                .Include("coach")
                .Include("athelete")
                .Where(a => a.coachId == id && a.available)
                .ToList();

            athletesByCoach.ForEach(a => athletesDTO.Add(AthleteDTO.from(a.athelete)));

            List<AthleteDTO> athletesDTOSubAge = new List<AthleteDTO>();
            athletesDTO.ForEach(a => {
                int age = DateTime.Now.Year - a.birthDate.Year;
                if (age <= edadFin)
                    athletesDTOSubAge.Add(a);
            });

            return athletesDTOSubAge;
        }
    }
}
