using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class AnnouncementDTO
    {
        public int id { get; set; }
        public string announcementTitle { get; set; }
        public string announcementDetail { get; set; }
        public int coachId { get; set; }

        public List<string> athletesNames = new List<string>();
    }
}
