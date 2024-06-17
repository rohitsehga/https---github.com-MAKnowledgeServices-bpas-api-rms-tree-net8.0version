using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonCourse
    {
        public int? Id { get; set; }
        public string PeLogn { get; set; }
        public int? QualificationTypeId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? QualificationId { get; set; }
        public string InstitutionName { get; set; }
        public int? UniversityId { get; set; }
        public int? PassingYear { get; set; }
        public string ApproveStatus { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
