using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Api.Models
{
    /// <summary>
    /// User entity.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = default!;

        [Required, EmailAddress, StringLength(320)]
        public string Email { get; set; } = default!;
    }
}
