using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;

namespace EasyFinanceApi.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountSubscriptionRepository _accountSubscriptionRepository;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMembershipRepository membershipRepository
            , IAccountRepository accountRepository, IAccountSubscriptionRepository accountSubscriptionRepository)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
            this._membershipRepository = membershipRepository;
            this._accountRepository = accountRepository;
            this._accountSubscriptionRepository = accountSubscriptionRepository;
        }

        public async Task<SaveCustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                //if customer email dont exist return this
                if (await _customerRepository.ExistEmail(customer))
                    return new SaveCustomerResponse("Email already exist");

                var time = await _membershipRepository.AddAsync();
                await _unitOfWork.CompleteAsync();

                var membershipId = await _membershipRepository.GetIdMembershipAsync(time);
                var key = await _accountRepository.AddAsync();
                await _unitOfWork.CompleteAsync();

                var accountId = await _accountRepository.GetIdAccountAsync(key);
                await _accountSubscriptionRepository.AddAsync(membershipId, accountId, 1);
                await _unitOfWork.CompleteAsync();

                customer.AccountId = accountId;
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();

                return new SaveCustomerResponse(customer);
            } catch (Exception ex)
            {
                return new SaveCustomerResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
