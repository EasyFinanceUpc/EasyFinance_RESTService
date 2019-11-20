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

        public async Task<SaveGoalResponse> Delete(int id)
        {
            try
            {
                var goal = await _goalRepository.GetGoal(id);
                _goalRepository.Delete(goal);
                await _unitOfWork.CompleteAsync();
                return new SaveGoalResponse(goal);
            }catch(Exception ex)
            {
                return new SaveGoalResponse($"An error occurred when delete the article: {ex.Message}");
            }
        }

        public async Task<IEnumerable<GoalResource>> GetGoals(int id)
        {
            var goals = await _goalRepository.GetGoals(id);
            var response = _mapper.Map<IEnumerable<Goal>, IEnumerable<GoalResource>>(goals);
            foreach(GoalResource goal in response)
            {
                var catergory = await _categoryRepository.GetCategory(goal.Id);
                goal.CategoryName = catergory.Name;
                goal.Color = catergory.Color;
            }
            return response;
        }

        public async Task<SaveGoalResponse> Update(int id)
        {
            try
            {
                var goal = await _goalRepository.GetGoal(id);
                goal.ReachAt = DateTime.Now;
                _goalRepository.Update(goal);
                await _unitOfWork.CompleteAsync();
                return new SaveGoalResponse(goal);
            } catch(Exception ex)
            {
                return new SaveGoalResponse($"An error occurred when delete the article: {ex.Message}");
            }
        }
    }
}
