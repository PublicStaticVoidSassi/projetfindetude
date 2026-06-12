using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace UniFlowCRM.Tasks;

public interface ITaskAppService : ICrudAppService<TaskDto, Guid, TaskRequestDto, CreateUpdateTaskDto>
{

}
