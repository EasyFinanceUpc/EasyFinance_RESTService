using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Persistence.Repositories
{
    public class MovementRepository : BaseRepository, IMovementRepository
    {
        public MovementRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
        }

        public void Delete(Movement movement)
        {
            _context.Movements.Remove(movement);
        }

        public async Task<Movement> GetMovement(int id)
        {
            return await _context.Movements.FindAsync(id);
        }

        public async Task<IEnumerable<Movement>> GetMovements(int id)
        {
            return await _context.Movements.Where(x => x.CustomerId == id).ToListAsync();
        }
    }
}
