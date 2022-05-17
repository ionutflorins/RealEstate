import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPropertyconfigurationComponent } from './add-edit-propertyconfiguration.component';

describe('AddEditPropertyconfigurationComponent', () => {
  let component: AddEditPropertyconfigurationComponent;
  let fixture: ComponentFixture<AddEditPropertyconfigurationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPropertyconfigurationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPropertyconfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
