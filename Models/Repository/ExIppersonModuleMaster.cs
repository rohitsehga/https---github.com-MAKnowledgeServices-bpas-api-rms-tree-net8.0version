using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonModuleMaster
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string Status { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string UserLogn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string Screens { get; set; }
    }
}
