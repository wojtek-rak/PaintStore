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
import { LoggedIn } from "../classes/logged-in";
let InformationLabelComponent = class InformationLabelComponent extends LoggedIn {
    constructor() {
        super();
        // @Input() loggedUser: IsUserLoggedIn;
        this.labelName = ""; // TODO
        this.data = []; // TODO
    }
    ngOnInit() {
        super.ngOnInit();
        document.addEventListener("click", e => {
            if (e.path[0].classList.contains("message-container")) {
                this.close();
            }
        });
    }
    close() {
        const el = this.wrapper.nativeElement;
        el.classList.remove("opacity");
        setTimeout(() => {
            el.classList.remove("display");
            const nullCheck = (document.querySelector("body"));
            if (nullCheck === null)
                return;
            nullCheck.classList.remove("stop-scrolling");
        }, 200);
    }
    show(data, name) {
        // stop scrolling when label visible
        const nullCheck = (document.querySelector("body"));
        if (nullCheck === null)
            return;
        nullCheck.classList.add("stop-scrolling");
        // show element
        const el = this.wrapper.nativeElement;
        el.classList.add("display");
        setTimeout(() => {
            el.classList.add("opacity");
        }, 0);
        // set proper data - this.data is used for displaying users
        this.labelName = name;
        this.data = data;
    }
    // emitter($event) {
    //   console.log($event);
    //   if ($event === true) {
    //     console.log("wlasnie zafollowano");
    //   } else {
    //     console.log("unfollow");
    //   }
    // }
    getData() {
        return this.data;
    }
    getLabelName() {
        return this.labelName;
    }
};
__decorate([
    ViewChild("wrapper"),
    __metadata("design:type", Object)
], InformationLabelComponent.prototype, "wrapper", void 0);
InformationLabelComponent = __decorate([
    Component({
        selector: "app-information-label",
        templateUrl: "./information-label.component.html",
        styleUrls: ["./information-label.component.scss"]
    }),
    __metadata("design:paramtypes", [])
], InformationLabelComponent);
export { InformationLabelComponent };
//# sourceMappingURL=information-label.component.js.map