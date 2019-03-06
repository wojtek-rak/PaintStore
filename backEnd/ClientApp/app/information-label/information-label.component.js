var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var InformationLabelComponent = /** @class */ (function (_super) {
    __extends(InformationLabelComponent, _super);
    function InformationLabelComponent() {
        return _super.call(this) || this;
    }
    InformationLabelComponent.prototype.ngOnInit = function () {
        var _this = this;
        _super.prototype.ngOnInit.call(this);
        document.addEventListener("click", function (e) {
            if (e.path[0].classList.contains("message-container")) {
                _this.close();
            }
        });
    };
    InformationLabelComponent.prototype.close = function () {
        var el = this.wrapper.nativeElement;
        el.classList.remove("opacity");
        setTimeout(function () {
            el.classList.remove("display");
            document.querySelector("body").classList.remove("stop-scrolling");
        }, 200);
    };
    InformationLabelComponent.prototype.show = function (data, name) {
        // stop scrolling when label visible
        document.querySelector("body").classList.add("stop-scrolling");
        // show element
        var el = this.wrapper.nativeElement;
        el.classList.add("display");
        setTimeout(function () {
            el.classList.add("opacity");
        }, 0);
        // set proper data - this.data is used for displaying users
        this.labelName = name;
        this.data = data;
    };
    // emitter($event) {
    //   console.log($event);
    //   if ($event === true) {
    //     console.log("wlasnie zafollowano");
    //   } else {
    //     console.log("unfollow");
    //   }
    // }
    InformationLabelComponent.prototype.getData = function () {
        return this.data;
    };
    InformationLabelComponent.prototype.getLabelName = function () {
        return this.labelName;
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
    return InformationLabelComponent;
}(LoggedIn));
export { InformationLabelComponent };
//# sourceMappingURL=information-label.component.js.map