using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Services.Communication;
using EasyFinanceApi.Resources.ToResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Domain.Services
{
    public interface IMovementService
    {
        Task<SaveMovementResponse> AddAsync(Movement movement, int type);
        Task<MovementResource> GetMovement(int id);
        Task<IEnumerable<MovementResource>> GetMovements(int id);
        Task<SaveMovementResponse> Delete(int id);
    }
}
