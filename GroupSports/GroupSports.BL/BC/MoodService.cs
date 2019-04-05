using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class MoodService : IMoodService
    {
        IMoodRepository moodRepository = new MoodRepository();
        public string deleteMood(int id)
        {
            return moodRepository.deleteMood(id);
        }

        public List<mood> findAll()
        {
            return moodRepository.findAll();
        }

        public List<mood> findByAthleteId(int id)
        {
            return moodRepository.findByAthleteId(id);
        }

        public List<mood> findByAthleteIdAndDay(int id, DateTime day)
        {
            return moodRepository.findByAthleteIdAndDay(id,day);
        }

        public mood findById(int id)
        {
            return moodRepository.findById(id);
        }

        public string insertMood(mood mood)
        {
            return moodRepository.insertMood(mood);
        }

        public string updateMood(mood mood)
        {
            return moodRepository.updateMood(mood);
        }

        public string updateMoodResponse(mood mood)
        {
            return moodRepository.updateMoodResponse(mood);
        }
    }
}
