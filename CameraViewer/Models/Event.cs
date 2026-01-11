using System;

namespace CameraViewer.Models;

public record Event
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? Time { get; set; }
    public string? ImageUrl { get; set; }
};
