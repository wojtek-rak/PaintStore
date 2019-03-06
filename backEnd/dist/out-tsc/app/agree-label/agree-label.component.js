var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, ViewChild, EventEmitter, Output } from "@angular/core";
var AgreeLabelComponent = /** @class */ (function () {
    function AgreeLabelComponent() {
        this.emitter = new EventEmitter();
    }
    AgreeLabelComponent.prototype.ngOnInit = function () {
        var _this = this;
        document.addEventListener("click", function (e) {
            if (e.path[0].classList.contains("message-container")) {
                _this.close();
            }
        });
    };
    AgreeLabelComponent.prototype.confirm = function () {
        this.close();
        this.emitter.emit();
    };
    AgreeLabelComponent.prototype.show = function () {
        var nullCheck = (document.querySelector("body"));
        if (nullCheck === null)
            return;
        nullCheck.classList.add("stop-scrolling");
        var el = this.wrapper.nativeElement;
        el.classList.add("display");
        setTimeout(function () {
            el.classList.add("opacity");
        }, 0);
    };
    AgreeLabelComponent.prototype.close = function () {
        var nullCheck = (document.querySelector("body"));
        if (nullCheck === null)
            return;
        nullCheck.classList.remove("stop-scrolling");
        var el = this.wrapper.nativeElement;
        el.classList.remove("opacity");
        setTimeout(function () {
            el.classList.remove("display");
        }, 200);
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], AgreeLabelComponent.prototype, "message", void 0);
    __decorate([
        Output(),
        __metadata("design:type", EventEmitter)
    ], AgreeLabelComponent.prototype, "emitter", void 0);
    __decorate([
        ViewChild("wrapper"),
        __metadata("design:type", Object)
    ], AgreeLabelComponent.prototype, "wrapper", void 0);
    AgreeLabelComponent = __decorate([
        Component({
            selector: "app-agree-label",
            templateUrl: "./agree-label.component.html",
            styleUrls: ["./agree-label.component.scss"]
        }),
        __metadata("design:paramtypes", [])
    ], AgreeLabelComponent);
    return AgreeLabelComponent;
}());
export { AgreeLabelComponent };
//# sourceMappingURL=agree-label.component.js.map