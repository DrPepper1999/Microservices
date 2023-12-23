namespace Notification.API.Services.Contracts;

public interface IMongoEntity
{
    static abstract string CollectionName { get; }
}