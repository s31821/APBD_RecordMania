using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Student
{
    public int Id { get; set; }
    [StringLength(100)]public string FirstName { get; set; }
    [StringLength(100)]public string LastName { get; set; }
    [StringLength(250)]public string Email { get; set; }
    
    public ICollection<Record> Records { get; set; }
}