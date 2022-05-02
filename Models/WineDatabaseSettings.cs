namespace WineOClockApi.Models;

public class WinesDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string WinesCollectionName { get; set; } = null!;
}