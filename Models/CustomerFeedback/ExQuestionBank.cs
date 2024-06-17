using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExQuestionBank
    {
        public int QuestionId { get; set; }
        public int? AssessmentQbId { get; set; }
        public string Question { get; set; }
        public string ResponseType { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public string Option6 { get; set; }
        public string Option7 { get; set; }
        public string Option8 { get; set; }
        public string Option9 { get; set; }
        public string Option10 { get; set; }
        public string Option11 { get; set; }
        public string Option12 { get; set; }
        public string Other { get; set; }
        public string MediaPath { get; set; }
        public string CorrectOption { get; set; }
        public string CategoryId { get; set; }
        public int? NoOfOptions { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
