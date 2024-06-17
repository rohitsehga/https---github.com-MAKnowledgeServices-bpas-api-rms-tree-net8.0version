using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExClientcontact
    {
        public int Id { get; set; }
        public int CuIden { get; set; }
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? EnteredOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
