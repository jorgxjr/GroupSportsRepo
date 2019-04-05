using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        group_sportsEntities context = new group_sportsEntities();

        public List<announcement> announcementByAthleteId(int athleteId)
        {
            var announceByAthletes = context.announcementByAthlete
               .Where(aa => aa.athleteId == athleteId && aa.available)
               .OrderByDescending(aa => aa.announcement.id)
               .ToList();

            List<announcement> announces = new List<announcement>();
            announceByAthletes.ForEach(aa => announces.Add(context.announcement.FirstOrDefault(a => a.id == aa.announcementId && a.available)));

            return announces;
        }

        public List<announcement> announcementByCoach(int coachId)
        {
            var announceByCoach = context.announcement
               .Where(a => a.coachId == coachId && a.available)
               .ToList();

            return announceByCoach;
        }

        public string deleteAnnouncement(int id)
        {
            try
            {
                var announce = context.announcement.FirstOrDefault(x => x.id == id);
                if (announce != null)
                {
                    context.announcement.Remove(announce);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string deleteAthleteAnnouncement(int id, int announcementId)
        {
            try
            {
                var aba = context.announcementByAthlete.FirstOrDefault(x => x.athleteId == id && x.announcementId == announcementId);
                if (aba != null)
                {
                    context.announcementByAthlete.Remove(aba);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<announcement> findAll()
        {
            return context.announcement.Where(a => a.available).ToList();
        }

        public List<AnnouncementDTO> findAllAnnouncementsFromCoach(int coachId)
        {
            List<AnnouncementDTO> announcementDTOs = new List<AnnouncementDTO>();

            var announcements = context.announcement
                .Where(a => a.coachId == coachId && a.available)
                .ToList();
            announcements.Reverse();

            announcements.ForEach(a => {
                announcementDTOs.Add(new AnnouncementDTO() {
                    id = a.id,
                    announcementTitle = a.announcementTitle,
                    announcementDetail = a.announcementDetail,
                    coachId = a.coachId,
                    athletesNames = a.announcementByAthlete.Select(ab => ab.athelete.user.username).ToList()
                });
            });

            return announcementDTOs;
        }

        public announcement findById(int id)
        {
            return context.announcement.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertAnnouncement(announcement announcement)
        {
            try
            {
                announcement.available = true;
                context.announcement.Add(announcement);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string setAthletesForAnnouncement(AnnouncementForAthletesDTO announcementForAthletesDTO)
        {
            try
            {
                announcement announcement = new announcement();
                announcement.announcementTitle = announcementForAthletesDTO.announcementTitle;
                announcement.announcementDetail = announcementForAthletesDTO.announcementDetail;
                announcement.coachId = announcementForAthletesDTO.coachId;
                announcement.available = true;
                var announce = context.announcement.Add(announcement);
                context.SaveChanges();

                List<AthleteIdDTO> athletesId = announcementForAthletesDTO.athletesId;
                athletesId.ForEach(a => {
                    announcementByAthlete announceByAthlete = new announcementByAthlete();
                    announceByAthlete.athleteId = a.athleteId;
                    announceByAthlete.announcementId = announce.id;
                    announceByAthlete.available = true;
                    context.announcementByAthlete.Add(announceByAthlete);
                });

                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateAnnouncement(announcement announcement)
        {
            try
            {
                var result = context.announcement.FirstOrDefault(x => x.id == announcement.id);
                if (result != null)
                {
                    result.announcementTitle = announcement.announcementTitle;
                    result.announcementDetail = announcement.announcementDetail;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
    }
}
