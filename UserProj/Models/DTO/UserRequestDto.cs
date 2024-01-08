using System.ComponentModel.DataAnnotations;

namespace UserProj.Models.DTO
{
    public class UserRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int? DocumnetId { get; set; }

    }
}
