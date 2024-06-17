using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.CustomerFeedback
{
    public partial class ExUserResponse
    {
        public int Id { get; set; }
        public string Usermailid { get; set; }
        public int? Assesmentid { get; set; }
        public int? QuestionId { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string Answer6 { get; set; }
        public string Answer7 { get; set; }
        public string Answer8 { get; set; }
        public string Answer9 { get; set; }
        public string Answer10 { get; set; }
        public string Answer11 { get; set; }
        public string Answer12 { get; set; }
        public string Other { get; set; }
        public int? RemainingTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
