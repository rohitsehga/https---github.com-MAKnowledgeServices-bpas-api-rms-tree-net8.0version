using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class Productconfig
    {
        public decimal Id { get; set; }
        public string Productname { get; set; }
        public string Authtype { get; set; }
        public bool Mfa { get; set; }
        public string Mfatype { get; set; }
        public bool Welcomemail { get; set; }
        public decimal CntrlCc { get; set; }
        public string Logobase64 { get; set; }
        public int? NotifyDays { get; set; }
        public string FromMailId { get; set; }
        public string PasswordPolicy { get; set; }
        public string IntegrationData { get; set; }
        public string Creby { get; set; }
        public DateTime Credate { get; set; }
        public string Updby { get; set; }
        public DateTime? Upddate { get; set; }
    }
}
