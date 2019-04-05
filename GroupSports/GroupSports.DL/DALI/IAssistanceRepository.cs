using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IAssistanceRepository
    {
        List<AssistanceDTO> findAll();
        AssistanceDTO findById(int id);
        List<AssistanceDTO> findByCoachId(int coachId, DateTime day);
        List<AssistanceDTO> assistanceByDate(DateTime dateTime);
        void insertAssistanceDTO(AssistanceDTO assistanceDTO);
        string updateAssistanceDTO(List<AssistanceShiftDTO> assistanceShiftDTOs);
        void deleteAssistanceDTO(int id);
    }
}
