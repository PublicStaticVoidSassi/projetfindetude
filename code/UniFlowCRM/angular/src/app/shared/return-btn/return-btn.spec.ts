import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnBtn } from './return-btn';

describe('ReturnBtn', () => {
  let component: ReturnBtn;
  let fixture: ComponentFixture<ReturnBtn>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReturnBtn]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReturnBtn);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
