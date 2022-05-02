using WineOClockApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WineOClockApi.Services;

public class WinesService
{
    private readonly IMongoCollection<Wine> _winesCollection;

    public WinesService(
        IOptions<WinesDatabaseSettings> WineDatabaseSettings)
    {
        var settings = MongoClientSettings.FromConnectionString(WineDatabaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        var mongoClient = new MongoClient(settings);

        var mongoDatabase = mongoClient.GetDatabase(
            WineDatabaseSettings.Value.DatabaseName);

        _winesCollection = mongoDatabase.GetCollection<Wine>(
            WineDatabaseSettings.Value.WinesCollectionName);
    }

    public async Task<List<Wine>> GetAsync() =>
        await _winesCollection.Find(_ => true).ToListAsync();

    public async Task<Wine?> GetAsync(string id) =>
        await _winesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Wine newWine) =>
        await _winesCollection.InsertOneAsync(newWine);

    public async Task UpdateAsync(string id, Wine updatedWine) =>
        await _winesCollection.ReplaceOneAsync(x => x.Id == id, updatedWine);

    public async Task RemoveAsync(string id) =>
        await _winesCollection.DeleteOneAsync(x => x.Id == id);
}