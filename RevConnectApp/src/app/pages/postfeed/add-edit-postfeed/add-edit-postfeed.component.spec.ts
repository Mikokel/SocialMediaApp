import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPostfeedComponent } from './add-edit-postfeed.component';

describe('AddEditPostfeedComponent', () => {
  let component: AddEditPostfeedComponent;
  let fixture: ComponentFixture<AddEditPostfeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPostfeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPostfeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
