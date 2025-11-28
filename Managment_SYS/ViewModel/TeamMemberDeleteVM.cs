using Managment_SYS.Models;

namespace Managment_SYS.ViewModel
{
    public class TeamMemberDeleteVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleType Role { get; set; }
    }
}
