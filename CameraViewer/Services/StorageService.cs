using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CameraViewer.Models;
using Microsoft.Extensions.Logging;

namespace CameraViewer.Services;

public class StorageService : IAsyncDisposable
{
    private const string StoragePath = "storage.json";

    private readonly ILogger<StorageService> _logger;
    
    public StorageContent Content { get;  set; } = new();

    public StorageService(ILogger<StorageService> logger)
    {
        _logger = logger;
        
        LoadAsync().Wait();
    }

    public async ValueTask DisposeAsync()
    {
        await SaveAsync();

        GC.SuppressFinalize(this);
    }

    public async Task LoadAsync()
    {
        try
        {
            await using var stream = File.OpenRead(StoragePath);
            var result = await JsonSerializer.DeserializeAsync<StorageContent>(stream,
                StorageContentContext.Default.StorageContent);

            if (result != null)
            {
                Content = result;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "无法读取存储文件");
        }
    }

    public async Task SaveAsync()
    {
        try
        {
            await using var stream = File.OpenWrite(StoragePath);
            await JsonSerializer.SerializeAsync<StorageContent>(stream, Content, StorageContentContext.Default.StorageContent);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "无法写入存储文件");
        }
    }
}
