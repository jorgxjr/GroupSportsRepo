using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class AssistanceRepository : IAssistanceRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public List<AssistanceDTO> assistanceByDate(DateTime dateTime)
        {
            //List<AssistanceDTO> assistanceDTOs = new List<AssistanceDTO>();

            //var athletes = context.session
            //    .Where(a => a.sessionDay == dateTime && a.available)
            //    .ToList();

            //athletes.ForEach(x => assistanceDTOs.Add(AssistanceDTO.from(x)));
            //return assistanceDTOs;
            return null;
        }

        public void deleteAssistanceDTO(int id)
        {
            var result = context.session.FirstOrDefault(x => x.id == id);
            if (result != null)
            {
                result.attendance = false;
                context.SaveChanges();
            }
        }

        public List<AssistanceDTO> findAll()
        {
            //List<AssistanceDTO> assistanceDTOs = new List<AssistanceDTO>();

            //var sessions = context.session
            //    .Where(a => a.available)
            //    .ToList();

            //sessions.ForEach(x => assistanceDTOs.Add(AssistanceDTO.from(x)));
            //return assistanceDTOs;
            return null;
        }

        public List<AssistanceDTO> findByCoachId(int coachId, DateTime day)
        {
            List<AssistanceDTO> assistanceDTOs = new List<AssistanceDTO>();

            List<session> sessions = context.session
                .Where(a => a.coachId == coachId && 
                        a.sessionDay == day &&
                        a.available)
                .ToList();

            sessions.ForEach(x => {
                if (!assistanceDTOs.Exists(a => a.athleteId == x.athleteId && a.dateTime == x.sessionDay && a.weekId == x.weekId))
                    assistanceDTOs.Add(AssistanceDTO.from(x, sessions
                        .Where(s => s.athleteId == x.athleteId && s.weekId == x.weekId)
                        .OrderBy(s => s.shiftId)
                        .ToList()));
            });

            return assistanceDTOs;
        }

        public AssistanceDTO findById(int id)
        {
            //var session = context.session.FirstOrDefault(c => c.id == id && c.available);

            //if (session == null)
            //    return null;

            //return AssistanceDTO.from(session);
            return null;
        }

        public void insertAssistanceDTO(AssistanceDTO assistanceDTO)
        {
            throw new NotImplementedException();
        }

        public string updateAssistanceDTO(List<AssistanceShiftDTO> assistanceShiftDTOs)
        {
            try
            {
                assistanceShiftDTOs.ForEach(a =>
                {
                    var ses = context.session.FirstOrDefault(s => s.id == a.sessionId);
                    if (ses != null)
                    {
                        ses.intensityPercentage = a.intensityPercentage;
                        ses.attendance = a.attendance;
                    }
                });
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
