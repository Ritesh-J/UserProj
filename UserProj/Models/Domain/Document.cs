using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public User? User { get; set; }
        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}
