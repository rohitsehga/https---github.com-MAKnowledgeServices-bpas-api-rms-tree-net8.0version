using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExAccessMaster
    {
        public int Id { get; set; }
        public string PeLogn { get; set; }
        public string ServiceLine { get; set; }
        public string Role { get; set; }
        public byte? Admin { get; set; }
        public byte? Approver { get; set; }
        public byte? Superadmin { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public DateTime? EnddateStamp { get; set; }
        public string EnddateUserlognid { get; set; }
        public string EntityId { get; set; }
    }
}
