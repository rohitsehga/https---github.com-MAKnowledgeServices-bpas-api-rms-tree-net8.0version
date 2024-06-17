using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExType
    {
        public int TypeId { get; set; }
        public string TypeDesc { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
