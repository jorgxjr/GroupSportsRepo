using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class AssistanceService : IAssistanceService
    {
        IAssistanceRepository assistanceRepository = new AssistanceRepository();
        public List<AssistanceDTO> assistanceByDate(DateTime dateTime)
        {
            return assistanceRepository.assistanceByDate(dateTime);
        }

        public void deleteAssistanceDTO(int id)
        {
            assistanceRepository.deleteAssistanceDTO(id);
        }

        public List<AssistanceDTO> findAll()
        {
            return assistanceRepository.findAll();
        }

        public List<AssistanceDTO> findByCoachId(int coachId, DateTime day)
        {
            return assistanceRepository.findByCoachId(coachId, day);
        }

        public AssistanceDTO findById(int id)
        {
            return assistanceRepository.findById(id);
        }

        public void insertAssistanceDTO(AssistanceDTO assistanceDTO)
        {
            throw new NotImplementedException();
        }

        public string updateAssistanceDTO(List<AssistanceShiftDTO> assistanceShiftDTOs)
        {
            return assistanceRepository.updateAssistanceDTO(assistanceShiftDTOs);
        }
    }
}
