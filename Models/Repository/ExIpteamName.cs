using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpteamName
    {
        public string TnCode { get; set; }
        public string TnName { get; set; }
        public string TnLognid { get; set; }
        public string TnStatus { get; set; }
        public DateTime? TnEntrystamp { get; set; }
    }
}
