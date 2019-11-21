using EasyFinanceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Repositories
{
    public interface IMovementRepository
    {
        Task AddAsync(Movement movement);
        Task<Movement> GetMovement(int id);
        Task<IEnumerable<Movement>> GetMovements(int id);
        void Delete(Movement movement);
    }
}
