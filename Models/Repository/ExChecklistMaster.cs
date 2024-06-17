using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExChecklistMaster
    {
        public string ChecklistType { get; set; }
        public int ChecklistId { get; set; }
        public string ChecklistDesc { get; set; }
        public string ChecklistNote { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Enteredby { get; set; }
        public string Status { get; set; }
    }
}
