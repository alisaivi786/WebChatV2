using MongoDB.Driver;
using WebChat.Application.Contracts.Presistence.IRepositories.Mongo;
using WebChat.Presistence.Repositories.BaseRepository;

namespace WebChat.Presistence.Repositories.MongoRepositories;

/// <summary>
/// Mongo User Repository
/// Developer: ALI RAZA MUSHTAQ
/// Date: 31-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="database"></param>
public class MongoUserRepository(IMongoDatabase database) 
    : BaseMongoRepository<UserDetailsEntity>(database, "User"),IMongoUserRepository
{

}
