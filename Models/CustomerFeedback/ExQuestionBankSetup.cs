using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExQuestionBankSetup
    {
        public int AssessmentQbId { get; set; }
        public string QuestionBankName { get; set; }
        public string QuestionBankType { get; set; }
        public string Status { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Updatedby { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
