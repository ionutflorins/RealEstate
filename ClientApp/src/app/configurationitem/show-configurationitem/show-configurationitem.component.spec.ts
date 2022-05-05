import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowConfigurationitemComponent } from './show-configurationitem.component';

describe('ShowConfigurationitemComponent', () => {
  let component: ShowConfigurationitemComponent;
  let fixture: ComponentFixture<ShowConfigurationitemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowConfigurationitemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowConfigurationitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
