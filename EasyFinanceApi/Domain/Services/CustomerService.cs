using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Domain.Repositories;
using EasyFinanceApi.Domain.Services.Communication;
using Microsoft.AspNetCore.Http;

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
                if (customer.Birthday.AddYears(18) > DateTime.Now)
                    return new SaveCustomerResponse("You must be over 18 to register");


                var time = await _membershipRepository.AddAsync();
                await _unitOfWork.CompleteAsync();

                var membershipId = await _membershipRepository.GetIdMembershipAsync(time);
                var key = await _accountRepository.AddAsync(false);
                await _unitOfWork.CompleteAsync();

                var accountId = await _accountRepository.GetIdAccountAsync(key);
                await _accountSubscriptionRepository.AddAsync(membershipId, accountId, 1);
                await _unitOfWork.CompleteAsync();

                customer.AccountId = accountId;
                customer.Active = true;
                customer.Role = ERole.Owner;
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();

                return new SaveCustomerResponse(customer);
            } catch (Exception ex)
            {
                return new SaveCustomerResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCustomerResponse> SaveAsyncLocal(Customer customer, string email)
        {
            try
            {
                if (await _customerRepository.ExistEmail(customer))
                    return new SaveCustomerResponse("Email already exist");
                if (customer.Birthday.AddYears(18) > DateTime.Now)
                    return new SaveCustomerResponse("You must be over 18 to register");

                var OwnerAccountId = await _customerRepository.GetOwnerAccountId(email);
                customer.AccountId = OwnerAccountId;
                customer.Active = true;
                customer.Role = ERole.Member;
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
