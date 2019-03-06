import { TestBed, inject } from "@angular/core/testing";
import { UserService } from "./user.service";
describe("UserService", () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [UserService]
        });
    });
    it("should be created", inject([UserService], (service) => {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=user.service.spec.js.map