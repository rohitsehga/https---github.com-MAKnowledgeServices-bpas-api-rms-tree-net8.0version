﻿using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonDesg
    {
        public string PeLogn { get; set; }
        public string PeDesg { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
    }
}
