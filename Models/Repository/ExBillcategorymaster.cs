using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExBillcategorymaster
    {
        public int BillcatId { get; set; }
        public string BillcatName { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Lognid { get; set; }
        public string Status { get; set; }
    }
}
