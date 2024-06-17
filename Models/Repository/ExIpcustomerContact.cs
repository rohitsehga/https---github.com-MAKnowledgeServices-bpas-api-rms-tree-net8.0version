using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerContact
    {
        public int CuIden { get; set; }
        public string CuCode { get; set; }
        public int Sl { get; set; }
        public string Contactname { get; set; }
        public string Responsibility { get; set; }
        public string Location { get; set; }
        public string Contactnumber { get; set; }
        public string Email { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Address { get; set; }
        public string Winlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Contactfor { get; set; }
        public string Userlognid { get; set; }
    }
}
