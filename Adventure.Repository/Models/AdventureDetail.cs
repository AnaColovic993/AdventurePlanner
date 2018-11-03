using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Adventure.Repository.Models
{
    public class AdventureDetail
    {
        [Key]
        public int AdventureDetailId { get; set; }
        public string AdventureName { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }

        public int AdventureTypeId { get; set; }
        public AdventureType AdventureType { get; set; }

        public List<UserAdventure> UserAdventure { get; set; }
    }

}
