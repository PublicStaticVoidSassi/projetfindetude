import { Component, Input } from '@angular/core';
import { LocalizationPipe, ShortDateTimePipe } from '@abp/ng.core';
import { NoteDto, NoteType } from '../../proxy/notes';
import { DatePipe, NgClass } from '@angular/common';

@Component({
  selector: 'app-note-mini-ui',
  imports: [
    LocalizationPipe,
    NgClass,
    ShortDateTimePipe,
    DatePipe
  ],
  templateUrl: './note-mini-ui.html',
  styleUrl: './note-mini-ui.scss',
})
export class NoteMiniUi {
    @Input() note : NoteDto;
  protected readonly NoteType = NoteType;
}
