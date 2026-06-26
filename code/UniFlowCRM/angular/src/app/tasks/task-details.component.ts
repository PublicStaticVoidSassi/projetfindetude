import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TasksService } from '../proxy/tasks/tasks.service';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule, ConfirmationService, ToasterService, Confirmation } from '@abp/ng.theme.shared';
import { LocalizationPipe } from '@abp/ng.core';
import { ReturnBtn } from "../shared/return-btn/return-btn";

@Component({
  selector: 'app-task-details',
  standalone: true,
  imports: [CommonModule, ThemeSharedModule, LocalizationPipe, ReturnBtn],
  templateUrl: './task-details.component.html',
})
export class TaskDetailsComponent implements OnInit {
  private readonly taskService = inject(TasksService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly confirmation = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  task = signal<any>(null);

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.taskService.get(id).subscribe((data) => this.task.set(data));
    }
  }

  edit() {
    this.router.navigate(['/Tasks/form', this.task().id]);
  }

  delete() {
    this.confirmation.warn('::AreYouSureValue', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.taskService.delete(this.task().id).subscribe(() => {
          this.toaster.success('::SuccessfullyDeleted');
          this.router.navigate(['/Tasks']);
        });
      }
    });
  }

  goBack() {
    this.router.navigate(['/Tasks']);
  }
}
