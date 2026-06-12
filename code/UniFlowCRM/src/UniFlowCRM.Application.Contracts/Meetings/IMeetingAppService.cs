using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
namespace UniFlowCRM.Meetings;

public interface IMeetingAppService : ICrudAppService<MeetingDto, Guid, MeetingRequestDto, CreateUpdateMeetingDto>
{

}
