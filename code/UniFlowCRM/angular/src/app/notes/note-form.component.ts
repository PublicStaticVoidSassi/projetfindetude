import { Component, inject, OnInit, signal } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import {AccountsLookup,ContactsLookup,LeadsLookup,OpportunitiesLookup} from '../shared/lookup-components/';
import {
  ToasterService,
  ThemeSharedModule,
} from '@abp/ng.theme.shared';

import { LocalizationPipe } from '@abp/ng.core';

import {
  NotesService,
  noteTypeOptions,
} from '../proxy/notes';

@Component({
  selector: 'app-note-form',
  standalone: true,
  imports: [
    AccountsLookup,ContactsLookup,LeadsLookup,OpportunitiesLookup,
    CommonModule,
    ReactiveFormsModule,
    ThemeSharedModule,
    LocalizationPipe,
  ],
  templateUrl: './note-form.component.html',
})
export class NoteFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly notesService = inject(NotesService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly toaster = inject(ToasterService);

  form: FormGroup = this.fb.group({});
  id: string | null = null;

  loading = signal(false);

  noteTypes = noteTypeOptions;

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];

    this.buildForm();

    const query = this.route.snapshot.queryParams;

    this.form.patchValue({
      leadId: query['leadId'] ?? null,
      accountId: query['accountId'] ?? null,
      contactId: query['contactId'] ?? null,
      opportunityId: query['opportunityId'] ?? null,
    });

    if (this.id) {
      this.loading.set(true);

      this.notesService.get(this.id).subscribe({
        next: note => {
          this.form.patchValue(note);
          this.loading.set(false);
        },
        error: () => {
          this.loading.set(false);
        },
      });
    }
  }

  buildForm() {
    this.form = this.fb.group({
      // id: [null],

      title: [
        '',
        [
          Validators.required,
          Validators.maxLength(128),
        ],
      ],

      content: [
        '',
        [
          Validators.required,
        ],
      ],

      type: [
        null,
        [
          Validators.required,
        ],
      ],

      leadId: [null],
      accountId: [null],
      contactId: [null],
      opportunityId: [null],
    });
  }

  save() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.loading.set(true);

    const dto = this.form.getRawValue();

    const request = this.id
      ? this.notesService.update(this.id, dto)
      : this.notesService.create(dto);

    request.subscribe({
      next: () => {
        this.toaster.success('::SuccessfullySaved');

        this.router.navigate(['/Notes']);
      },

      error: () => {
        this.loading.set(false);
      },
    });
  }

  cancel() {
    this.router.navigate(['/Notes']);
  }
}