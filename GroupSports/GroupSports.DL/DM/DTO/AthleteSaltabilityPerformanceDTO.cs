using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class AthleteSaltabilityPerformanceDTO
    {
        public int athleteId { get; set; }
        public string athleteName { get; set; }
        public string athletePictureUrl { get; set; }
        public string username { get; set; }
        public int age { get; set; }
        public float averageSaltability { get; set; }
        public float bestJumpMark { get; set; }

        public bool isValid()
        {
            return averageSaltability > 0 && bestJumpMark > 0;
        }

        public static AthleteSaltabilityPerformanceDTO from(athelete athlete, int saltabilityTestTypeId)
        {
            var jumpTests = athlete.jumpTest.Where(j => j.jumpTestTypeId == saltabilityTestTypeId);
            jumpTests = jumpTests.OrderBy(j => j.distanceResult);
            bool containsElements = jumpTests.Count() > 0;

            return new AthleteSaltabilityPerformanceDTO()
            {
                athleteId = athlete.id,
                athleteName = $"{athlete.user.firstName}",
                athletePictureUrl = athlete.user.pictureUrl,
                username = athlete.user.username,
                age = DateTime.Today.Year - athlete.user.birthDate.Year,
                averageSaltability = containsElements ? (float) jumpTests.Average(j => j.distanceResult) : 0,
                bestJumpMark = containsElements ? (float) jumpTests.Max(j => j.distanceResult) : 0
            };
        }
    }
}
