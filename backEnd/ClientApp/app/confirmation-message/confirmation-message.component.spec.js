import { async, TestBed } from '@angular/core/testing';
import { ConfirmationMessageComponent } from './confirmation-message.component';
describe('ConfirmationMessageComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ConfirmationMessageComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(ConfirmationMessageComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=confirmation-message.component.spec.js.map