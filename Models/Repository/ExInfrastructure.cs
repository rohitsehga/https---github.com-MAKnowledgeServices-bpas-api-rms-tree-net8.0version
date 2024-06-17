using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExInfrastructure
    {
        public int? Id { get; set; }
        public string ServerIp { get; set; }
        public string ServerLocation { get; set; }
        public string ServerType { get; set; }
        public string Peopleaccess { get; set; }
        public string Enteredby { get; set; }
        public DateTime? Enteredon { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedon { get; set; }
    }
}
