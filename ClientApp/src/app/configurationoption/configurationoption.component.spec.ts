import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurationoptionComponent } from './configurationoption.component';

describe('ConfigurationoptionComponent', () => {
  let component: ConfigurationoptionComponent;
  let fixture: ComponentFixture<ConfigurationoptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfigurationoptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurationoptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
