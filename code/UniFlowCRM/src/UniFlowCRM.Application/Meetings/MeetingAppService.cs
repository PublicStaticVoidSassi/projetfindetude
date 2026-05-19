using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
namespace UniFlowCRM.Meetings;

public class MeetingAppService :

  CrudAppService<Meeting, MeetingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMeetingDto>,
  IMeetingAppService
{
    public MeetingAppService(IRepository<Meeting, Guid> repository) :
      base(repository)
    {

    }
}
