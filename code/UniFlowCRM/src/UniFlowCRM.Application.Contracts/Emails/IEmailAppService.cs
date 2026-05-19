using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System;
namespace UniFlowCRM.Emails;

public interface IEmailAppService : ICrudAppService<EmailDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmailDto>
{

}
