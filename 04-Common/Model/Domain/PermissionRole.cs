using Model.Auth;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class PermissionRole
    {
        [Key]
        public int Id { get; set; }
        public Permission Permission { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
