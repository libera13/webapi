using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Service;

public class Service
{

    private readonly IMongoCollection<BsonDocument> _users;
    public Service(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _users = database.GetCollection<BsonDocument>("user-identity_16c16a05-e9cb-4d32-3e64-08dc1cceebfa");
    }

    public async Task<List<Model>> GetAllAsync()
    {
        var docs = await _users.Find(new BsonDocument()).ToListAsync();

        var rsp = new List<Model>();
        foreach (var doc in docs)
        {
            rsp.Add(new Model
            {
                Name = doc.GetValue("fullName").AsString
            });
        }
        return rsp;
    }
}
