using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class GroupRoleMapping
    {
        public string Group { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
