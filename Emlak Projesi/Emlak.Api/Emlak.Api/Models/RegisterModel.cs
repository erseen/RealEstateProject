using System.ComponentModel.DataAnnotations;

namespace Emlak.Api.Models
{
    public class RegisterModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? RePassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}
