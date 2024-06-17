using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcountry
    {
        public int Id { get; set; }
        public string Sortname { get; set; }
        public string Name { get; set; }
        public int Phonecode { get; set; }
    }
}
