using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using UniFlowCRM.Books;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using UniFlowCRM.Leads;
using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.EmailAddresses;
using UniFlowCRM.Opportunities;
using UniFlowCRM.URLs;
using UniFlowCRM.Notes;
using UniFlowCRM.Tasks;
using UniFlowCRM.Calls;
using UniFlowCRM.Meetings;
using UniFlowCRM.Emails;
using UniFlowCRM.Dashboards;


namespace UniFlowCRM.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ConnectionStringName("Default")]
public class UniFlowCRMDbContext :
    AbpDbContext<UniFlowCRMDbContext>,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    // public DbSet<Book> Books { get; set; } // keeping it as a good luck charm

    public DbSet<Lead> Leads { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Opportunity> Opportunities { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Call> Calls { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Email> Emails { get; set; }
    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    #endregion

    public UniFlowCRMDbContext(DbContextOptions<UniFlowCRMDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region defaults
        base.OnModelCreating(builder);
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureBlobStoring();
        #endregion

        // views and functions
        builder.Entity<Dashboard>()
            .HasNoKey()
            .ToView("dashboard", UniFlowCRMConsts.DbSchema);
        builder.Entity<Income>()
            .HasNoKey()
            .ToView("incomepercurrency", UniFlowCRMConsts.DbSchema);
        #region Accounts
        builder.Entity<Account>(b =>
        {
            b.ToTable(UniFlowCRMConsts.DbTablePrefix + "Accounts",
                UniFlowCRMConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(l => l.UserID).IsRequired();
            b.Property(l => l.Email)
            .HasConversion(
                v => v == null ? null : v.ToString(), // write
                v => v == null ? null : new EmailAddress(v)  // read
            )
            .HasColumnName("Email");
            b.Property(l => l.Phone)
            .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new PhoneNumbers.PhoneNumber(v))
            .HasColumnName("Phone");
            b.Property(l => l.Fax)
            .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new PhoneNumbers.PhoneNumber(v))
            .HasColumnName("Fax");
            b.OwnsOne(l => l.Address, a =>
            {
                a.Property(a => a.Street).HasColumnName("Street");
                a.Property(a => a.City).HasColumnName("City");
                a.Property(a => a.Country).HasColumnName("Country");
                a.Property(a => a.PostalCode).HasColumnName("PostalCode");
            });
            b.Property(l => l.Website)
            .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new URL(v))
            .HasColumnName("Website");
            b.OwnsOne<Moneys.Money>(l => l.Revenue, r =>
            {
                r.Property(r => r.Value).HasColumnName("IncomeValue");
                r.Property(r => r.Currency).HasColumnName("IncomeCurrency");
            });
        });
        #endregion
        #region leads
        builder.Entity<Lead>(b =>
        {
            b.ToTable(UniFlowCRMConsts.DbTablePrefix + "Leads",
                UniFlowCRMConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(l => l.UserID).IsRequired();
            b.HasOne<Account>().WithMany().HasForeignKey(l => l.AccountID).IsRequired(false);
            b.Property(l => l.Email)
            .HasConversion(
                v => v == null ? null : v.ToString(), // write
                v => v == null ? null : new EmailAddress(v)  // read
            )
            .HasColumnName("Email");
            b.Property(l => l.Phone)
            .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new PhoneNumbers.PhoneNumber(v))
            .HasColumnName("Phone");

            #endregion
            #region Contacts
            builder.Entity<Contact>(b =>
            {
                b.ToTable(UniFlowCRMConsts.DbTablePrefix + "Contacts",
                    UniFlowCRMConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<Lead>().WithMany().HasForeignKey(c => c.LeadID).IsRequired(false);
                b.HasOne<IdentityUser>().WithMany().HasForeignKey(l => l.UserID).IsRequired();
                b.HasOne<Account>().WithMany().HasForeignKey(l => l.AccountID).IsRequired(false);
                b.Property(l => l.Email)
                .HasConversion(
                    v => v == null ? null : v.ToString(), // write
                    v => v == null ? null : new EmailAddress(v)  // read
                )
                .HasColumnName("Email");
                b.Property(l => l.Phone)
                .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new PhoneNumbers.PhoneNumber(v))
                .HasColumnName("Phone");
                b.Property(l => l.Fax)
                .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new PhoneNumbers.PhoneNumber(v))
                .HasColumnName("Fax");
                b.OwnsOne(l => l.Address, a =>
                {
                    a.Property(a => a.Street).HasColumnName("Street");
                    a.Property(a => a.City).HasColumnName("City");
                    a.Property(a => a.Country).HasColumnName("Country");
                    a.Property(a => a.PostalCode).HasColumnName("PostalCode");
                });
                b.Property(l => l.Website)
                .HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new URL(v))
                .HasColumnName("Website");
            });
            #endregion

            #region Opporunities
            builder.Entity<Opportunity>(b =>
            {
                b.ToTable(UniFlowCRMConsts.DbTablePrefix + "Opportunities",
                    UniFlowCRMConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<IdentityUser>().WithMany().HasForeignKey(l => l.UserID).IsRequired();
                b.HasOne<Account>().WithMany().HasForeignKey(l => l.AccountID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
                b.HasOne<Lead>().WithMany().HasForeignKey(l => l.LeadID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
                b.HasOne<Contact>().WithMany().HasForeignKey(l => l.ContactID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
                b.OwnsOne<Moneys.Money>(l => l.Amount, r =>
                {
                    r.Property(r => r.Value).HasColumnName("AmountValue");
                    r.Property(r => r.Currency).HasColumnName("AmountCurrency");
                });
            });
        });
        #endregion

        #region Notes

        builder.Entity<Note>(b =>
        {
            b.ConfigureByConvention();
            b.ToTable("notes", UniFlowCRMConsts.DbSchema);
            b.HasOne<Lead>().WithMany().HasForeignKey(n => n.LeadId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Account>().WithMany().HasForeignKey(n => n.AccountId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Contact>().WithMany().HasForeignKey(n => n.ContactId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Opportunity>().WithMany().HasForeignKey(n => n.OpportunityId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        });


        #endregion

        #region Tasks
        builder.Entity<Task>(b =>
        {
            b.ConfigureByConvention();

            b.ToTable("tasks", UniFlowCRMConsts.DbSchema);
            b.HasOne<Lead>().WithMany().HasForeignKey(n => n.LeadID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(n => n.OwnerID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Account>().WithMany().HasForeignKey(n => n.AccountID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Contact>().WithMany().HasForeignKey(n => n.ContactID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Opportunity>().WithMany().HasForeignKey(n => n.OpportunityID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        });
        #endregion
        #region Calls
        builder.Entity<Call>(b =>
        {
            b.ConfigureByConvention();
            b.ToTable("calls", UniFlowCRMConsts.DbSchema);
            b.Property(e => e.PhoneNumber).HasConversion(v => v == null ? null : v.ToString(), v => v == null ? null : new PhoneNumbers.PhoneNumber(v));
            b.HasOne<Lead>().WithMany().HasForeignKey(n => n.LeadID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(n => n.OwnerID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Account>().WithMany().HasForeignKey(n => n.AccountID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Contact>().WithMany().HasForeignKey(n => n.ContactID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Opportunity>().WithMany().HasForeignKey(n => n.OpportunityID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        });
        #endregion
        #region Meetings
        builder.Entity<Meeting>(b =>
        {
            b.ConfigureByConvention();
            b.ToTable("meetings", UniFlowCRMConsts.DbSchema);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(n => n.OwnerID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Lead>().WithMany().HasForeignKey(n => n.LeadID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Account>().WithMany().HasForeignKey(n => n.AccountID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Contact>().WithMany().HasForeignKey(n => n.ContactID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Opportunity>().WithMany().HasForeignKey(n => n.OpportunityID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        });
        #endregion
        #region Emails
        builder.Entity<Email>(b =>
        {
            b.ConfigureByConvention();
            b.ToTable("emails", UniFlowCRMConsts.DbSchema);
            b.Property<EmailAddress>(e => e.From).HasConversion(v => (v == null) ? null : v.ToString(), v => (v == null) ? null : new EmailAddress(v));
            b.Property<EmailAddress>(e => e.To).HasConversion(v => (v == null) ? null : v.ToString(), v => (v == null) ? null : new EmailAddress(v));
            b.Property<EmailAddress>(e => e.Bcc).HasConversion(v => (v == null) ? null : v.ToString(), v => (v == null) ? null : new EmailAddress(v));
            b.Property<EmailAddress>(e => e.Cc).HasConversion(v => (v == null) ? null : v.ToString(), v => (v == null) ? null : new EmailAddress(v));
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(n => n.OwnerID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Lead>().WithMany().HasForeignKey(n => n.LeadID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Account>().WithMany().HasForeignKey(n => n.AccountID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Contact>().WithMany().HasForeignKey(n => n.ContactID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            b.HasOne<Opportunity>().WithMany().HasForeignKey(n => n.OpportunityID).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        });
        #endregion




    }
}
