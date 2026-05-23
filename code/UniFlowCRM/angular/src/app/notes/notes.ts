import { Component, inject, OnInit } from '@angular/core';
import {
  ListService,
  PagedResultDto,
  PermissionDirective,
} from '@abp/ng.core';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import {
  NgxDatatableListDirective,
  NgxDatatableDefaultDirective,
  ConfirmationService,
  ToasterService,
} from '@abp/ng.theme.shared';

import { LocalizationPipe } from '@abp/ng.core';
import { Router } from '@angular/router';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

import { NotesService, NoteDto, noteTypeOptions } from '../proxy/notes';

@Component({
  selector: 'app-notes',
  imports: [
    NgbDropdownModule,
    NgxDatatableModule,
    NgxDatatableListDirective,
    NgxDatatableDefaultDirective,
    LocalizationPipe,
    PermissionDirective,
  ],
  templateUrl: './notes.html',
  styleUrl: './notes.scss',
  providers: [ListService],
})
export class NotesComponent implements OnInit {
  private readonly _notesService = inject(NotesService);
  private readonly router = inject(Router);
  private readonly confirm = inject(ConfirmationService);
  private readonly toaster = inject(ToasterService);

  List = inject(ListService);

  notes = {} as PagedResultDto<NoteDto>;
  notetypes= noteTypeOptions;
  refreshList = () => {
    this.List.get();
  };

  ngOnInit() {
    this.List.hookToQuery(q => {
      return this._notesService.getList(q);
    }).subscribe(notes => {
      this.notes = notes;
    });
  }

  openDetails(id: string) {
    this.router.navigate(['/Notes/' + id]);
  }

  delete(id: string) {
    this.confirm
      .warn(
        '::Note:Delete:Warning:Text',
        '::Note:Delete:Warning:Title'
      )
      .subscribe(result => {
        if (result == 'confirm') {
          this._notesService.delete(id).subscribe(() => {
            this.toaster.success('::Note:Deleted:Success');
            this.refreshList();
          });
        } else {
          this.toaster.show('::Note:Deleted:Canceled');
        }
      });
  }

  edit(id: string) {
    this.router.navigate(['/Notes/form/' + id]);
  }

  create() {
    this.router.navigate(['/Notes/form/']);
  }
}