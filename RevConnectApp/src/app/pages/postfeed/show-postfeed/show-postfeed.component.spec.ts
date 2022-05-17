import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPostfeedComponent } from './show-postfeed.component';

describe('ShowPostfeedComponent', () => {
  let component: ShowPostfeedComponent;
  let fixture: ComponentFixture<ShowPostfeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPostfeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPostfeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
