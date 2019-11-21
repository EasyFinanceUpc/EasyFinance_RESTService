using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;
using EasyFinanceApi.Resources.ToResource;

namespace EasyFinanceApi.Domain.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MovementService(IMovementRepository movementRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<SaveMovementResponse> AddAsync(Movement movement, int type)
        {
            try
            {
                movement.CreateAt = DateTime.Now;
                if (type == 1)
                    movement.Type = EType.Income;
                else
                    movement.Type = EType.Expense;
                await _movementRepository.AddAsync(movement);
                await _unitOfWork.CompleteAsync();
                return new SaveMovementResponse(movement);
            } catch(Exception ex)
            {
                return new SaveMovementResponse($"An error occurred when saving the movement: {ex.Message}");
            }
        }

        public async Task<SaveMovementResponse> Delete(int id)
        {
            try
            {
                var movement = await _movementRepository.GetMovement(id);
                _movementRepository.Delete(movement);
                await _unitOfWork.CompleteAsync();
                return new SaveMovementResponse(movement);
            } catch (Exception ex)
            {
                return new SaveMovementResponse($"An error occurred when delete the movement: {ex.Message}");
            }
        }

        public async Task<MovementResource> GetMovement(int id)
        {
            var movement = await _movementRepository.GetMovement(id);
            var result = _mapper.Map<Movement, MovementResource>(movement);
            if (movement.Type == EType.Income)
                result.TypeName = Enum.GetName(typeof(Type), 1);
            else
                result.TypeName = Enum.GetName(typeof(Type), 2);
            var category = await _categoryRepository.GetCategory(movement.CategoryId);
            result.CategoryName = category.Name;
            result.Color = category.Color;
            return result;
        }

        public async Task<IEnumerable<MovementResource>> GetMovements(int id)
        {
            var movements = await _movementRepository.GetMovements(id);
            var results = _mapper.Map<IEnumerable<Movement>, IEnumerable<MovementResource>>(movements);
            foreach(MovementResource movement in results)
            {
                if (movement.Type == 1)
                    movement.TypeName = "Income";
                else
                    movement.TypeName = "Expense";
                var category = await _categoryRepository.GetCategory(movement.CategoryId);
                movement.CategoryName = category.Name;
                movement.Color = category.Color;
            }
            return results;
        }
    }
}
