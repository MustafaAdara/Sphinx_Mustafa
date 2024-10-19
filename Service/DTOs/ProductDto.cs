using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDto
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [StringLength(150), MinLength(2)]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
