using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Adventure.Repository.Models
{
    public class AdventureType
    {
        [Key]
        public int AdventureTypeId { get; set; }
        public string AdventureTypeName { get; set; }

        public List<AdventureDetail> AdventureDetail { get; set; }
    }
}
