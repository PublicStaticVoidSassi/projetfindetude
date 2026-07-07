using System;
using System.Collections.Generic;
using System.Data;
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
    // private readonly IRepository<Book, Guid> _bookRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<IdentityUser, Guid> _userRepository;
    private readonly IRepository<IdentityRole, Guid> _roleRepository;
    private readonly IRepository<Account, Guid> _accountRepository;
    private readonly IRepository<Lead, Guid> _leadRepository;
    private readonly IRepository<Contact, Guid> _contactRepository;
    private readonly IRepository<Opportunity, Guid> _opportunityRepository;
    public UniFlowCRMDataSeederContributor(
        IRepository<IdentityUser, Guid> u,
        IRepository<Opportunity, Guid> opportunityRepository,
        IRepository<Contact, Guid> contactRepository,
        IRepository<Lead, Guid> leadRepository,
        IRepository<Account, Guid> accountRepository,
        IGuidGenerator gg,
        IRepository<IdentityRole, Guid> roleRepository)
    {
        // _bookRepository = bookRepository;
        _guidGenerator = gg;
        _userRepository = u;

        _accountRepository = accountRepository;
        _leadRepository = leadRepository;
        _contactRepository = contactRepository;
        _opportunityRepository = opportunityRepository;
        _roleRepository = roleRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedRolesAsync(context);
        if (await _accountRepository.GetCountAsync() != 0)
        {
            return;
        }
        // getting the admin user
        IdentityUser defaultUser = await _userRepository.FindAsync(e => e.UserName == "admin") ?? throw new Exception("default user not found");
        // seedings accounts 
        var accounts = new List<Account>();

        Account Create(
            string name,
            string? desc,
            AccountType type,
            AccountIndustry industry,
            string phone,
            string prefix,
            string email,
            Address address,
            int employees,
            Money? revenue = null
        )
        {
            return new Account(
                _guidGenerator.Create(),
                name,
                defaultUser.Id,
                desc,
                type,
                industry,
                new PhoneNumber(phone, prefix),
                null,
                new EmailAddress(email),
                null,
                address,
                revenue,
                employees
            );
        }

        // Core companies
        accounts.Add(Create(
            "ITComp",
            "We deliver more than just software",
            AccountType.Partner,
            AccountIndustry.Technology,
            "123456789",
            "+213",
            "contact@itcomp.dz",
            new Address("les sources", "Algiers", "Algeria", 123),
            132
        ));

        accounts.Add(Create(
            "NASA",
            "To infinity and beyond",
            AccountType.Analyst,
            AccountIndustry.Engineering,
            "456789",
            "+1",
            "marketting@nasa.gov.us",
            new Address().AddCity("Washington DC").AddCountry("USA").AddStreet("Wall ST"),
            5000
        ));

        accounts.Add(Create(
            "Air Algerie",
            null,
            AccountType.Competitor,
            AccountIndustry.Engineering,
            "4512289",
            "+213",
            "admin@airalgerie.dz",
            new Address().AddCity("Algiers").AddCountry("Algeria"),
            2500
        ));

        accounts.Add(Create(
            "SCP Foundation",
            null,
            AccountType.Other,
            AccountIndustry.Other,
            "456789",
            "+1",
            "researcher@thescpfoundation.earth",
            new Address().AddCity("???").AddCountry("???").AddStreet("???").AddPostalCode(0),
            99999999,
            new Money(99999999, Currency.USD)
        ));

        // Bulk generated companies
        var seedData = new (string name, string? desc, AccountType type, AccountIndustry industry, string phone, string prefix, string email, string city, string country, int employees)[]
        {
    ("Google","Search engine",AccountType.Partner,AccountIndustry.Technology,"111111","+1","contact@google.com","Mountain View","USA",180000),
    ("Microsoft","Windows & Cloud",AccountType.Partner,AccountIndustry.Technology,"222222","+1","contact@microsoft.com","Redmond","USA",220000),
    ("Apple","Devices",AccountType.Partner,AccountIndustry.Technology,"333333","+1","contact@apple.com","Cupertino","USA",160000),
    ("Tesla","EV cars",AccountType.Partner,AccountIndustry.Manufacturing,"444444","+1","contact@tesla.com","Austin","USA",140000),
    ("SpaceX","Space travel",AccountType.Partner,AccountIndustry.Engineering,"555555","+1","contact@spacex.com","Hawthorne","USA",12000),
    ("Amazon","E-commerce",AccountType.Partner,AccountIndustry.Retail,"666666","+1","contact@amazon.com","Seattle","USA",1500000),
    ("Meta","Social media",AccountType.Partner,AccountIndustry.Technology,"777777","+1","contact@meta.com","Menlo Park","USA",70000),
    ("Netflix","Streaming",AccountType.Partner,AccountIndustry.Media,"888888","+1","contact@netflix.com","Los Gatos","USA",12000),
    ("Intel","Chips",AccountType.Partner,AccountIndustry.Manufacturing,"999999","+1","contact@intel.com","Santa Clara","USA",130000),
    ("IBM","Enterprise IT",AccountType.Partner,AccountIndustry.Technology,"101010","+1","contact@ibm.com","Armonk","USA",280000),
    ("Oracle","Databases",AccountType.Partner,AccountIndustry.Technology,"121212","+1","contact@oracle.com","Austin","USA",140000),
    ("Samsung","Electronics",AccountType.Partner,AccountIndustry.Manufacturing,"131313","+82","contact@samsung.com","Seoul","Korea",270000),
    ("Sony","Entertainment",AccountType.Partner,AccountIndustry.Media,"141414","+81","contact@sony.com","Tokyo","Japan",110000),
    ("BMW","Cars",AccountType.Competitor,AccountIndustry.Manufacturing,"151515","+49","contact@bmw.com","Munich","Germany",150000),
    ("Mercedes","Luxury cars",AccountType.Competitor,AccountIndustry.Manufacturing,"161616","+49","contact@mercedes.com","Stuttgart","Germany",170000),
    ("Airbus","Aircraft",AccountType.Partner,AccountIndustry.Engineering,"171717","+33","contact@airbus.com","Toulouse","France",130000),
    ("Boeing","Aircraft",AccountType.Partner,AccountIndustry.Engineering,"181818","+1","contact@boeing.com","Chicago","USA",170000),
    ("GitHub","Code hosting",AccountType.Partner,AccountIndustry.Technology,"191919","+1","contact@github.com","San Francisco","USA",4000),
    ("OpenAI","AI research",AccountType.Partner,AccountIndustry.Technology,"202020","+1","contact@openai.com","San Francisco","USA",2000),
    ("ESA","Space agency",AccountType.Other,AccountIndustry.Engineering,"212121","+33","contact@esa.int","Paris","France",22000),
    ("WHO","Health org",AccountType.Other,AccountIndustry.Other,"222222","+41","contact@who.int","Geneva","Switzerland",8000),
        };

        foreach (var s in seedData)
        {
            accounts.Add(Create(
                s.name,
                s.desc,
                s.type,
                s.industry,
                s.phone,
                s.prefix,
                s.email,
                new Address().AddCity(s.city).AddCountry(s.country),
                s.employees
            ));
        }

        await _accountRepository.InsertManyAsync(accounts);
        // leads
        var rnd = new Random();

        var leads = new List<Lead>
{
    new Lead(Guid.NewGuid(), "John", "Smith", "Interested in enterprise CRM solution",
        LeadStatus.New, LeadSource.Conference,
        new PhoneNumber("555111111", "+213"),
        new EmailAddress("john.smith@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Sara", "Johnson", "Requested pricing information",
        LeadStatus.InProcess, LeadSource.Email,
        new PhoneNumber("555222222", "+213"),
        new EmailAddress("sara.johnson@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Emily", "Brown", "Met at conference",
        LeadStatus.New, LeadSource.Conference,
        new PhoneNumber("555333333", "+213"),
        new EmailAddress("emily.brown@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Michael", "Taylor", "Webinar follow-up",
        LeadStatus.New, LeadSource.Campaign,
        new PhoneNumber("555100001", "+213"),
        new EmailAddress("michael.taylor@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Olivia", "Martin", "Requested demo",
        LeadStatus.InProcess, LeadSource.Email,
        new PhoneNumber("555100002", "+213"),
        new EmailAddress("olivia.martin@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Daniel", "Lee", "CRM integration interest",
        LeadStatus.New, LeadSource.Conference,
        new PhoneNumber("555100003", "+213"),
        new EmailAddress("daniel.lee@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Sophia", "Walker", "Pricing request",
        LeadStatus.InProcess, LeadSource.Email,
        new PhoneNumber("555100004", "+213"),
        new EmailAddress("sophia.walker@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "James", "Harris", "Cold outreach reply",
        LeadStatus.New, LeadSource.ColdCall,
        new PhoneNumber("555100005", "+213"),
        new EmailAddress("james.harris@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Isabella", "Clark", "Interested after video",
        LeadStatus.New, LeadSource.ExistingCustomer,
        new PhoneNumber("555100006", "+213"),
        new EmailAddress("isabella.clark@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Ethan", "Lewis", "Enterprise plan inquiry",
        LeadStatus.InProcess, LeadSource.Email,
        new PhoneNumber("555100007", "+213"),
        new EmailAddress("ethan.lewis@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Mia", "Young", "Conference follow-up",
        LeadStatus.New, LeadSource.Conference,
        new PhoneNumber("555100008", "+213"),
        new EmailAddress("mia.young@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Alexander", "King", "Support request",
        LeadStatus.InProcess, LeadSource.Email,
        new PhoneNumber("555100009", "+213"),
        new EmailAddress("alex.king@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Charlotte", "Scott", "SaaS pricing interest",
        LeadStatus.New, LeadSource.PublicRelations,
        new PhoneNumber("555100010", "+213"),
        new EmailAddress("charlotte.scott@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Liam", "Anderson", "Demo request",
        LeadStatus.New, LeadSource.Email,
        new PhoneNumber("555100011", "+213"),
        new EmailAddress("liam.anderson@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Ava", "Thomas", "Pricing breakdown",
        LeadStatus.InProcess, LeadSource.Conference,
        new PhoneNumber("555100012", "+213"),
        new EmailAddress("ava.thomas@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Noah", "Moore", "Integration interest",
        LeadStatus.New, LeadSource.WordOfMouth,
        new PhoneNumber("555100013", "+213"),
        new EmailAddress("noah.moore@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Emma", "Jackson", "Call request",
        LeadStatus.InProcess, LeadSource.Email,
        new PhoneNumber("555100014", "+213"),
        new EmailAddress("emma.jackson@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),

    new Lead(Guid.NewGuid(), "Lucas", "White", "Downloaded brochure",
        LeadStatus.New, LeadSource.PublicRelations,
        new PhoneNumber("555100015", "+213"),
        new EmailAddress("lucas.white@demo.com"),
        defaultUser.Id,
        accounts[rnd.Next(accounts.Count)].Id),
};
        Console.WriteLine("seeding leads");
        await _leadRepository.InsertManyAsync(leads);

        // contacts

        var contacts = new List<Contact>
{
    new Contact(Guid.NewGuid(), "Omar", "Ali", "Benkhelifa",
        "Key decision maker in enterprise deal",
        ContactStatus.Active, ContactSource.PublicRelations,
        new PhoneNumber("555111111", "+213"),
        new PhoneNumber("555111112", "+213"),
        new EmailAddress("omar.benkhelifa@corp.com"),
        new URL("https://corp-example.com"),
        null,
        "IT Director",
        "Information Technology",
        defaultUser.Id,
        null,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Sara", null, "Mansouri",
        "Marketing lead contact",
        ContactStatus.Active, ContactSource.Campaign,
        new PhoneNumber("+213 555222222"),
        null,
        new EmailAddress("sara.mansouri@marketing.com"),
        new URL("https://marketing-example.com"),
        null,
        "Marketing Manager",
        "Marketing",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Yacine", null, "Khelifi",
        "Follow-up from conference",
        ContactStatus.Active, ContactSource.Conference,
        new PhoneNumber("555333333", "+213"),
        null,
        new EmailAddress("yacine.khelifi@demo.com"),
        null,
        null,
        "Business Analyst",
        "Sales",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Amina", null, "Zohra",
        "Interested in CRM demo",
        ContactStatus.Active, ContactSource.Campaign,
        new PhoneNumber("555444444", "+213"),
        null,
        new EmailAddress("amina.zohra@demo.com"),
        null,
        null,
        "Product Manager",
        "Product",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Karim", null, "Boudiaf",
        "Enterprise inquiry",
        ContactStatus.Active, ContactSource.Email,
        new PhoneNumber("555555555", "+213"),
        null,
        new EmailAddress("karim.boudiaf@demo.com"),
        null,
        null,
        "CTO",
        "Engineering",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Lina", null, "Ferhat",
        "Pricing request",
        ContactStatus.Active, ContactSource.Email,
        new PhoneNumber("555666666", "+213"),
        null,
        new EmailAddress("lina.ferhat@demo.com"),
        null,
        null,
        "Sales Rep",
        "Sales",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Rachid", null, "Benali",
        "Technical discussion lead",
        ContactStatus.Active, ContactSource.Conference,
        new PhoneNumber("555777777", "+213"),
        null,
        new EmailAddress("rachid.benali@demo.com"),
        null,
        null,
        "Engineer",
        "IT",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Nour", null, "Kaci",
        "Webinar follow-up",
        ContactStatus.Active, ContactSource.Conference,
        new PhoneNumber("555888888", "+213"),
        null,
        new EmailAddress("nour.kaci@demo.com"),
        null,
        null,
        "Consultant",
        "Business",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Imane", null, "Saidi",
        "Follow-up required",
        ContactStatus.Active, ContactSource.Email,
        new PhoneNumber("555999999", "+213"),
        null,
        new EmailAddress("imane.saidi@demo.com"),
        null,
        null,
        "HR Manager",
        "HR",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Walid", null, "Cherif",
        "Demo request",
        ContactStatus.Active, ContactSource.Email,
        new PhoneNumber("555101010", "+213"),
        null,
        new EmailAddress("walid.cherif@demo.com"),
        null,
        null,
        "Developer",
        "Engineering",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Hichem", null, "Belaid",
        null,
        ContactStatus.Active, ContactSource.TradeShow,
        new PhoneNumber("555111001", "+213"),
        null,
        new EmailAddress("hichem.belaid@demo.com"),
        null,
        null,
        "Analyst",
        "Finance",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Sami", null, "Meziane",
        null,
        ContactStatus.Active, ContactSource.Email,
        new PhoneNumber("555111002", "+213"),
        null,
        new EmailAddress("sami.meziane@demo.com"),
        null,
        null,
        "Director",
        "Operations",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Nabil", null, "Farhi",
        null,
        ContactStatus.Active, ContactSource.Conference,
        new PhoneNumber("555111003", "+213"),
        null,
        new EmailAddress("nabil.farhi@demo.com"),
        null,
        null,
        "Engineer",
        "IT",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Yasmine", null, "Djebbar",
        null,
        ContactStatus.Active, ContactSource.Employee,
        new PhoneNumber("555111004", "+213"),
        null,
        new EmailAddress("yasmine.djebbar@demo.com"),
        null,
        null,
        "Consultant",
        "Sales",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),

    new Contact(Guid.NewGuid(), "Adel", null, "Brahimi",
        null,
        ContactStatus.Active, ContactSource.Email,
        new PhoneNumber("555111005", "+213"),
        null,
        new EmailAddress("adel.brahimi@demo.com"),
        null,
        null,
        "CTO",
        "Tech",
        defaultUser.Id,
        leads[rnd.Next(leads.Count)].Id,
        accounts[rnd.Next(accounts.Count)].Id
    ),
};
        Console.WriteLine("seeding contacts");
        await _contactRepository.InsertManyAsync(contacts);
        // seeding roles:
        

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
    public async Task SeedRolesAsync(DataSeedContext context)
    {
        if (await _roleRepository.GetCountAsync() > 1)
        {
            return;
        }
        var rMarketaire = new IdentityRole(_guidGenerator.Create(), "Marketaire")
        {
            IsDefault = true,
            IsPublic = true,
            IsStatic = true
        };
        var rDirecteur = new IdentityRole(_guidGenerator.Create(), "Directeur")
        {
            IsDefault = false,
            IsPublic = true,
            IsStatic = true
        };
        await _roleRepository.InsertManyAsync([rMarketaire,rDirecteur]);
    }
}
