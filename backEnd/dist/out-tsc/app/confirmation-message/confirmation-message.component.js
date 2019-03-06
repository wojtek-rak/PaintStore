var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild } from "@angular/core";
let ConfirmationMessageComponent = class ConfirmationMessageComponent {
    constructor() {
        this.message = "";
    }
    // ngOnInit() {
    //   // this.showMessage();
    // }
    show(message) {
        this.message = message;
        // show confirmation message
        let el = this.msgElement.nativeElement;
        el.classList.add("visible");
        // remove message after 8 seconds
        setTimeout(() => {
            if (el.classList.contains("visible")) {
                el.classList.add("hidden");
                setTimeout(() => {
                    el.classList.remove("hidden");
                    el.classList.remove("visible");
                }, 300);
            }
        }, 4000);
    }
    closeMessage(id) {
        let el = this.msgElement.nativeElement;
        el.classList.add("hidden");
        setTimeout(() => {
            el.classList.remove("hidden");
            el.classList.remove("visible");
        }, 300);
    }
};
__decorate([
    ViewChild("msg"),
    __metadata("design:type", Object)
], ConfirmationMessageComponent.prototype, "msgElement", void 0);
ConfirmationMessageComponent = __decorate([
    Component({
        selector: "app-confirmation-message",
        templateUrl: "./confirmation-message.component.html",
        styleUrls: ["./confirmation-message.component.scss"]
    }),
    __metadata("design:paramtypes", [])
], ConfirmationMessageComponent);
export { ConfirmationMessageComponent };
//# sourceMappingURL=confirmation-message.component.js.map