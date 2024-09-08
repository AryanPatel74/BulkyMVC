﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyRazorProject.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Display Name")]
        [Length(20, 100)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage = "Range Should be between 0-100")]
        public string? DisplayOrder { get; set; }
    }
}
