using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class SessionDTO
    {
        public SessionDTO(session s)
        {
            id = s.id;
            sessionDay = s.sessionDay;
            intensityPercentage = s.intensityPercentage;
            shiftId = s.shiftId;
            weekId = s.weekId;
            coachId = s.coachId;
            athleteId = s.athleteId;
            attendance = s.attendance;
            pictureURL = s.athelete.user.pictureUrl;
            username = s.athelete.user.username;
            trainingPlanName = s.week.mesocycle.trainingPlan.name;
            mesocycleName = s.week.mesocycle.mesocycleType.mesocycleName;
            binnacleDetail = s.binnacleDetail.Where(b => b.available).ToList();
            shift = s.shift;
        }
        public int id { get; set; }
        public System.DateTime sessionDay { get; set; }
        public Nullable<double> intensityPercentage { get; set; }
        public int shiftId { get; set; }
        public int weekId { get; set; }
        public int coachId { get; set; }
        public int athleteId { get; set; }
        public bool attendance { get; set; }
        public string pictureURL { get; set; }
        public string username { get; set; }
        public string trainingPlanName { get; set; }
        public string mesocycleName { get; set; }
        public ICollection<binnacleDetail> binnacleDetail { get; set; }
        public shift shift { get; set; }
    }
}
