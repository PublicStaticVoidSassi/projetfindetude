import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteMiniUi } from './note-mini-ui';

describe('NoteMiniUi', () => {
  let component: NoteMiniUi;
  let fixture: ComponentFixture<NoteMiniUi>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NoteMiniUi]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NoteMiniUi);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
