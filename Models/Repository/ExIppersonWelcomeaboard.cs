using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonWelcomeaboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Doj { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string ImageName { get; set; }
        public string EmpNo { get; set; }
        public string Dept { get; set; }
        public DateTime? DoB { get; set; }
        public DateTime? DoC { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string WinId { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MailStatusBoard { get; set; }
        public string MailStatusAll { get; set; }
        public string Itstatus { get; set; }
        public string DomainAccount { get; set; }
        public string Fbdays { get; set; }
        public string Status { get; set; }
        public string PublishStatus { get; set; }
    }
}
