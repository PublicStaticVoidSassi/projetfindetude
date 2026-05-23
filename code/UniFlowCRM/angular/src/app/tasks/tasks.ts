import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, inject, OnInit } from '@angular/core';
import { TasksService } from '../proxy/tasks/tasks.service';
import { TaskDto } from '../proxy/tasks/models';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { RouterLink, Router } from '@angular/router';
import { LocalizationPipe } from '@abp/ng.core';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [LocalizationPipe, CommonModule, ThemeSharedModule, RouterLink],
  templateUrl: './tasks.html',
  styleUrl: './tasks.scss',
  providers: [ListService],
})
export class Tasks implements OnInit {
  private readonly router = inject(Router);
  private readonly taskService = inject(TasksService);
  public readonly list = inject(ListService);

  tasks = {} as PagedResultDto<TaskDto>;

  ngOnInit() {
    const taskStreamCreator = (query: PagedAndSortedResultRequestDto) => this.taskService.getList(query);

    this.list.hookToQuery(taskStreamCreator).subscribe((response) => {
      this.tasks = response;
    });
  }

  create() {
    this.router.navigate(['/Tasks/form']);
  }

  delete(id: string) {
    if (confirm('Are you sure?')) {
      this.taskService.delete(id).subscribe(() => {
        this.list.get();
      });
    }
  }
}
