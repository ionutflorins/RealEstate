import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditConfigurationitemComponent } from './add-edit-configurationitem.component';

describe('AddEditConfigurationitemComponent', () => {
  let component: AddEditConfigurationitemComponent;
  let fixture: ComponentFixture<AddEditConfigurationitemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditConfigurationitemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditConfigurationitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
