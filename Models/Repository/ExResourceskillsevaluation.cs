using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceskillsevaluation
    {
        public string PeLogn { get; set; }
        public int? CuIden { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        /// <summary>
        /// Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N
        /// </summary>
        public string CommWritten { get; set; }
        /// <summary>
        /// Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N
        /// </summary>
        public string CommVerbal { get; set; }
        /// <summary>
        /// Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N
        /// </summary>
        public string AtdDataaccuracy { get; set; }
        public string AtdPresentation { get; set; }
        /// <summary>
        /// Yes: Y, No:N
        /// </summary>
        public string Proactive { get; set; }
        /// <summary>
        /// Yes: Y, No:N
        /// </summary>
        public string Responsiveness { get; set; }
        /// <summary>
        /// Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N
        /// </summary>
        public string ProdQuality { get; set; }
        /// <summary>
        /// Yes : Y, No : N
        /// </summary>
        public string MeetingDeadlines { get; set; }
        public string Dedication { get; set; }
        /// <summary>
        /// Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N
        /// </summary>
        public string StrongModelSkill { get; set; }
        public string Status { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
    }
}
