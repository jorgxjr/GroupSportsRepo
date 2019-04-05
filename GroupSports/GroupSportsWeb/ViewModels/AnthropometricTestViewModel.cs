using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class AnthropometricTestViewModel
    {
        public AntropometricTestService antropometricTestService = new AntropometricTestService();
        public List<anthropometricTest> listAntropometricTest = new List<anthropometricTest>();

        public int id { get; set; }
        public string size { get; set; }
        public double weight { get; set; }
        public double wingspan { get; set; }
        public double bodyFatPercentage { get; set; }
        public double leanBodyPercentage { get; set; }
        public int athleteId { get; set; }
        public int coachId { get; set; }
        public System.DateTime date { get; set; }
        public bool available { get; set; }

        internal void listById(int id)
        {
            this.listAntropometricTest = antropometricTestService.findByAthleteId(id);

        }
    }

    
}