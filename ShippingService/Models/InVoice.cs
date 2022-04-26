﻿using System.ComponentModel.DataAnnotations;

namespace ShippingService.Models
{
    public class InVoice
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalID { get; set; }
        public Shipping Shipping { get; set; }
    }
}
