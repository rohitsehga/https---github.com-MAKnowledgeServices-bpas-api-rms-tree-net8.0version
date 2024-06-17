using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExAssessmentScheduling
    {
        public int? AssessmentId { get; set; }
        public string RandomQuestion { get; set; }
        public int? NoOfQuestions { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? LastupdatedOn { get; set; }
        public string LastupdatedBy { get; set; }
    }
}
