using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerGeo
    {
        public int Sl { get; set; }
        public int CuIden { get; set; }
        public int ProjId { get; set; }
        public string PeLogn { get; set; }
        public string Group { get; set; }
        public string Geo { get; set; }
        public DateTime? KickOff { get; set; }
        public DateTime? DateOfMove { get; set; }
        public DateTime? GeoStartdt { get; set; }
        public DateTime? GeoEnddate { get; set; }
        public string Status { get; set; }
        public DateTime Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
