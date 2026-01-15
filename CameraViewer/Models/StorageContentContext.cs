using System.Text.Json.Serialization;

namespace CameraViewer.Models;

[JsonSerializable(typeof(StorageContent))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public partial class StorageContentContext : JsonSerializerContext;
    