using Microsoft.Extensions.Hosting;

namespace WebChat.Extension.Extensions;

public static class EnvironmentExtensions
{
    public static bool IsTest(this IHostEnvironment environment)
    {
        // Assuming "Test" is the name of your custom environment
        return environment.IsEnvironment("Test");
    }
}