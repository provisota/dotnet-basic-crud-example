using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Api.Dtos
{
    // DTO used to create or update an order
    public class UpsertOrderDto
    {
        [Required, StringLength(200)]
        public string Item { get; set; } = default!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

    // DTO used to return order data
    public class OrderDto
    {
        public int Id { get; set; }
        public string Item { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
