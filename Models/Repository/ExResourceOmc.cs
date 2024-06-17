﻿using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceOmc
    {
        public int? CuIden { get; set; }
        public string PeLogn { get; set; }
        public string ClientAnalystName { get; set; }
        public DateTime? KickOffDt { get; set; }
        public int? Sl { get; set; }
        public DateTime? DueCallDt { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? CalledDate { get; set; }
        public string Comments { get; set; }
        public string UserLognId { get; set; }
        public string UserDesg { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
    }
}
