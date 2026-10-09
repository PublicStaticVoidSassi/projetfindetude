using Riok.Mapperly.Abstractions;
using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using UniFlowCRM.Accounts;
using UniFlowCRM.Books;
using UniFlowCRM.Calls;
using UniFlowCRM.Campaigns;
using UniFlowCRM.Contacts;
using UniFlowCRM.Dashboards;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Emails;
using UniFlowCRM.Leads;
using UniFlowCRM.Meetings;
using UniFlowCRM.Moneys;
using UniFlowCRM.Notes;
using UniFlowCRM.Opportunities;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.Tasks;
using Volo.Abp.Mapperly;

namespace UniFlowCRM;

// campaigns mapper
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class DtoToCampaignMapper : MapperBase<CreateUpdateCampaignDto, Campaign>
{
    public override Campaign Map(CreateUpdateCampaignDto source)
    {
        var target = new Campaign(
        id: source.Id,
        name: source.Name,
        description: source.Description,
        status: source.Status,
        expectedAccounts: source.ExpectedAccounts,
        expectedLeads: source.ExpectedLeads,
        expectedContacts: source.ExpectedContacts,
        expectedOpportunities: source.ExpectedOpportunities,
        startDate: source.StartDate,
        endDate: source.EndDate,
        assignedTo: source.AssignedTo,
        budget: new Money(value: source.BudgetValue, currency: source.BudgetCurrency),
        costSoFar: new Money(value: source.CostSoFarValue, currency: source.CostSoFarCurrency)
        );
        return target;
    }

    public override partial void Map(CreateUpdateCampaignDto source, Campaign destination);

}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CampaignToDtoMapper : MapperBase<Campaign, CampaignDto>
{
    [MapProperty(nameof(Campaign.Budget.Value), nameof(CampaignDto.BudgetValue))]
    [MapProperty(nameof(Campaign.Budget.Currency), nameof(CampaignDto.BudgetCurrency))]
    [MapProperty(nameof(Campaign.CostSoFar.Value), nameof(CampaignDto.CostSoFarValue))]
    [MapProperty(nameof(Campaign.CostSoFar.Currency), nameof(CampaignDto.CostSoFarCurrency))]
    public override partial CampaignDto Map(Campaign source);

    public override partial void Map(Campaign source, CampaignDto destination);
}


[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]

public partial class IncomeMapper : MapperBase<Income, IncomeDto>
{
    public override partial IncomeDto Map(Income source);
    public override partial void Map(Income source, IncomeDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]

public partial class DashboardMapper : MapperBase<Dashboard, DashboardDto>
{
    public override partial DashboardDto Map(Dashboard source);

    public override partial void Map(Dashboard source, DashboardDto destination);
}

[Mapper]
public static partial class UniFlowCRMValueObjectMapper
{
    public static string Map(EmailAddress email)
        => email.ToString();

    public static string Map(PhoneNumber phone)
        => phone.ToString();
    public static PhoneNumber Map(string phone)
        => new PhoneNumber(phone);


}
[Mapper]
public static partial class EmailAddressMapper
{
    public static EmailAddress Map(string email)
         => (string.IsNullOrEmpty(email)) ? null : new EmailAddress(email);

}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMContactToContactDtoMapper : MapperBase<Contact, ContactDto>
{
    [MapProperty(nameof(Account.Address.City), nameof(AccountDto.City))]
    [MapProperty(nameof(Account.Address.Street), nameof(AccountDto.Street))]
    [MapProperty(nameof(Account.Address.Country), nameof(AccountDto.Country))]
    [MapProperty(nameof(Account.Address.PostalCode), nameof(AccountDto.PostalCode))]
    public override partial ContactDto Map(Contact source);
    [MapProperty(nameof(Account.Address.City), nameof(AccountDto.City))]
    [MapProperty(nameof(Account.Address.Street), nameof(AccountDto.Street))]
    [MapProperty(nameof(Account.Address.Country), nameof(AccountDto.Country))]
    [MapProperty(nameof(Account.Address.PostalCode), nameof(AccountDto.PostalCode))]
    public override partial void Map(Contact source, ContactDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMAccountToAccountDtoMapper
    : MapperBase<Account, AccountDto>

{
    [MapProperty(nameof(Account.Address.City), nameof(AccountDto.City))]
    [MapProperty(nameof(Account.Address.Street), nameof(AccountDto.Street))]
    [MapProperty(nameof(Account.Address.Country), nameof(AccountDto.Country))]
    [MapProperty(nameof(Account.Address.PostalCode), nameof(AccountDto.PostalCode))]
    public override partial AccountDto Map(Account source);
    [MapProperty(nameof(Account.Address.City), nameof(AccountDto.City))]
    [MapProperty(nameof(Account.Address.Street), nameof(AccountDto.Street))]
    [MapProperty(nameof(Account.Address.Country), nameof(AccountDto.Country))]
    [MapProperty(nameof(Account.Address.PostalCode), nameof(AccountDto.PostalCode))]
    public override partial void Map(Account source, AccountDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMLeadToLeadDtoMapper : MapperBase<Lead, LeadDto>
{
    public override partial LeadDto Map(Lead source);

    public override partial void Map(Lead source, LeadDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class UniFlowCRMBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class UniFlowCRMCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}


[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMOpportunityToOpportunityDtoMapper : MapperBase<Opportunity, OpportunityDto>
{
    public override partial OpportunityDto Map(Opportunity source);

    public override partial void Map(Opportunity source, OpportunityDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class NoteToDto : MapperBase<Note, NoteDto>
{
    public override partial NoteDto Map(Note source);

    public override partial void Map(Note source, NoteDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class DtoToNote : MapperBase<CreateUpdateNoteDto, Note>
{
    public override partial Note Map(CreateUpdateNoteDto source);

    public override partial void Map(CreateUpdateNoteDto source, Note destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMLeadJoinedToLeadDtoMapper : MapperBase<LeadJoined, LeadDto>
{
    public override partial LeadDto Map(LeadJoined source);

    public override partial void Map(LeadJoined source, LeadDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class TaskToDto : MapperBase<Task, TaskDto>
{
    public override partial TaskDto Map(Task source);
    public override partial void Map(Task source, TaskDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class DtoToTask : MapperBase<CreateUpdateTaskDto, Task>
{
    public override partial Task Map(CreateUpdateTaskDto source);

    public override partial void Map(CreateUpdateTaskDto source, Task destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CallToDto : MapperBase<Call, CallDto>
{
    public override partial CallDto Map(Call source);
    public override partial void Map(Call source, CallDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class DtoToCall : MapperBase<CreateUpdateCallDto, Call>
{
    public override Call Map(CreateUpdateCallDto source)
    {
        var target = new Call(source.Id, source.Name);
        target.Description = source.Description;
        target.Status = source.Status;
        target.Direction = source.Direction;
        target.StartTime = source.StartTime;
        target.EndTime = source.EndTime;
        target.Duration = source.Duration;
        target.PhoneNumber = new PhoneNumber(source.PhoneNumber, source.PhoneCode);
        target.AccountID = source.AccountID;
        target.ContactID = source.ContactID;
        target.OpportunityID = source.OpportunityID;
        target.LeadID = source.LeadID;
        target.OwnerID = source.OwnerID;
        return target;
    }

    public override void Map(CreateUpdateCallDto source, Call destination)
    {
        destination.Name = source.Name;
        destination.Description = source.Description;
        destination.Status = source.Status;
        destination.Direction = source.Direction;
        destination.StartTime = source.StartTime;
        destination.EndTime = source.EndTime;
        destination.Duration = source.Duration;
        destination.PhoneNumber = new PhoneNumber(source.PhoneNumber, source.PhoneCode);
        destination.AccountID = source.AccountID;
        destination.ContactID = source.ContactID;
        destination.OpportunityID = source.OpportunityID;
        destination.LeadID = source.LeadID;
        destination.OwnerID = source.OwnerID;
    }
}
// Email
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(EmailAddressMapper))]
public partial class EmailToDto : MapperBase<Email, EmailDto>
{
    public override partial EmailDto Map(Email source);

    public override partial void Map(Email source, EmailDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(EmailAddressMapper))]
public partial class DtoToEmail : MapperBase<CreateUpdateEmailDto, Email>
{
    public override partial Email Map(CreateUpdateEmailDto source);

    public override partial void Map(CreateUpdateEmailDto source, Email destination);
}
// Meeting
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class MeetingToDto : MapperBase<Meeting, MeetingDto>
{
    public override partial MeetingDto Map(Meeting source);

    public override partial void Map(Meeting source, MeetingDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class DtoToMeeting : MapperBase<CreateUpdateMeetingDto, Meeting>
{
    public override partial Meeting Map(CreateUpdateMeetingDto source);


    public override partial void Map(CreateUpdateMeetingDto source, Meeting destination);
}
