﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Bulky.Models
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Categor Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }   
    }
}
