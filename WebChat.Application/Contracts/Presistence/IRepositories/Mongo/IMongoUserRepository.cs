using WebChat.Application.Contracts.Presistence.IBaseRepository;

namespace WebChat.Application.Contracts.Presistence.IRepositories.Mongo;

public interface IMongoUserRepository : IBaseMongoRepository<UserEntity>
{
}
