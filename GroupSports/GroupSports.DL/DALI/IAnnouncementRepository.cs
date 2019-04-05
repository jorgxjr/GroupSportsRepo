using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IAnnouncementRepository
    {
        List<announcement> findAll();
        List<AnnouncementDTO> findAllAnnouncementsFromCoach(int coachId);
        announcement findById(int id);
        List<announcement> announcementByCoach(int coachId);
        List<announcement> announcementByAthleteId(int athleteId);
        string setAthletesForAnnouncement(AnnouncementForAthletesDTO announcementForAthletesDTO);
        string insertAnnouncement(announcement announcement);
        string updateAnnouncement(announcement announcement);
        string deleteAnnouncement(int id);
        string deleteAthleteAnnouncement(int id, int announcementId);
    }
}
