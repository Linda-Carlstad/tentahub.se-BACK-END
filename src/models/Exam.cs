namespace TentaHub.Models;
public class Exam
{
    public string? ID { get; set; } = null;
    public string? courseNameShort { get; set; } = null;
    public string? universityName { get; set; } = null;
    public string? file {get; set;} = null;
    public DateTime? date { get; set; } = DateTime.Now;
    public int downloades { get; set; } = 0;
}