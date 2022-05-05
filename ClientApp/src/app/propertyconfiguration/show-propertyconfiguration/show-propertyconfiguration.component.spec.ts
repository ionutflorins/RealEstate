import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPropertyconfigurationComponent } from './show-propertyconfiguration.component';

describe('ShowPropertyconfigurationComponent', () => {
  let component: ShowPropertyconfigurationComponent;
  let fixture: ComponentFixture<ShowPropertyconfigurationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPropertyconfigurationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPropertyconfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
