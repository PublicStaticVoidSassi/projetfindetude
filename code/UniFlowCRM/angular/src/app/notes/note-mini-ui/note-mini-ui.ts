import {
  Input,
  OnInit,
  Component, 
  ApplicationRef, 
  EnvironmentInjector, 
  createComponent, 
  ComponentRef, 
  EmbeddedViewRef,
  inject
} from '@angular/core';
import { ConfigStateService, LocalizationPipe, ShortDateTimePipe } from '@abp/ng.core';
import { NoteDto, NotesService, NoteType,noteTypeOptions } from '../../proxy/notes';
import { DatePipe, NgClass } from '@angular/common';
import { Confirmation, ConfirmationService, ToasterService, AbpVisibleDirective, ModalComponent } from '@abp/ng.theme.shared';
import {NoteMiniform} from '../miniform/note-miniform.component';
import { RequiredTag } from "src/app/shared/required-tag/required-tag";
import { FormBuilder, FormGroup,ReactiveFormsModule, Validators } from '@angular/forms';
@Component({
  selector: 'app-note-mini-ui',
  imports: [
    ReactiveFormsModule,
    LocalizationPipe,
    NgClass,
    ShortDateTimePipe,
    DatePipe,
    AbpVisibleDirective,
    ModalComponent,
    RequiredTag
],
  templateUrl: './note-mini-ui.html',
  styleUrl: './note-mini-ui.scss',
})
export class NoteMiniUi implements OnInit{
save() {
  this.noteService.update(this.note.id as string,this.form.getRawValue())
  .subscribe((r)=>{
    this.Toaster.success("updated successfully");
    let creator = this.note.creator;
    this.note = {...r,creator};
    this.isModalOpen = false;
    // setTimeout(()=>{location.reload()},1000);
  });
}
  @Input() note! : NoteDto;
  private readonly configState = inject(ConfigStateService);
  private readonly noteService = inject(NotesService);
  private readonly confirmService = inject(ConfirmationService);
  private readonly Toaster = inject(ToasterService);

  //
 //
  isHidden : boolean = false;
  isOwner : boolean = false;
  NoteType = NoteType;
  NoteTypeOptions = noteTypeOptions;
  isModalOpen: boolean = false;
  fb = inject(FormBuilder);
  form: FormGroup = this.fb.group({});;
  isFor: undefined | 'lead' | 'account' | 'contact' | 'opportunity';
  
  ngOnInit() {
    this.form = this.fb.group({
      // id: [null],

      title: [
        this.note.title,
        [
          Validators.required,
          Validators.maxLength(128),
        ],
      ],

      content: [
        this.note.content,
        [
          Validators.required,
        ],
      ],

      type: [
        this.note.type,
        [
          Validators.required,
        ],
      ],

      leadId:         [this.note.leadId],
      accountId:      [this.note.accountId],
      contactId:      [this.note.contactId],
      opportunityId:  [this.note.opportunityId],
    });
  
    setTimeout(()=>{
        this.isOwner = this.configState.getOne('currentUser').id === this.note.creator?.id;
        // console.log(this.configState.getOne('currentUser').id,this.note.creator?.id)
    },1000)
  }
  delete(){
    this.confirmService.show("it cannot be undone","are you sure you want to delete this?")
    .subscribe(r=>{
      if (r === Confirmation.Status.confirm){
        this.noteService.delete(this.note.id as string)
        .subscribe(()=>{
          this.Toaster.success("deleted successfully");
          this.hide();
        });
      }
    });
  }
  edit(){
    this.isModalOpen = true;
    }
  hide(){
    this.isHidden = true;
  }
}
