using Managment_SYS.Models;
using System.ComponentModel.DataAnnotations;
namespace Managment_SYS.ViewModel
{
    public class TaskCreateVM
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public StatusType Status { get; set; }
        public PriorityType Priority { get; set; }
        [Display(Name ="Project Name",Prompt ="Select The Project ")]
        public int ProjectId { get; set; }
        [Display(Name="Member Name",Prompt ="Select The Member ")]
        public int TeamMemberId { get; set; }
    }
}
