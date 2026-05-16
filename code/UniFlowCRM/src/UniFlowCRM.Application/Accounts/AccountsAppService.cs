using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using UniFlowCRM.Addresses;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Moneys;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.URLs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace UniFlowCRM.Accounts
{
    public class AccountJoined
    {
        public AccountDto Account { get; set; }
        public IdentityUserDto? Owner { get; set; }
        public IdentityUserDto? Creator { get; set; }
        public IdentityUserDto? LastModifier { get; set; }
    }
    public class AccountsAppService : CrudAppService<Account, AccountDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAccountDto>, IAccountsAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        public AccountsAppService(IRepository<Account, Guid> repository,IRepository<IdentityUser,Guid> usersrepository) : base(repository)
        {
            _userRepository = usersrepository;
        }
        private async Task<IQueryable<AccountJoined>> GetQueryableAsync(PagedAndSortedResultRequestDto input)
        {
            var accounts = await Repository.GetQueryableAsync();

            

            var users = await _userRepository.GetQueryableAsync();

            var query =
                from account in accounts
                orderby input.Sorting
                join owner in users
                    on account.UserID equals owner.Id
                    into ownerJoin
                from owner in ownerJoin.DefaultIfEmpty()

                join creator in users
                    on account.CreatorId equals creator.Id
                    into creatorJoin
                from creator in creatorJoin.DefaultIfEmpty()

                join modifier in users
                    on account.LastModifierId equals modifier.Id
                    into modifierJoin
                from modifier in modifierJoin.DefaultIfEmpty()

                select new AccountJoined
                {
                    Account = ObjectMapper.Map<Account, AccountDto>(account),

                    Owner = owner != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner)
                        : null,

                    Creator = creator != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                        : null,

                    LastModifier = modifier != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier)
                        : null
                };
            return query;
        }
        private async Task<IQueryable<AccountJoined>> GetQueryableAsync(Guid id)
        {
            var accounts = await Repository.GetQueryableAsync();

            

            var users = await _userRepository.GetQueryableAsync();

            var query =
                from account in accounts
                where account.Id == id
                join owner in users
                    on account.UserID equals owner.Id
                    into ownerJoin
                from owner in ownerJoin.DefaultIfEmpty()

                join creator in users
                    on account.CreatorId equals creator.Id
                    into creatorJoin
                from creator in creatorJoin.DefaultIfEmpty()

                join modifier in users
                    on account.LastModifierId equals modifier.Id
                    into modifierJoin
                from modifier in modifierJoin.DefaultIfEmpty()

                select new AccountJoined
                {
                    Account = ObjectMapper.Map<Account, AccountDto>(account),

                    Owner = owner != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner)
                        : null,

                    Creator = creator != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                        : null,

                    LastModifier = modifier != null
                        ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier)
                        : null
                };
            return query;
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
                acc.SetRevenue(new Moneys.Money((decimal)input.RevenueAmount, (Currency)input.RevenueCurrency));
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
            var query = await GetQueryableAsync(id);
            var res = await AsyncExecuter.FirstAsync(query);
            var dto = res.Account;
            dto.Owner = res.Owner;
            dto.Creator = res.Creator;
            dto.Modifier = res.LastModifier;
            return dto;
        }

        public override async Task<PagedResultDto<AccountDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var q = await GetQueryableAsync(input);
            var res = await AsyncExecuter.ToListAsync(q);
            var dtos = res.Select(res =>
            {
                var dto = res.Account;
                dto.Owner = res.Owner;
                dto.Creator = res.Creator;
                dto.Modifier = res.LastModifier;
                return dto;
            }).ToList();
            return new PagedResultDto<AccountDto>(dtos.Count,dtos);
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
