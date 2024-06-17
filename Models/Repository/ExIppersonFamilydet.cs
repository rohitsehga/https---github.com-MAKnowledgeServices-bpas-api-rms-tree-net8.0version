using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonFamilydet
    {
        public string PeLogn { get; set; }
        public int Sl { get; set; }
        public int? RelationId { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public int? IsDependent { get; set; }
        public int? BloodGroup { get; set; }
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public DateTime? Dom { get; set; }
        public string LastUpdatedBy { get; set; }
        public string ConfirmStatus { get; set; }
        public string ConfirmBy { get; set; }
        public DateTime? ConfirmOn { get; set; }
    }
}
