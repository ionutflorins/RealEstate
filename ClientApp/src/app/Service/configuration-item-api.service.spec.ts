import { TestBed } from '@angular/core/testing';

import { ConfigurationItemApiService } from './configuration-item-api.service';

describe('ConfigurationItemApiService', () => {
  let service: ConfigurationItemApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfigurationItemApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
