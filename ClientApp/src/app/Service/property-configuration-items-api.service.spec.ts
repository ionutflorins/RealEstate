import { TestBed } from '@angular/core/testing';

import { PropertyConfigurationItemsApiService } from './property-configuration-items-api.service';

describe('PropertyConfigurationItemsApiService', () => {
  let service: PropertyConfigurationItemsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PropertyConfigurationItemsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
