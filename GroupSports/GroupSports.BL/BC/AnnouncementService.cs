using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class AnnouncementService : IAnnouncementService
    {
        IAnnouncementRepository announcementRepository = new AnnouncementRepository();

        public List<announcement> announcementByAthleteId(int athleteId)
        {
            return announcementRepository.announcementByAthleteId(athleteId);
        }

        public List<announcement> announcementByCoach(int coachId)
        {
            return announcementRepository.announcementByCoach(coachId);
        }

        public string deleteAnnouncement(int id)
        {
            return announcementRepository.deleteAnnouncement(id);
        }

        public string deleteAthleteAnnouncement(int id, int announcementId)
        {
            return announcementRepository.deleteAthleteAnnouncement(id, announcementId);
        }

        public List<announcement> findAll()
        {
            return announcementRepository.findAll();
        }

        public List<AnnouncementDTO> findAllAnnouncementsFromCoach(int coachId)
        {
            return announcementRepository.findAllAnnouncementsFromCoach(coachId);
        }

        public announcement findById(int id)
        {
            return announcementRepository.findById(id);
        }

        public string insertAnnouncement(announcement announcement)
        {
            return announcementRepository.insertAnnouncement(announcement);
        }

        public string setAthletesForAnnouncement(AnnouncementForAthletesDTO announcementForAthletesDTO)
        {
            return announcementRepository.setAthletesForAnnouncement(announcementForAthletesDTO);
        }

        public string updateAnnouncement(announcement announcement)
        {
            return announcementRepository.updateAnnouncement(announcement);
        }
    }
}
