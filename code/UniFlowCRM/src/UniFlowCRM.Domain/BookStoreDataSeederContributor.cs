using System;
using System.Threading.Tasks;
using UniFlowCRM.Accounts;
using UniFlowCRM.Addresses;
using UniFlowCRM.Books;
using UniFlowCRM.Contacts;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Leads;
using UniFlowCRM.Moneys;
using UniFlowCRM.Opportunities;
using UniFlowCRM.PhoneNumbers;
using UniFlowCRM.URLs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace UniFlowCRM;

public class UniFlowCRMDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    private readonly IRepository<Opportunity, Guid> _opportunityRepository;
    public UniFlowCRMDataSeederContributor(
        IRepository<Book, Guid> bookRepository,
        IRepository<IdentityUser,Guid> u,
        IRepository<Opportunity, Guid> opportunityRepository,
        IRepository<Contact, Guid> contactRepository,
        IRepository<Lead, Guid> leadRepository,
        IRepository<Account, Guid> accountRepository,
        IGuidGenerator gg)
    {
        _bookRepository = bookRepository;
        _guidGenerator = gg;
        _userRepository = u;
        
        _accountRepository = accountRepository; 
        _leadRepository = leadRepository; 
        _contactRepository = contactRepository; 
        _opportunityRepository = opportunityRepository; 

    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _accountRepository.GetCountAsync() != 0)
        {
            return;
        }
        // getting the admin user
        IdentityUser defaultUser = await _userRepository.FindAsync(e=>e.UserName=="admin")??throw new Exception("default user not found");
        // seedings accounts 
        Account ITComp = new Account(_guidGenerator.Create(), "ITComp", defaultUser.Id);
        ITComp.SetAddress(new Address().AddCity("Algiers").AddCountry("Algeria").AddStreet("les sources").AddPostalCode(123));
        ITComp.SetDescription("We deliver more than just software");
        ITComp.SetEmployees(132);
        ITComp.SetIndustry(AccountIndustry.Technology);
        ITComp.SetEmail(new EmailAddress("contact@itcomp.dz"));
        ITComp.SetType(AccountType.Partner);
        ITComp.SetPhone(new PhoneNumbers.PhoneNumber("123456789","+213"));
        Account NASA = new Account(_guidGenerator.Create(), "NASA", defaultUser.Id);
        NASA.SetAddress(new Address().AddCity("Washington DC").AddCountry("USA").AddStreet("wall ST"));
        NASA.SetDescription("To infinity and beyond");
        NASA.SetEmployees(5000);
        NASA.SetIndustry(AccountIndustry.Engineering);
        NASA.SetEmail(new EmailAddress("marketting@nasa.gov.us"));
        NASA.SetType(AccountType.Analyst);
        NASA.SetPhone(new PhoneNumbers.PhoneNumber("456789", "+1"));
        Account AirAlgerie = new Account(_guidGenerator.Create(), "Air Algerie", defaultUser.Id);
        AirAlgerie.SetAddress(new Address().AddCity("Algiers").AddCountry("Algeria"));
        AirAlgerie.SetEmployees(2500);
        AirAlgerie.SetIndustry(AccountIndustry.Engineering);
        AirAlgerie.SetEmail(new EmailAddress("admin@airalgerie.dz"));
        AirAlgerie.SetType(AccountType.Competitor);
        AirAlgerie.SetPhone(new PhoneNumbers.PhoneNumber("4512289", "+213"));
        Account SCPFoundation = new Account(_guidGenerator.Create(), "The SCP Foundation", defaultUser.Id);
        SCPFoundation.SetAddress(new Address().AddCity("???").AddCountry("???").AddStreet("???").AddPostalCode(0));
        SCPFoundation.SetEmployees(99999999);
        SCPFoundation.SetIndustry(AccountIndustry.Other);
        SCPFoundation.SetEmail(new EmailAddress("researcher@thescpfoundation.earth"));
        SCPFoundation.SetType(AccountType.Other);
        SCPFoundation.SetRevenue(new Moneys.Money(99999999, Currency.USD));

        await _accountRepository.InsertManyAsync([ITComp,NASA,AirAlgerie,SCPFoundation]);
        // leads
        var lJohn = new Lead(Guid.NewGuid(), "John");

        lJohn.SetLastName("Smith");
        lJohn.SetDescription("Interested in enterprise CRM solution");
        lJohn.SetStatus(LeadStatus.New);
        lJohn.SetSource(LeadSource.Conference);
        lJohn.SetPhone(new PhoneNumber("555111111", "+213"));
        lJohn.SetEmail(new EmailAddress("john.smith@demo.com"));
        lJohn.AssignToUser(defaultUser.Id);

        var lSaraJohnson = new Lead(Guid.NewGuid(), "Sara");

        lSaraJohnson.SetLastName("Johnson");
        lSaraJohnson.SetDescription("Requested pricing information for small business plan");
        lSaraJohnson.SetStatus(LeadStatus.InProcess);
        lSaraJohnson.SetSource(LeadSource.Email);
        lSaraJohnson.SetPhone(new PhoneNumber("+213 555222222"));
        lSaraJohnson.SetEmail(new EmailAddress("sara.johnson@demo.com"));
        lSaraJohnson.AssignToUser(defaultUser.Id);
        lSaraJohnson.AssignToAccount(AirAlgerie.Id);

        var lEmilyBrown = new Lead(Guid.NewGuid(), "Emily")
        {
        };

        lEmilyBrown.SetLastName("Brown");
        lEmilyBrown.SetDescription("Met at conference, interested in demo");
        lEmilyBrown.SetStatus(LeadStatus.New);
        lEmilyBrown.SetSource(LeadSource.Conference);
        lEmilyBrown.SetPhone(new PhoneNumber("555444444", "+213"));
        lEmilyBrown.SetEmail(new EmailAddress("emily.brown@demo.com"));
        lEmilyBrown.AssignToUser(defaultUser.Id);
        lEmilyBrown.AssignToAccount(NASA.Id);

        await _leadRepository.InsertManyAsync([lJohn,lSaraJohnson,lEmilyBrown]);

        // contacts
        var cOmarAli = new Contact(Guid.NewGuid(), "Omar");
        cOmarAli.SetMiddleName("Ali");
        cOmarAli.SetLastName("Benkhelifa");
        cOmarAli.SetDescription("Key decision maker in enterprise deal");
        cOmarAli.SetStatus(ContactStatus.Active);
        cOmarAli.SetSource(ContactSource.PublicRelations);
        cOmarAli.SetPhone(new PhoneNumber("555111111", "+213"));
        cOmarAli.SetFax(new PhoneNumber("555111112", "+213"));
        cOmarAli.SetEmail(new EmailAddress("omar.benkhelifa@corp.com"));
        cOmarAli.SetWebsite(new URL("https://corp-example.com"));
        cOmarAli.SetJob("IT Director");
        cOmarAli.SetDepartment("Information Technology");
        cOmarAli.AssignUser(defaultUser.Id);
        cOmarAli.AssignAccount(AirAlgerie.Id);

        var cSara = new Contact(Guid.NewGuid(), "Sara");
        cSara.SetStatus(ContactStatus.Active);
        cSara.SetSource(ContactSource.Campaign);
        cSara.SetPhone(new PhoneNumber("+213 555222222"));
        cSara.SetEmail(new EmailAddress("sara.mansouri@marketing.com"));
        cSara.SetWebsite(new URL("https://marketing-example.com"));
        cSara.SetJob("Marketing Manager");
        cSara.SetDepartment("Marketing");
        cSara.AssignUser(defaultUser.Id);
        cSara.AssignAccount(ITComp.Id);
        cSara.AssignLead(lSaraJohnson.Id);

        //if (await _bookRepository.GetCountAsync() <= 0)
        //{
        //    await _bookRepository.InsertAsync(
        //        new Book
        //        {
        //            Name = "1984",
        //            Type = BookType.Dystopia,
        //            PublishDate = new DateTime(1949, 6, 8),
        //            Price = 19.84f
        //        },
        //        autoSave: true
        //    );

        //    await _bookRepository.InsertAsync(
        //        new Book
        //        {
        //            Name = "The Hitchhiker's Guide to the Galaxy",
        //            Type = BookType.ScienceFiction,
        //            PublishDate = new DateTime(1995, 9, 27),
        //            Price = 42.0f
        //        },
        //        autoSave: true
        //    );
        //}
    }
}