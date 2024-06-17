using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExSkillsetMasterLevel
    {
        public int? LevelId { get; set; }
        public string Level { get; set; }
        public string Status { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
    }
}
