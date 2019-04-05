using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class JumpTestViewModel
    {
        JumpTestService jumpTestService = new JumpTestService();

        public List<jumpTest> listJumpTest = new List<jumpTest>();
        public List<jumpTest> listJumpTest2 = new List<jumpTest>();

        public int id { get; set; }
        public double distanceResult { get; set; }
        public int jumpTestTypeId { get; set; }
        public int coachId { get; set; }
        public int athleteId { get; set; }
        public Nullable<int> sessionId { get; set; }
        public System.DateTime date { get; set; }
        public bool available { get; set; }

        public void listJumpById(int id)
        {
            this.listJumpTest = jumpTestService.findByAthleteId(id);
        }

        public void listJumpById2(int id)
        {
            this.listJumpTest2 = jumpTestService.findByAthleteId(id).OrderBy(m => m.date)
                                .ThenByDescending(m => m.id)
                                .ToList();
        }
    }

    

}