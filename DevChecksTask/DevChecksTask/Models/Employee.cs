using System.ComponentModel.DataAnnotations;

namespace DevChecksTask.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "JobRole is required")]
        public string JobRole { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public bool IsFirstAppointment { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }
}
