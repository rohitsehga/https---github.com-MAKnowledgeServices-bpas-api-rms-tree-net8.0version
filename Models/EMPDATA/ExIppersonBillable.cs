using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonBillable
    {
        public int Id { get; set; }
        public string PeLogn { get; set; }
        public string Isbillable { get; set; }
        public DateTime? BillableStartdt { get; set; }
        public DateTime? BillableEnddt { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Lastupdatedon { get; set; }
        public string Lastupdatedby { get; set; }
    }
}
