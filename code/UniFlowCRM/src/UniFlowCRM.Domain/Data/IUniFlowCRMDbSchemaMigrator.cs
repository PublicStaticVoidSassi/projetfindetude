using System.Threading.Tasks;

namespace UniFlowCRM.Data;

public interface IUniFlowCRMDbSchemaMigrator
{
    Task MigrateAsync();
}
