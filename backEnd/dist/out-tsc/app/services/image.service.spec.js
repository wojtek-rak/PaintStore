import { TestBed, inject } from '@angular/core/testing';
import { ImageService } from './image.service';
describe('ImageService', function () {
    beforeEach(function () {
        TestBed.configureTestingModule({
            providers: [ImageService]
        });
    });
    it('should be created', inject([ImageService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=image.service.spec.js.map