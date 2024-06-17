using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExAssesmentSetup
    {
        public int AssessmentId { get; set; }
        public string AssessmentName { get; set; }
        public int? CuIden { get; set; }
        public string ProjectName { get; set; }
        public int? AssessmentQbId { get; set; }
        public string AssessmentOwner { get; set; }
        public string AssessmentPurpose { get; set; }
        public string AssessmentType { get; set; }
        public DateTime? AssessmentStartDate { get; set; }
        public DateTime? AssessmentEndDate { get; set; }
        public string AssessmentFrequency { get; set; }
        public string AssessmentComments { get; set; }
        public string AssessmentStatus { get; set; }
        public string Surveytype { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Updatedby { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
