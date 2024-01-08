using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserProj.Models.Domain;

namespace UserProj.Models.DTO
{
    public class DocumentResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }

    }
}
