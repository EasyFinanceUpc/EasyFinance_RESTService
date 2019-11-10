using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;

namespace EasyFinanceApi.Domain.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountSubscriptionRepository _accountSubscriptionRepository;

        public AdvisorService(IAdvisorRepository advisorRepository, IAccountRepository accountRepository
            , IMembershipRepository membershipRepository, IUnitOfWork unitOfWork, IAccountSubscriptionRepository accountSubscriptionRepository)
        {
            _advisorRepository = advisorRepository;
            _accountRepository = accountRepository;
            _membershipRepository = membershipRepository;
            _accountSubscriptionRepository = accountSubscriptionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<SaveAdvisorResponse> SaveAsync(Advisor advisor)
        {
            try
            {
                if (await _advisorRepository.ExistEmail(advisor))
                    return new SaveAdvisorResponse("Email already exist");

                var time = await _membershipRepository.AddAsync();
                await _unitOfWork.CompleteAsync();

                var membershipId = await _membershipRepository.GetIdMembershipAsync(time);
                var key = await _accountRepository.AddAsync(true);
                await _unitOfWork.CompleteAsync();

                var accountId = await _accountRepository.GetIdAccountAsync(key);
                await _accountSubscriptionRepository.AddAsync(membershipId, accountId, 4);
                await _unitOfWork.CompleteAsync();

                advisor.AccountId = accountId;
                advisor.Active = true;
                advisor.Role = ERole.Advisor;
                await _advisorRepository.AddAsync(advisor);
                await _unitOfWork.CompleteAsync();

                return new SaveAdvisorResponse(advisor);

            } catch (Exception ex)
            {
                return new SaveAdvisorResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
