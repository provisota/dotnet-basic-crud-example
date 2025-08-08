using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Api.Models
{
    /// <summary>
    /// Address entity.
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Street { get; set; } = default!;

        [Required, StringLength(100)]
        public string City { get; set; } = default!;
    }
}
