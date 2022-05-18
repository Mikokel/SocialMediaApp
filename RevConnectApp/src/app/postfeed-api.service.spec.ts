import { TestBed } from '@angular/core/testing';

import { PostfeedApiService } from './postfeed-api.service';

describe('PostfeedApiService', () => {
  let service: PostfeedApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PostfeedApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
