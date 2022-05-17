import { TestBed } from '@angular/core/testing';

import { PostfeedApi.ServiceService } from './postfeed-api.service.service';

describe('PostfeedApi.ServiceService', () => {
  let service: PostfeedApi.ServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PostfeedApi.ServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
