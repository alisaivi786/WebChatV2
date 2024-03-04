using System.Security.Principal;
namespace WebChat.Infrastructure.Admin;

public static class AdminPolicy
{
    public static void IsAdmin()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        var status = principal.IsInRole(WindowsBuiltInRole.Administrator);
        if (status)
        {
            Console.WriteLine("Running with administrative privileges.");
        }
        else
        {
            Console.WriteLine("Not running with administrative privileges. Exiting...");
            Environment.Exit(1);
        }
        
    }
}
