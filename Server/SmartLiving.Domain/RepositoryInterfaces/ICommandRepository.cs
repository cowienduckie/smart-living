using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface ICommandRepository : IBaseRepository<Command>
    {
        bool Switch(int deviceId, string userId);
    }
}