using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserProj.Models.Domain
{
    public class UserProject
    {

        public int UserId { get; set; }
        public  User User { get; set; }
        public int ProjectId { get; set; }
        public  Project Project { get; set; }

    }
}
