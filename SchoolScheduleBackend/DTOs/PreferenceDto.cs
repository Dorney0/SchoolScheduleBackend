public class PreferenceDto
{
    public int Id { get; set; }
    public int UserId { get; set; }  
    public DateTime Time { get; set; }
    public string Notes { get; set; }
}

public class PreferenceCreateDto
{
    public int UserId { get; set; }  
    public DateTime Time { get; set; }
    public string Notes { get; set; }
}