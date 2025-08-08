using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Api.Dtos
{
    // DTO used to create or update an address
    public class UpsertAddressDto
    {
        [Required, StringLength(200)]
        public string Street { get; set; } = default!;

        [Required, StringLength(100)]
        public string City { get; set; } = default!;
    }

    // DTO used to return address data
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
