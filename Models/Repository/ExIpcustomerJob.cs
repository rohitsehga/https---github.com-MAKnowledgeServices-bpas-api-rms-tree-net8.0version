using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerJob
    {
        public int CuIden { get; set; }
        public string CuCode { get; set; }
        public int? ProjId { get; set; }
        public int Sl { get; set; }
        public string Jobrefno { get; set; }
        public string Contractrefno { get; set; }
        public string AcMngr { get; set; }
        public string Contactname { get; set; }
        public string Clientgeo { get; set; }
        public DateTime? Startdt { get; set; }
        public DateTime? Enddt { get; set; }
        public string Clientgroup { get; set; }
        public string Billto { get; set; }
        public string Emailcc { get; set; }
        public string Billfrequency { get; set; }
        public string Modeofbill { get; set; }
        public string Presentationcurrency { get; set; }
        public string Billcurrency { get; set; }
        public string Billaddr1 { get; set; }
        public string Billaddr2 { get; set; }
        public string Billaddr3 { get; set; }
        public string Billaddr4 { get; set; }
        public string Billaddr5 { get; set; }
        public string Comments { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string Billpersonname { get; set; }
        public int? Cityid { get; set; }
    }
}
