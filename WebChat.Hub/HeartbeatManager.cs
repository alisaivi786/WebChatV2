
namespace WebChat.Hubs;

public class HeartbeatManager
{
    // Use a dictionary to store last heartbeat timestamps
    private static readonly Dictionary<string, DateTime> LastHeartbeats = new Dictionary<string, DateTime>();

    // Set the last heartbeat timestamp for a connection
    public static void SetLastHeartbeat(string connectionId, DateTime timestamp)
    {
        LastHeartbeats[connectionId] = timestamp;
    }

    // Get the last heartbeat timestamp for a connection
    public static DateTime GetLastHeartbeat(string connectionId)
    {
        return LastHeartbeats.TryGetValue(connectionId, out var timestamp)
            ? timestamp
            : DateTime.MinValue; // Default value if not found
    }

    public static IEnumerable<string> GetConnectionIds()
    {
        return LastHeartbeats.Keys;
    }
}
