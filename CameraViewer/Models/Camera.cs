namespace CameraViewer.Models;

public record Camera
{
    public required string Name { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public bool? IsOnline { get; set; }
}
