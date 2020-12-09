import { TestBed } from '@angular/core/testing';

import { CollectionCallService } from './collection-call.service';

describe('CollectionCallService', () => {
  let service: CollectionCallService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CollectionCallService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
