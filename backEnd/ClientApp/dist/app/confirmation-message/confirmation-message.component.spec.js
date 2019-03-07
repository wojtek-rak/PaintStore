import { async, TestBed } from '@angular/core/testing';
import { ConfirmationMessageComponent } from './confirmation-message.component';
describe('ConfirmationMessageComponent', () => {
    let component;
    let fixture;
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ConfirmationMessageComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ConfirmationMessageComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=confirmation-message.component.spec.js.map