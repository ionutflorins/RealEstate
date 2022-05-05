import { TestBed } from '@angular/core/testing';

import { ConfigurationOptionApiService } from './configuration-option-api.service';

describe('ConfigurationOptionApiService', () => {
  let service: ConfigurationOptionApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfigurationOptionApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
