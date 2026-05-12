using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using UniFlowCRM.ValueObjects;
using Volo.Abp.Domain.Entities;
using UniFlowCRM.Accounts;
using Volo.Abp.Identity;

namespace UniFlowCRM.Leads
{
    public class LeadsAppService :
        CrudAppService<Lead, LeadDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateLeadDto>
        , ILeadsAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<Account, Guid> _accountsRepository;
        public LeadsAppService(
            IRepository<Lead, Guid> repository,
            IRepository<Account, Guid> accountsRepository,
            IRepository<IdentityUser, Guid> userRepository
            ) : base(repository)
        {
            _userRepository = userRepository;
            _accountsRepository = accountsRepository;
        }
        public override async Task<LeadDto> GetAsync(Guid id)
        {
            var dto = await base.GetAsync(id) ?? throw new EntityNotFoundException();
            dto = await dereferenceFKs(dto);
            return dto;
        }

        public override async Task<PagedResultDto<LeadDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetListAsync(input);

            var newDtos = (await Task.WhenAll(result.Items
                .Select(e=> dereferenceFKs(e))))
                .ToList();

            return new PagedResultDto<LeadDto>(
                result.TotalCount,
                newDtos
            );
        }

        private async Task<LeadDto> dereferenceFKs(LeadDto dto)
        {
            try
            {
                dto.UserName = (await _userRepository.GetAsync(dto.UserID)).UserName;
                if (dto.AccountID is not null)
                {
                    dto.AccountName = (await _accountsRepository.GetAsync((Guid)dto.AccountID)).Name;
                }
            }
            catch (Exception)
            {

            }
            return dto;
            
            }
        private Lead Initialize(Lead lead, CreateUpdateLeadDto input)
        {
            lead.SetFirstName(input.FirstName);
            lead.SetLastName(input.LastName);
            lead.SetDescription(input.Description);
            if (input.Status is not null)
                lead.SetStatus((LeadStatus)input.Status);
            if (input.Source is not null)
                lead.SetSource((LeadSource)input.Source);
            if (input.PhoneNumber is not null)
                lead.SetPhone(new PhoneNumber(number: input.PhoneNumber, countryCode: input.PhoneCode));
            if (input.Email is not null)
                lead.SetEmail(new EmailAddress(input.Email));
            if (input.AccountID is not null)
                lead.AssignToAccount((Guid)input.AccountID);
            if (input.UserID is not null)
                lead.AssignToUser((Guid)input.UserID);
            else
                lead.AssignToUser(CurrentUser.Id!.Value);
            return lead;
        }
        public override async Task<LeadDto> CreateAsync(CreateUpdateLeadDto input)
        {
            Lead lead = new Lead(input.Id, input.FirstName);
            lead = Initialize(lead, input);
            await Repository.InsertAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
        public override async Task<LeadDto> UpdateAsync(Guid id, CreateUpdateLeadDto input)
        {
            Lead? lead = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            lead = Initialize(lead, input);
            await Repository.UpdateAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
    }
}
