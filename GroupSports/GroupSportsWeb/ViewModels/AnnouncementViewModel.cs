using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DM.DTO;
using GroupSports.BL.BC;
using GroupSports.DL.DM;


namespace GroupSportsWeb.ViewModels
{
    public class AnnouncementViewModel
    {
        public int id { get; set; }
        public string announcementTitle { get; set; }
        public string announcementDetail { get; set; }
        public int coachId { get; set; }
        public AnnouncementDTO announcementDTO { get; set; }
        public List<AnnouncementDTO> listAnnouncementsDTO = new List<AnnouncementDTO>();
        public AnnouncementService announcementService = new AnnouncementService();
        public List<string> athletesNames = new List<string>();

        public void FillByCoachID(int id)
        {
            this.listAnnouncementsDTO = announcementService.findAllAnnouncementsFromCoach(id);
        }

        public void Add(announcement announcement)
        {
            announcementService.insertAnnouncement(announcement);
        }
    }
}