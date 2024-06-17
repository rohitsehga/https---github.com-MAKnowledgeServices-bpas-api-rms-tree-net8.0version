using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExCategory
    {
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int? NoOfQuestions { get; set; }
        public int? PassingScore { get; set; }
        public bool? RandomSeq { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
