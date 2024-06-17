using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceSkill
    {
        public int? Id { get; set; }
        public string PeLogn { get; set; }
        public string SkillCode { get; set; }
        public int? Proficiencyscale { get; set; }
        public int? Requiredrefreshtime { get; set; }
        public string Shortskilldescription { get; set; }
        public string AquiredAt { get; set; }
        public string ApproveStatus { get; set; }
        public string ApproveBy { get; set; }
        public DateTime? ApproveOn { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
