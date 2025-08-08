using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Api.Models
{
    /// <summary>
    /// Order entity.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Item { get; set; } = default!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
