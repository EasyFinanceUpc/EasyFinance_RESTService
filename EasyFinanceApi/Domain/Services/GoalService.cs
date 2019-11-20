using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;

namespace EasyFinanceApi.Domain.Services
{
    public class GoalService : IGoalService
    {
        public readonly IGoalRepository _goalRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GoalService(IGoalRepository goalRepository, IUnitOfWork unitOfWork)
        {
            _goalRepository = goalRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<SaveGoalResponse> AddGoal(Goal goal)
        {
            try
            {
                goal.CreateAt = DateTime.Now;
                await _goalRepository.AddAsync(goal);
                await _unitOfWork.CompleteAsync();
                return new SaveGoalResponse(goal);
            }
            catch (Exception ex)
            {
                return new SaveGoalResponse($"An error occurred when saving the article: {ex.Message}");
            }
        }
    }
}
