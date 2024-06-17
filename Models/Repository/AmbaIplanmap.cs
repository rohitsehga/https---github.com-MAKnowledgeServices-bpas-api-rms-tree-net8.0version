using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class AmbaIplanmap
    {
        public string PeLogn { get; set; }
        public string PeName { get; set; }
        public string Activedirectoryname { get; set; }
        public string Activedirectoryusername { get; set; }
        public string Title { get; set; }
        public string EmailId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Active { get; set; }
        public int? PersonId { get; set; }
    }
}
