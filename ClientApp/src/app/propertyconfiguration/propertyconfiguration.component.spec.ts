import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyconfigurationComponent } from './propertyconfiguration.component';

describe('PropertyconfigurationComponent', () => {
  let component: PropertyconfigurationComponent;
  let fixture: ComponentFixture<PropertyconfigurationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyconfigurationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyconfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
