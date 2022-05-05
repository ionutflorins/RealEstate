import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowConfigurationoptionComponent } from './show-configurationoption.component';

describe('ShowConfigurationoptionComponent', () => {
  let component: ShowConfigurationoptionComponent;
  let fixture: ComponentFixture<ShowConfigurationoptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowConfigurationoptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowConfigurationoptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
