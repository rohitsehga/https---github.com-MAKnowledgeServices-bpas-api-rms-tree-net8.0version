using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExLastClientUnLock
    {
        public int? CuIden { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        /// <summary>
        /// P=Pending to open month;O=Open for the month;C=Closed
        /// </summary>
        public string Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Comments { get; set; }
        public string AdminLognId { get; set; }
        public DateTime? AdminEntryStamp { get; set; }
        public string AdminComments { get; set; }
    }
}
