using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model;

public class Employee
{
    public int Id { get; set; }
    [Required(ErrorMessage ="First Name is requrired")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is requrired")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Email is requrired")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Phone is requrired")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Position is requrired")]
    public string Position { get; set; }
}
