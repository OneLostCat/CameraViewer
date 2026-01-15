using System.Collections.Generic;

namespace CameraViewer.Models;

public record StorageContent
{
    public List<Camera> Cameras { get; set; } = [];
}
