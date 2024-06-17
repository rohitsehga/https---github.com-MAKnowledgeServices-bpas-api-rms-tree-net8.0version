using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class QAvailableField
    {
        public int FieldId { get; set; }
        public string ReferDbname { get; set; }
        public string ReferTableName { get; set; }
        public string ReferFieldName { get; set; }
        public string ShowFieldName { get; set; }
        public string FieldType { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
