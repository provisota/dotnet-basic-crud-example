using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Api.Dtos
{
    // DTO used to create or update a user
    public class UpsertUserDto
    {
        [Required, StringLength(200)]
        public string Name { get; set; } = default!;

        [Required, EmailAddress, StringLength(320)]
        public string Email { get; set; } = default!;
    }

    // DTO used to return user data
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
