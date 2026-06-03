import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteMiniform } from './note-miniform.component';

describe('Miniform', () => {
  let component: NoteMiniform;
  let fixture: ComponentFixture<NoteMiniform>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NoteMiniform]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NoteMiniform);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
