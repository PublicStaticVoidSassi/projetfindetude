using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Volo.Abp.Identity;
using Microsoft.AspNetCore.Authorization;

namespace UniFlowCRM.Notes;

[Authorize]
public class NotesAppService : CrudAppService<Note, NoteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateNoteDto>, INotesAppService
{
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    private readonly IRepository<Opportunity, Guid> _opportunityRepository;

    public NotesAppService(
        INotesRepository repository,
        IRepository<IdentityUser, Guid> userRepository,
        IRepository<Lead, Guid> leadRepository,
        IRepository<Account, Guid> accountRepository,
        IRepository<Contact, Guid> contactRepository,
        IRepository<Opportunity, Guid> opportunityRepository)
        : base(repository)
    {
        _userRepository = userRepository;
        _leadRepository = leadRepository;
        _accountRepository = accountRepository;
        _contactRepository = contactRepository;
        _opportunityRepository = opportunityRepository;
    }

    private async Task<IQueryable<NoteDto>> GetQueryableAsync(Guid id)
    {
        var notes = (await Repository.GetQueryableAsync());
        var users = await _userRepository.GetQueryableAsync();
        var leads = await _leadRepository.GetQueryableAsync();
        var accounts = await _accountRepository.GetQueryableAsync();
        var contacts = await _contactRepository.GetQueryableAsync();
        var opportunities = await _opportunityRepository.GetQueryableAsync();

        return from note in notes
               where note.Id == id
               join user in users
                   on note.CreatorId equals user.Id
                   into creatorJoin
               from creator in creatorJoin.DefaultIfEmpty()

               join lead in leads
                   on note.LeadId equals lead.Id
                   into leadJoin
               from lead in leadJoin.DefaultIfEmpty()

               join account in accounts
                   on note.AccountId equals account.Id
                   into accountJoin
               from account in accountJoin.DefaultIfEmpty()

               join contact in contacts
                   on note.ContactId equals contact.Id
                   into contactJoin
               from contact in contactJoin.DefaultIfEmpty()

               join opportunity in opportunities
                   on note.OpportunityId equals opportunity.Id
                   into opportunityJoin
               from opportunity in opportunityJoin.DefaultIfEmpty()

               select new NoteDto
               {
                   Id = note.Id,
                   Title = note.Title,
                   Content = note.Content,
                   Type = note.Type,
                   CreationTime = note.CreationTime,
                   LeadId = note.LeadId,
                   AccountId = note.AccountId,
                   ContactId = note.ContactId,
                   OpportunityId = note.OpportunityId,

                   Lead = lead != null
                       ? ObjectMapper.Map<Lead, LeadDto>(lead)
                       : null,

                   Account = account != null
                       ? ObjectMapper.Map<Account, AccountDto>(account)
                       : null,

                   Contact = contact != null
                       ? ObjectMapper.Map<Contact, ContactDto>(contact)
                       : null,

                   Opportunity = opportunity != null
                       ? ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity)
                       : null,

                   Creator = creator != null
                       ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                       : null
               };
    }
    private async Task<IQueryable<NoteDto>> GetQueryableAsync()
    {
        var notes = (await Repository.GetQueryableAsync()).OrderBy("creationtime desc");
        var users = await _userRepository.GetQueryableAsync();
        var leads = await _leadRepository.GetQueryableAsync();
        var accounts = await _accountRepository.GetQueryableAsync();
        var contacts = await _contactRepository.GetQueryableAsync();
        var opportunities = await _opportunityRepository.GetQueryableAsync();

        return from note in notes
               join user in users
                   on note.CreatorId equals user.Id
                   into creatorJoin
               from creator in creatorJoin.DefaultIfEmpty()

               join lead in leads
                   on note.LeadId equals lead.Id
                   into leadJoin
               from lead in leadJoin.DefaultIfEmpty()

               join account in accounts
                   on note.AccountId equals account.Id
                   into accountJoin
               from account in accountJoin.DefaultIfEmpty()

               join contact in contacts
                   on note.ContactId equals contact.Id
                   into contactJoin
               from contact in contactJoin.DefaultIfEmpty()

               join opportunity in opportunities
                   on note.OpportunityId equals opportunity.Id
                   into opportunityJoin
               from opportunity in opportunityJoin.DefaultIfEmpty()
                   //orderby "Note." + input.Sorting
               select new NoteDto
               {
                   Id = note.Id,
                   Title = note.Title,
                   Content = note.Content,
                   Type = note.Type,

                   LeadId = note.LeadId,
                   AccountId = note.AccountId,
                   ContactId = note.ContactId,
                   OpportunityId = note.OpportunityId,
                   CreationTime = note.CreationTime,
                   Lead = lead != null
                       ? ObjectMapper.Map<Lead, LeadDto>(lead)
                       : null,

                   Account = account != null
                       ? ObjectMapper.Map<Account, AccountDto>(account)
                       : null,

                   Contact = contact != null
                       ? ObjectMapper.Map<Contact, ContactDto>(contact)
                       : null,

                   Opportunity = opportunity != null
                       ? ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity)
                       : null,

                   Creator = creator != null
                       ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                       : null
               };
    }
    private async Task<IQueryable<NoteDto>> GetQueryableAsync(PagedAndSortedResultRequestDto input)
    {
        var notes = (await Repository.GetQueryableAsync()).OrderBy(input.Sorting ?? "creationtime desc").Skip(input.SkipCount).Take(input.MaxResultCount);
        var users = await _userRepository.GetQueryableAsync();
        var leads = await _leadRepository.GetQueryableAsync();
        var accounts = await _accountRepository.GetQueryableAsync();
        var contacts = await _contactRepository.GetQueryableAsync();
        var opportunities = await _opportunityRepository.GetQueryableAsync();

        return from note in notes
               join user in users
                   on note.CreatorId equals user.Id
                   into creatorJoin
               from creator in creatorJoin.DefaultIfEmpty()

               join lead in leads
                   on note.LeadId equals lead.Id
                   into leadJoin
               from lead in leadJoin.DefaultIfEmpty()

               join account in accounts
                   on note.AccountId equals account.Id
                   into accountJoin
               from account in accountJoin.DefaultIfEmpty()

               join contact in contacts
                   on note.ContactId equals contact.Id
                   into contactJoin
               from contact in contactJoin.DefaultIfEmpty()

               join opportunity in opportunities
                   on note.OpportunityId equals opportunity.Id
                   into opportunityJoin
               from opportunity in opportunityJoin.DefaultIfEmpty()
               orderby "Note." + input.Sorting
               select new NoteDto
               {
                   Id = note.Id,
                   Title = note.Title,
                   Content = note.Content,
                   Type = note.Type,
                   CreationTime = note.CreationTime,
                   LeadId = note.LeadId,
                   AccountId = note.AccountId,
                   ContactId = note.ContactId,
                   OpportunityId = note.OpportunityId,

                   Lead = lead != null
                       ? ObjectMapper.Map<Lead, LeadDto>(lead)
                       : null,

                   Account = account != null
                       ? ObjectMapper.Map<Account, AccountDto>(account)
                       : null,

                   Contact = contact != null
                       ? ObjectMapper.Map<Contact, ContactDto>(contact)
                       : null,

                   Opportunity = opportunity != null
                       ? ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity)
                       : null,

                   Creator = creator != null
                       ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator)
                       : null
               };
    }
    public override async Task<PagedResultDto<NoteDto>> GetListAsync(
        PagedAndSortedResultRequestDto input)
    {
        var query = await GetQueryableAsync(input);
        //query = query
        //.OrderBy(input.Sorting ?? "title")
        //.Skip(input.SkipCount)
        //.Take(input.MaxResultCount);

        var items = await AsyncExecuter.ToListAsync(query);
        var count = await Repository.GetCountAsync();

        return new PagedResultDto<NoteDto>(
            count,
            items
        );
    }
    public override async Task<NoteDto> GetAsync(Guid id)
    {
        var query = await GetQueryableAsync(id);

        return await AsyncExecuter.FirstAsync(query) ?? throw new EntityNotFoundException();
    }

    public async override Task<NoteDto> UpdateAsync(Guid id, CreateUpdateNoteDto input)
    {
        var note = await Repository.GetAsync(id);
        return note.CreatorId != CurrentUser.Id ? throw new UserFriendlyException("permission:denied") : await base.UpdateAsync(id, input);
    }

    public async Task<List<NoteDto>> GetForLead(Guid leadId)
    {
        var notes = (await this.GetQueryableAsync()).Where(note => note.LeadId == leadId).ToList();
        return notes;
    }
    // TODO
    public async Task<List<NoteDto>> GetForContact(Guid contactId)
    {
        var notes = (await this.GetQueryableAsync()).Where(note => note.ContactId == contactId).ToList();
        return notes;
    }

    public async Task<List<NoteDto>> GetForAccount(Guid accountId)
    {
        var notes = (await this.GetQueryableAsync()).Where(note => note.AccountId == accountId).ToList();
        return notes;
    }

    public async Task<List<NoteDto>> GetForOpportunity(Guid opportunityId)
    {
        var notes = (await this.GetQueryableAsync()).Where(note => note.OpportunityId == opportunityId).ToList();
        return notes;
    }
}
