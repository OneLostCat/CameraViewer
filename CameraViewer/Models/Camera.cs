namespace CameraViewer.Models;

public record Camera
{
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string RecordingPath { get; set; }
}
