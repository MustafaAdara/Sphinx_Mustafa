using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClientDto
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(9)]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Code Must Be 9 Numbers")]
        public double Code { get; set; }
        [Required]
        public string Class { get; set; }
        public string State { get; set; }
    }
}
