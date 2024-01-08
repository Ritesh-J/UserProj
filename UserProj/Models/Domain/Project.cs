using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserProj.Models.Domain
{
    public class Project
    {
        [Key, Required]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<UserProject>? UserProjects { get; set; }=new List<UserProject>();
        [JsonIgnore]
        public ICollection<Document>? Documents { get; set; } = new List<Document>();
    }
}
