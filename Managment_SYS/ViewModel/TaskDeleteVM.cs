using Managment_SYS.Models;

namespace Managment_SYS.ViewModel
{
    public class TaskDeleteVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public StatusType Status { get; set; }
        public PriorityType Priority { get; set; }
        public int ProjectId { get; set; }
        public int TeamMemberId { get; set; }
    }
}
