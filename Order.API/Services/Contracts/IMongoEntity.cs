namespace Order.API.Services.Contracts;

public interface IMongoEntity
{
    static abstract string CollectionName { get; }
}