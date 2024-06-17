using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExEmploymentType
    {
        public int EmploymentType { get; set; }
        public string EmploymentTypeName { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string UserLognid { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
