using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClientProductDto
    {
        public string ProductId { get; set; }
        public string ClientId { get; set; }
        public string ProductName { get; set; }
        public string ClientName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        [StringLength(255)]
        public string License { get; set; }
    }
}
