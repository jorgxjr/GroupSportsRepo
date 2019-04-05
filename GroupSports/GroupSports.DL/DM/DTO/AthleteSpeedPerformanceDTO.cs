using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class AthleteSpeedPerformanceDTO
    {
        public int athleteId { get; set; }
        public string athleteName { get; set; }
        public string athletePictureUrl { get; set; }
        public string username { get; set; }
        public int averageHours { get; set; }
        public int averageMinutes { get; set; }
        public int averageSeconds { get; set; }
        public int averageMilliseconds { get; set; }
        public int bestMarkHour { get; set; }
        public int bestMarkMinute { get; set; }
        public int bestMarkSecond { get; set; }
        public int bestMarkMillisecond { get; set; }
        public int age { get; set; }

        public bool isValid()
        {
            return (averageHours + averageMinutes + averageSeconds + averageMilliseconds) > 0 &&
                   (bestMarkHour + bestMarkMinute + bestMarkSecond + bestMarkMillisecond) > 0;
        }

        public static AthleteSpeedPerformanceDTO from(athelete athlete, int meters)
        {
            var speedTests = athlete.speedTest.Where(s => s.meters == meters);
            speedTests = speedTests.OrderBy(s => ((s.hours*3600) + (s.minutes*60) + s.seconds + (s.milliseconds*1.0/1000)));
            bool containsElements = speedTests.Count() > 0;

            return new AthleteSpeedPerformanceDTO()
            {
                athleteId = athlete.id,
                athleteName = $"{athlete.user.firstName}",
                athletePictureUrl = athlete.user.pictureUrl,
                username = athlete.user.username,

                averageHours = containsElements ? (int)speedTests.Average(s => s.hours) : 0,
                averageMinutes = containsElements ? (int)speedTests.Average(s => s.minutes) : 0,
                averageSeconds = containsElements ? (int)speedTests.Average(s => s.seconds) : 0,
                averageMilliseconds = containsElements ? (int)speedTests.Average(s => s.milliseconds) : 0,

                bestMarkHour = containsElements ? speedTests.FirstOrDefault().hours : 0,
                bestMarkMinute = containsElements ? speedTests.FirstOrDefault().minutes : 0,
                bestMarkSecond = containsElements ? speedTests.FirstOrDefault().seconds : 0,
                bestMarkMillisecond = containsElements ? speedTests.FirstOrDefault().milliseconds : 0,

                age = DateTime.Today.Year - athlete.user.birthDate.Year
            };
        }
    }
}
