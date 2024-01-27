using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
       
        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot exeed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        /// <summary>
        /// by adding the required annotation for enums, it wouldnot work as enums already have default values. which means if you add other values than the specified ones in the num attributes, it would pop  an exception.
        /// but by making the enum nullable, the "Required" annotaion would work perfectley if there is an empty input and the enum exception woudnot appear because its already nullabel
        /// </summary>
        [Required]
        public Dept? Department { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
