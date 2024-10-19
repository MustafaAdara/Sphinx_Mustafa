using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public class Client
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(50),MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(9)]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Code Must Be 9 Numbers")]
        public double Code { get; set; }
        [Required]
        public ClientClass Class { get; set; }
        public ClientState State { get; set; }
        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

    }

    public enum ClientClass
    {
        A,
        B,
        C
    }

    public enum ClientState
    {
        Active,
        Inactive,
        Pending
    }
}
