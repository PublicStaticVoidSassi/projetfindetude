using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Calls;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
namespace UniFlowCRM.Emails;

public class EmailJoined
{
    public EmailDto email { get; set; }
    public AccountDto? account { get; set; }
    public LeadDto? lead { get; set; }
    public ContactDto? contact { get; set; }
    public OpportunityDto? opportunity { get; set; }
    public IdentityUserDto? owner { get; set; }
    public IdentityUserDto? creator { get; set; }
    public IdentityUserDto? modifier { get; set; }

    public EmailDto ToDto()
    {
        var res = this.email;
        res.Account = account;
        res.Lead = lead;
        res.Contact = contact;
        res.Opportunity = opportunity;
        res.Creator = creator;
        res.Owner = owner;
        res.Modifier = modifier;
        return res;
    }
}

public class EmailsAppService :
  CrudAppService<Email,
  EmailDto,
  Guid,
  EmailRequestDto,
  CreateUpdateEmailDto
  >, IEmailAppService
{

    public IRepository<Lead, Guid> LeadsRepository { get; }
    public IRepository<IdentityUser, Guid> UsersRepository { get; }
    public IRepository<Account, Guid> AccountsRepository { get; }
    public IRepository<Contact, Guid> ContactsRepository { get; }
    public IRepository<Opportunity, Guid> OpportunitesRepository { get; }

    private readonly EmailManager _emailManager;

    public EmailsAppService(
        IRepository<Email, Guid> repository,
        IRepository<Lead, Guid> leadsRepository,
        IRepository<IdentityUser, Guid> usersRepository,
        IRepository<Account, Guid> accountsRepository,
        IRepository<Contact, Guid> contactsRepository,
        IRepository<Opportunity, Guid> opportunitysRepository
,
        EmailManager emailManager) : base(repository)
    {
        LeadsRepository = leadsRepository;
        UsersRepository = usersRepository;
        AccountsRepository = accountsRepository;
        ContactsRepository = contactsRepository;
        OpportunitesRepository = opportunitysRepository;
        _emailManager = emailManager;
    }


    public async Task SendEmailAsync(Guid id, CancellationToken ct = default)
    {
        Email email = await Repository.GetAsync(id, cancellationToken: ct);
        await _emailManager.SendEmailAsync(email);
    }




    public override async Task<PagedResultDto<EmailDto>> GetListAsync(EmailRequestDto input)
    {
        var emails = (await Repository.GetQueryableAsync())

                .Where((e) =>
                    input.filter == null || e.Subject.ToLower().Contains(input.filter)
                )
          .OrderBy(input.Sorting ?? "creationtime desc")
          .Skip(input.SkipCount)
          .Take(input.MaxResultCount);
        var leads = await LeadsRepository.GetQueryableAsync();
        var users = await UsersRepository.GetQueryableAsync();
        var accounts = await AccountsRepository.GetQueryableAsync();
        var contacts = await ContactsRepository.GetQueryableAsync();
        var opportunities = await OpportunitesRepository.GetQueryableAsync();

        var query = from email in emails
                    join account in accounts
                on email.AccountID equals account.Id
                into accountJoin
                    from account in accountJoin.DefaultIfEmpty()

                    join lead in leads
                        on email.LeadID equals lead.Id
                        into leadJoin
                    from lead in leadJoin.DefaultIfEmpty()

                    join contact in contacts
                        on email.ContactID equals contact.Id
                        into contactJoin
                    from contact in contactJoin.DefaultIfEmpty()

                    join opportunity in opportunities
                        on email.OpportunityID equals opportunity.Id
                        into opportunityJoin
                    from opportunity in opportunityJoin.DefaultIfEmpty()

                    join owner in users
                        on email.OwnerID equals owner.Id
                        into ownerJoin
                    from owner in ownerJoin.DefaultIfEmpty()

                    join creator in users
                        on email.CreatorId equals creator.Id
                        into creatorJoin
                    from creator in creatorJoin.DefaultIfEmpty()

                    join modifier in users
                        on email.LastModifierId equals modifier.Id
                        into modifierJoin
                    from modifier in modifierJoin.DefaultIfEmpty()



                    select new EmailJoined
                    {
                        email = ObjectMapper.Map<Email, EmailDto>(email),

                        account = account == null
                            ? null
                            : ObjectMapper.Map<Account, AccountDto>(account),

                        contact = contact == null
                            ? null
                            : ObjectMapper.Map<Contact, ContactDto>(contact),

                        lead = lead == null
                            ? null
                            : ObjectMapper.Map<Lead, LeadDto>(lead),

                        opportunity = opportunity == null
                            ? null
                            : ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity),

                        owner = owner == null
                            ? null
                            : ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner),

                        creator = creator == null
                            ? null
                            : ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator),

                        modifier = modifier == null
                            ? null
                            : ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier),
                    };
        var dto = (await AsyncExecuter.ToListAsync(query)).Select(e => e.ToDto()).ToList();
        var count = await Repository.GetCountAsync();
        return new PagedResultDto<EmailDto>(count, dto);
    }
    public override async Task<EmailDto> GetAsync(Guid id)
    {
        var emails = (await Repository.GetQueryableAsync()).Where(email => email.Id == id);
        var leads = await LeadsRepository.GetQueryableAsync();
        var users = await UsersRepository.GetQueryableAsync();
        var accounts = await AccountsRepository.GetQueryableAsync();
        var contacts = await ContactsRepository.GetQueryableAsync();
        var opportunities = await OpportunitesRepository.GetQueryableAsync();

        var query = from email in emails
                    join account in accounts
                on email.AccountID equals account.Id
                into accountJoin
                    from account in accountJoin.DefaultIfEmpty()

                    join lead in leads
                        on email.LeadID equals lead.Id
                        into leadJoin
                    from lead in leadJoin.DefaultIfEmpty()

                    join contact in contacts
                        on email.ContactID equals contact.Id
                        into contactJoin
                    from contact in contactJoin.DefaultIfEmpty()

                    join opportunity in opportunities
                        on email.OpportunityID equals opportunity.Id
                        into opportunityJoin
                    from opportunity in opportunityJoin.DefaultIfEmpty()

                    join owner in users
                        on email.OwnerID equals owner.Id
                        into ownerJoin
                    from owner in ownerJoin.DefaultIfEmpty()

                    join creator in users
                        on email.CreatorId equals creator.Id
                        into creatorJoin
                    from creator in creatorJoin.DefaultIfEmpty()

                    join modifier in users
                        on email.LastModifierId equals modifier.Id
                        into modifierJoin
                    from modifier in modifierJoin.DefaultIfEmpty()



                    select new EmailJoined
                    {
                        email = ObjectMapper.Map<Email, EmailDto>(email),

                        account = account == null
                            ? null
                            : ObjectMapper.Map<Account, AccountDto>(account),

                        contact = contact == null
                            ? null
                            : ObjectMapper.Map<Contact, ContactDto>(contact),

                        lead = lead == null
                            ? null
                            : ObjectMapper.Map<Lead, LeadDto>(lead),

                        opportunity = opportunity == null
                            ? null
                            : ObjectMapper.Map<Opportunity, OpportunityDto>(opportunity),

                        owner = owner == null
                            ? null
                            : ObjectMapper.Map<IdentityUser, IdentityUserDto>(owner),

                        creator = creator == null
                            ? null
                            : ObjectMapper.Map<IdentityUser, IdentityUserDto>(creator),

                        modifier = modifier == null
                            ? null
                            : ObjectMapper.Map<IdentityUser, IdentityUserDto>(modifier),
                    };
        return (await AsyncExecuter.FirstAsync(query)).ToDto();
    }
}
