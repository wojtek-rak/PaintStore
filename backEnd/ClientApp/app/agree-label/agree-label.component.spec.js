import { async, TestBed } from '@angular/core/testing';
import { AgreeLabelComponent } from './agree-label.component';
describe('AgreeLabelComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [AgreeLabelComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(AgreeLabelComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=agree-label.component.spec.js.map