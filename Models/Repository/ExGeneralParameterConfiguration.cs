using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExGeneralParameterConfiguration
    {
        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string ParametervalueType { get; set; }
    }
}
