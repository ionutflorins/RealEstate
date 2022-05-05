import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigurationitemComponent } from './configurationitem.component';

describe('ConfigurationitemComponent', () => {
  let component: ConfigurationitemComponent;
  let fixture: ComponentFixture<ConfigurationitemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfigurationitemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigurationitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
