import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPropertyconfigurationitemsComponent } from './add-edit-propertyconfigurationitems.component';

describe('AddEditPropertyconfigurationitemsComponent', () => {
  let component: AddEditPropertyconfigurationitemsComponent;
  let fixture: ComponentFixture<AddEditPropertyconfigurationitemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPropertyconfigurationitemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPropertyconfigurationitemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
