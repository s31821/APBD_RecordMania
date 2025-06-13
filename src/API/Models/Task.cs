using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Task
{
    public int Id { get; set; }
    [StringLength(100)]public string Name { get; set; }
    [StringLength(2000)]public string Description { get; set; }
    
    public ICollection<Record> Records { get; set; }
}