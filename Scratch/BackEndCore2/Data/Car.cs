using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace demobackend.Data
{
    public class Car
    {
        
        [Key]
        public int Id {get; set;}
        [StringLength(50),Required]
        public string Name {get; set;}
        [StringLength(50),Required]
        public string Mark {get; set;}
        [StringLength(50),Required]
        public string Model {get; set;}
        [Required]
        public DateTime Registered { get; set; }

    }
}