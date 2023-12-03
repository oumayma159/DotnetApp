﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApp.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public Guid? MembershiptypeId { get; set; }
        public virtual Membershiptype? Membershiptype { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
