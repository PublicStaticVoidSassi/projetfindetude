using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using UniFlowCRM.ValueObjects;
using Volo.Abp.Domain.Entities;
namespace UniFlowCRM.Leads
{
    public class LeadsAppService: 
        CrudAppService<Lead,LeadDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateLeadDto>
        ,ILeadsAppService
    {
        public LeadsAppService(IRepository<Lead, Guid> repository) : base(repository)
        {
            
        }
        private Lead Initialize(Lead lead, CreateUpdateLeadDto input) {
            lead.SetFirstName(input.FirstName);
            lead.SetLastName(input.LastName);
            lead.SetDescription(input.Description);
            if (input.Status is not null)
                lead.SetStatus((LeadStatus)input.Status);
            if (input.Source is not null)
                lead.SetSource((LeadSource)input.Source);
            if (input.PhoneNumber is not null)
                lead.SetPhone(new PhoneNumber(number:input.PhoneNumber,countryCode:input.PhoneCode));
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
            return ObjectMapper.Map<Lead,LeadDto>(lead);
        }
        public override async Task<LeadDto> UpdateAsync(Guid id,CreateUpdateLeadDto input)
        {
            Lead? lead = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            lead = Initialize(lead, input);
            await Repository.UpdateAsync(lead);
            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }
    }
}
