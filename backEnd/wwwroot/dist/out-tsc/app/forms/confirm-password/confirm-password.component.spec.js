import { async, TestBed } from '@angular/core/testing';
import { ConfirmPasswordComponent } from './confirm-password.component';
describe('ConfirmPasswordComponent', () => {
    let component;
    let fixture;
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ConfirmPasswordComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(ConfirmPasswordComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=confirm-password.component.spec.js.map