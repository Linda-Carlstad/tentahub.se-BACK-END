namespace TentaHub.Models;
public class Exam
{
    public string? ID { get; set; } = null;
    public string? courseNameShort { get; set; } = null;
    public string? universityName { get; set; } = null;
    public DateOnly? date { get; set; } = DateOnly.FromDateTime(DateTime.UnixEpoch);
    public int downloades { get; set; } = 0;
}