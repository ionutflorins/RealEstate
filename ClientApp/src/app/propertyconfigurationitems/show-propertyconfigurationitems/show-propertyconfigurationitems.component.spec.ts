import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPropertyconfigurationitemsComponent } from './show-propertyconfigurationitems.component';

describe('ShowPropertyconfigurationitemsComponent', () => {
  let component: ShowPropertyconfigurationitemsComponent;
  let fixture: ComponentFixture<ShowPropertyconfigurationitemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPropertyconfigurationitemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPropertyconfigurationitemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
