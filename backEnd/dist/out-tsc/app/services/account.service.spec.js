import { TestBed, inject } from '@angular/core/testing';
import { AccountService } from './account.service';
describe('AccountService', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [AccountService]
        });
    });
    it('should be created', inject([AccountService], (service) => {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=account.service.spec.js.map