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
let AgreeLabelComponent = class AgreeLabelComponent {
    constructor() {
        this.emitter = new EventEmitter();
    }
    ngOnInit() {
        document.addEventListener("click", e => {
            if (e.path[0].classList.contains("message-container")) {
                this.close();
            }
        });
    }
    confirm() {
        this.close();
        this.emitter.emit();
    }
    show() {
        const nullCheck = (document.querySelector("body"));
        if (nullCheck === null)
            return;
        nullCheck.classList.add("stop-scrolling");
        const el = this.wrapper.nativeElement;
        el.classList.add("display");
        setTimeout(() => {
            el.classList.add("opacity");
        }, 0);
    }
    close() {
        const nullCheck = (document.querySelector("body"));
        if (nullCheck === null)
            return;
        nullCheck.classList.remove("stop-scrolling");
        const el = this.wrapper.nativeElement;
        el.classList.remove("opacity");
        setTimeout(() => {
            el.classList.remove("display");
        }, 200);
    }
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
export { AgreeLabelComponent };
//# sourceMappingURL=agree-label.component.js.map