using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Adventure.Repository.Models
{
    public class UserAdventure
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double PriceCalculated { get; set; }

        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key]
        public int AdventureDetailId { get; set; }
        public AdventureDetail AdventureDetail { get; set; }
    }
}
