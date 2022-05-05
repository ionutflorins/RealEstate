import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyconfigurationitemsComponent } from './propertyconfigurationitems.component';

describe('PropertyconfigurationitemsComponent', () => {
  let component: PropertyconfigurationitemsComponent;
  let fixture: ComponentFixture<PropertyconfigurationitemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyconfigurationitemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyconfigurationitemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
