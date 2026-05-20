using Volo.Abp.Application.Services;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
namespace UniFlowCRM.Emails;

public class EmailsAppService :
  CrudAppService<Email,
  EmailDto,
  Guid,
  PagedAndSortedResultRequestDto,
  CreateUpdateEmailDto
  >, IEmailAppService
{
    public EmailsAppService(IRepository<Email, Guid> repository) : base(repository)
    {

    }
}
