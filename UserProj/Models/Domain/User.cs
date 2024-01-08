using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserProj.Models.Domain
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [ForeignKey("DocumentId")]
        public int? DocumentId { get; set; }
        public Document? Document { get; set; }
        [JsonIgnore]
        public ICollection<UserProject>? UserProjects { get; set; } = new List<UserProject>();

        



    }
}
