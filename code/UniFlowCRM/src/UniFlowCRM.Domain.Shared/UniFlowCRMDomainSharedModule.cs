using UniFlowCRM.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.OpenIddict;
using Volo.Abp.BlobStoring.Database;

namespace UniFlowCRM;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(BlobStoringDatabaseDomainSharedModule)
    )]
public class UniFlowCRMDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        UniFlowCRMGlobalFeatureConfigurator.Configure();
        UniFlowCRMModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<UniFlowCRMDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<UniFlowCRMResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/UniFlowCRM");

            options.DefaultResourceType = typeof(UniFlowCRMResource);
            
            options.Languages.Add(new LanguageInfo("en", "en", "English")); 
            options.Languages.Add(new LanguageInfo("fr", "fr", "French")); 

        });
        
        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("UniFlowCRM", typeof(UniFlowCRMResource));
        });
    }
}
