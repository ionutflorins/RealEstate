import { TestBed } from '@angular/core/testing';

import { PropertyConfiguraionApiService } from './property-configuraion-api.service';

describe('PropertyConfiguraionApiService', () => {
  let service: PropertyConfiguraionApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PropertyConfiguraionApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
