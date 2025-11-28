using Managment_SYS.Models;

namespace Managment_SYS.ViewModel
{
    public class TeamMemberCreateVM
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleType Role { get; set; }
    }
}
