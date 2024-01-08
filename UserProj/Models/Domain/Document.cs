using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserProj.Models.Domain
{
    public class Document
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        [JsonIgnore]
        public Project? Project { get; set; }

    }
}
