using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Language
{
    public int Id { get; set; }
    [StringLength(100)]public string Name { get; set; }
    public ICollection<Record> Records { get; set; }
}