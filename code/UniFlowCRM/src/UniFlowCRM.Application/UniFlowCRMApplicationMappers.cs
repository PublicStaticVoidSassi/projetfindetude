using System;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using UniFlowCRM.Books;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Opportunities;
using UniFlowCRM.Leads;
using UniFlowCRM.Notes;
using UniFlowCRM.PhoneNumbers;

namespace UniFlowCRM;

[Mapper]
public static partial class UniFlowCRMValueObjectMapper
{
    public static string Map(EmailAddress email)
        => email.ToString();

    public static string Map(PhoneNumber phone)
        => phone.ToString();
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
public partial class UniFlowCRMNoteToNoteDtoMapper : MapperBase<Note, NoteDto>
{
    public override partial NoteDto Map(Note source);

    public override partial void Map(Note source, NoteDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMNoteDtoToNoteMapper : MapperBase<CreateUpdateNoteDto, Note>
{
    public override Note Map(CreateUpdateNoteDto source)
    {
        var output = new Note(source.Id,source.Title,source.Content);
        if (source.AccountId is not null) output.LinkToAccount((Guid)source.AccountId);
        if (source.ContactId is not null) output.LinkToContact((Guid)source.ContactId);
        if (source.OpportunityId is not null) output.LinkToOpportunity((Guid)source.OpportunityId);
        if (source.LeadId is not null) output.LinkToLead((Guid)source.LeadId);
        return output;
    }

    public override partial void Map(CreateUpdateNoteDto source, Note destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
[UseStaticMapper(typeof(UniFlowCRMValueObjectMapper))]
public partial class UniFlowCRMLeadJoinedToLeadDtoMapper : MapperBase<LeadJoined, LeadDto>
{
    public override partial LeadDto Map(LeadJoined source);

    public override partial void Map(LeadJoined source, LeadDto destination);
}
