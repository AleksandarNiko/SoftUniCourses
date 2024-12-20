﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.Data.Models
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CustomerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; } = null;

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
