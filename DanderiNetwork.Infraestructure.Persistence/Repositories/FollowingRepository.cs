

using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Domain.Entities;
using DanderiNetwork.Infraestructure.Persistence.Contexts;

namespace DanderiNetwork.Infraestructure.Persistence.Repositories
{
    //Este repositorio no necesita la mayoria de operaciones que nos hereda el repositorio generico 
    public class FollowingRepository : GenericRepository<Following>, IFollowingRepository
    {
        private readonly ApplicationContext _dbContext;
        public FollowingRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
