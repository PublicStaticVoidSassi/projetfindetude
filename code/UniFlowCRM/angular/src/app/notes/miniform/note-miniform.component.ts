import { Component, inject, Input } from '@angular/core';
import { AutofocusDirective, CoreModule, LocalizationPipe } from '@abp/ng.core';
import { ModalCloseDirective, ModalComponent, Toaster, ToasterService } from '@abp/ng.theme.shared';
import { NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup,FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { bookTypeOptions } from '../../proxy/books';
import { CreateUpdateNoteDto, NotesService, NoteType, noteTypeOptions } from '../../proxy/notes';
import { AccountsLookup, ContactsLookup, LeadsLookup, OpportunitiesLookup } from '../../shared/lookup-components';
import { RequiredTag } from '../../shared/required-tag/required-tag';

@Component({
  selector: 'note-miniform',
  imports: [
    AutofocusDirective,
    CoreModule,
    LocalizationPipe,
    ModalCloseDirective,
    ModalComponent,
    NgbInputDatepicker,
    ReactiveFormsModule,
    AccountsLookup,
    ContactsLookup,
    LeadsLookup,
    OpportunitiesLookup,
    RequiredTag
  ],
  templateUrl: './note-miniform.component.html',
  styleUrl: './note-miniform.component.scss',
})
export class NoteMiniform {
  @Input() isFor! : 'lead'|'account'|'contact'|'opportunity';
  @Input() id! : string;
  private readonly fb = inject(FormBuilder);
  notesService = inject(NotesService);
  toaster = inject(ToasterService);

  form: FormGroup = this.fb.group({});

isModalOpen=  false;
openModal(){
  this.isModalOpen = true;
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
        NoteType.General,
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
  constructor() {

    this.buildForm();
  }
  save() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.toaster.success(this.form.errors.toString());
      return;
    }


    const dto = this.form.getRawValue();

    let request = this.notesService.create(dto);

    request.subscribe({
      next: () => {
        this.toaster.success('::SuccessfullySaved');
        this.form.reset();
        this.isModalOpen = false;
        // window.reload();
      },
      error: err => {
        this.toaster.error(err.message);
      }
    });
  }


  protected readonly noteTypes = noteTypeOptions;
}
