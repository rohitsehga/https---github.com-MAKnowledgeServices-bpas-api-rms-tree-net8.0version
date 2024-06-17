using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonReplaceClient
    {
        public int? Id { get; set; }
        public string TranType { get; set; }
        public int? ReplacingCuIden { get; set; }
        public string ReplacingPeLogn { get; set; }
        public DateTime? ReplacingKickOffDate { get; set; }
        public int? ReplaceWithCuIden { get; set; }
        public string ReplaceWithPeLogn { get; set; }
        public DateTime? ReplacingWithKickOffDate { get; set; }
        public DateTime? ReplaceOnDate { get; set; }
        public string UserComments { get; set; }
        public string ApproveStatus { get; set; }
        public string ApproveUserLognId { get; set; }
        public DateTime? ApproveEntrystamp { get; set; }
        public string ApproveComments { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
