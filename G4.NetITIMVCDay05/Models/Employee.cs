using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G4.NetITIMVCDay05.Models
{
    public class Employee
    {
        /*---------------------------------------------------------*/
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(12, MinimumLength = 3, ErrorMessage ="Name must be between 3 and 12 Charcter.")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Age is Required.")]
        [Range(25, 50, ErrorMessage ="Age must be between 25 and 50.")]
        [DisplayName("Employee Age")]
        public int Age { get; set; }


        [Range(2500, 5000, ErrorMessage = "Salary must be between 2500 and 5000.")]
        [DisplayName("Employee Salary")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Salary { get; set; }


        [Required(ErrorMessage = "Address is Required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 50 Charcter.")]
        [DisplayName("Employee Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("Employee Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is Required.")]
        [DisplayName("Password")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password")]
        [DisplayName("Confirm Password")]
        [NotMapped]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        /*---------------------------------------------------------*/
        //[ForeignKey("Department")]
        public int DepartmentId { get; set; }
        //[ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        /*---------------------------------------------------------*/
    }
}
