using System.ComponentModel.DataAnnotations;

namespace EmployeeMvc.Models
{

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string JobRole { get; set; }

        [Required]
        public string Gender { get; set; }

        public bool IsFirstAppointment { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }

}
