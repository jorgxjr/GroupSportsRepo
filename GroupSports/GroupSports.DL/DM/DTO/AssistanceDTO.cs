using GroupSports.DL.DALI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class AssistanceDTO
    {
        public int userId { get; set; }
        public int athleteId { get; set; }
        public string pictureURL { get; set; }
        public string fullName { get; set; }
        public string disciplineName { get; set; }
        public int currentMesocycle { get; set; }
        public int totalMesocycles { get; set; }
        public int currentWeek { get; set; }
        public int totalWeeks { get; set; }
        public DateTime dateTime { get; set; }
        public int weekId { get; set; }
        public string trainingPlanName { get; set; }
        public string mesocycleName { get; set; }

        public List<AssistanceShiftDTO> assistanceShifts = new List<AssistanceShiftDTO>();

        public static AssistanceDTO from(session x, List<session> sessions)
        {
            IMesocycleRepository mesoRepo = new MesocycleRepository();
            IWeekRepository weekRepo = new WeekRepository();

            var mesocycles = mesoRepo.mesocyclesByTrainingPlanIdNoNulls(x.week.mesocycle.trainingPlanId);
            mesocycles.OrderBy(m => m.startDate);

            var weeks = weekRepo.weeksByMesocycleId(x.week.mesocycleId);
            weeks.OrderBy(w => w.startDate);

            int totalMesocyclesOfTP = mesocycles.Count;
            int currentMC = mesocycles.Count(m => m.startDate <= x.sessionDay);

            int totalOfWeeksOfMC = weeks.Count;
            int currentWeek = weeks.Count(w => w.startDate <= x.sessionDay);

            AssistanceDTO assistance = new AssistanceDTO()
            {
                userId = x.athelete.userId,
                athleteId = x.athleteId,
                pictureURL = x.athelete.user.pictureUrl,
                fullName = $"{x.athelete.user.firstName} {x.athelete.user.lastName}",
                disciplineName = x.athelete.discipline.disciplineName,
                currentMesocycle = currentMC,
                totalMesocycles = totalMesocyclesOfTP,
                currentWeek = currentWeek,
                totalWeeks = totalOfWeeksOfMC,
                dateTime = x.sessionDay,
                weekId = x.weekId,
                trainingPlanName = x.week.mesocycle.trainingPlan.name,
                mesocycleName = x.week.mesocycle.mesocycleType.mesocycleName
            };

            sessions.ForEach(s => {
                assistance.assistanceShifts.Add(new AssistanceShiftDTO() {
                    sessionId = s.id,
                    shiftId = s.shiftId,
                    shiftName = s.shift.shiftName,
                    intensityPercentage = s.intensityPercentage,
                    attendance = s.attendance
                });
            });

            return assistance;
        }
    }
}
