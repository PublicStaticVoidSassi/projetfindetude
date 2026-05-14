using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using UniFlowCRM.Money;
using UniFlowCRM.ValueObjects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace UniFlowCRM.Accounts
{
    public class AccountsAppService : CrudAppService<Account, AccountDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAccountDto>, IAccountsAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        public AccountsAppService(IRepository<Account, Guid> repository,IRepository<IdentityUser,Guid> usersrepository) : base(repository)
        {
            _userRepository = usersrepository;
        }
        private Account Initialize(Account acc, CreateUpdateAccountDto input)
        {
            acc.SetName(input.Name);
            acc.SetDescription(input.Description);
            if (input.Website is not null)
                acc.SetWebsite(new URL(input.Website));
            //TODO: check nulls
            if (input.PhoneNumber != null)
                acc.SetPhone(new PhoneNumber(countryCode: input.PhoneCode, number: input.PhoneNumber));
            if (input.FaxNumber != null)
                acc.SetFax(new PhoneNumber(countryCode: input.FaxCode, number: input.FaxNumber));
            if (input.Email != null)
                acc.SetEmail(new EmailAddress(input.Email));
            acc.SetType(input.Type);
            acc.SetIndustry(input.Industry);
            if (input.RevenueCurrency != null && input.RevenueAmount != null)
                acc.SetRevenue(new ValueObjects.Money((decimal)input.RevenueAmount, (Currency)input.RevenueCurrency));
            acc.SetEmployees(input.Employees);
            if (input.UserID is not null)
                acc.AssignTo((Guid)input.UserID);
            else
                acc.AssignTo(CurrentUser.Id!.Value);
            acc.SetAddress(
                new Address()
                .AddCity(input.City)
                .AddCountry(input.Country)
                .AddStreet(input.Street)
                .AddPostalCode(input.PostalCode)
            );
            return acc;
        }
        public override async Task<AccountDto> GetAsync(Guid id)
        {
            var dto = await base.GetAsync(id);
            var username = (await _userRepository.GetAsync(dto.UserID))!.UserName;
            var creatorname = (dto.CreatorId is not null)? (await _userRepository.FindAsync((Guid)dto.CreatorId!))?.UserName : "system";
            dto.Username = username;
            dto.creatorName = creatorname;
            return dto;
        }
        public override async Task<AccountDto> CreateAsync(CreateUpdateAccountDto input)
        {
            Account acc = new Account(id: input.Id , name: input.Name, userID: CurrentUser.Id!.Value);
            acc = Initialize(acc,input);
            await Repository.InsertAsync(acc);
            return ObjectMapper.Map<Account, AccountDto>(acc);
        }
        public override async Task<AccountDto> UpdateAsync(Guid id,CreateUpdateAccountDto input)
        {
            Account? acc = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            acc = Initialize(acc, input);
            await Repository.UpdateAsync(acc);
            return ObjectMapper.Map<Account, AccountDto>(acc);
        }
    }
}
