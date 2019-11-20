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
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GoalService(IGoalRepository goalRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
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

        public async Task<IEnumerable<GoalResource>> GetGoals(int id)
        {
            var goals = await _goalRepository.GetGoals(id);
            var response = _mapper.Map<IEnumerable<Goal>, IEnumerable<GoalResource>>(goals);
            foreach(GoalResource goal in response)
            {
                var catergory = await _categoryRepository.GetCategory(1);
                goal.CategoryName = catergory.Name;
                
            }
            return null;
        }
    }
}
