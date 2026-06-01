import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService, ThemeSharedModule } from '@abp/ng.theme.shared';
import { TasksService } from '../proxy/tasks/tasks.service';
import { LocalizationPipe } from '@abp/ng.core';
import { CommonModule } from '@angular/common';
import {
  taskStatusOptions,
  taskPriorityOptions
} from '../proxy/tasks/index';
import {AccountsLookup,LeadsLookup,OpportunitiesLookup,UsersLookup,ContactsLookup} from '../shared/lookup-components';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [AccountsLookup,LeadsLookup,OpportunitiesLookup,UsersLookup,ContactsLookup,LocalizationPipe,CommonModule, ReactiveFormsModule, ThemeSharedModule],
  templateUrl: './task-form.component.html',
})
export class TaskFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly taskService = inject(TasksService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly toaster = inject(ToasterService);

  taskStatuses = taskStatusOptions;
  taskPriorities = taskPriorityOptions;
  form: FormGroup = this.fb.group({});
  id: string | null = null;
  loading = signal(false);

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.buildForm();

    if (this.id) {
      this.loading.set(true);
      this.taskService.get(this.id).subscribe((task) => {
        this.form.patchValue(task);
        this.loading.set(false);
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      status: [null],
      priority: [null],
      startTime: [null],
      endTime: [null],
      completedAt: [null],
      owner: [null],
      accountID: [null],
      contactID: [null],
      opportunityID: [null],
      leadID: [null],
    });
  }

  save() {
    if (this.form.invalid) return;

    this.loading.set(true);
    const request = this.id
      ? this.taskService.update(this.id, this.form.value)
      : this.taskService.create(this.form.value);

    request.subscribe({
      next: () => {
        this.toaster.success('::SuccessfullySaved');
        this.router.navigate(['/Tasks']);
      },
      error: () => this.loading.set(false),
    });
  }

  cancel() {
    this.router.navigate(['/Tasks']);
  }
}
