using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
namespace WebChat.Common.JsonFileService;

public class JsonFileService(IHostEnvironment hostEnvironment)
{
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task<List<int>> GetItemsFromJsonFile(string fileName)
    {
        string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\DataSample",fileName);

        if (!File.Exists(filePath))
        {
            // Handle file not found error
            return null;
        }

        string jsonData = await File.ReadAllTextAsync(filePath);

        List<UserModel> items = JsonConvert.DeserializeObject<List<UserModel>>(jsonData);

        return items.Select(x=>x.UserId).ToList();
    }

    public class UserModel
    {
        public int UserId { get; set; }    
        public string? UserName { get; set; }    
    }
}
