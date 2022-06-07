import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditConfigurationoptionComponent } from './add-edit-configurationoption.component';

describe('AddEditConfigurationoptionComponent', () => {
  let component: AddEditConfigurationoptionComponent;
  let fixture: ComponentFixture<AddEditConfigurationoptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditConfigurationoptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditConfigurationoptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
