using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
namespace UniFlowCRM.Meetings;

public class MeetingsAppService :

  CrudAppService<Meeting, MeetingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMeetingDto>,
  IMeetingAppService
{
    public MeetingsAppService(IRepository<Meeting, Guid> repository) :
      base(repository)
    {

    }
}
