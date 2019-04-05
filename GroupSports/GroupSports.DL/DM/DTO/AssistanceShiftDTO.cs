using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class AssistanceShiftDTO
    {
        public int sessionId { get; set; }
        public int shiftId { get; set; }
        public string shiftName { get; set; }
        public double? intensityPercentage { get; set; }
        public bool attendance { get; set; }
    }
}
