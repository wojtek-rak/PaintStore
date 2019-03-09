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
import { ImageService } from "../services/image.service";
import { FormBuilder, Validators } from "@angular/forms";
import { requiredTextValidator } from "../validators/text-validator";
import { fileValidator } from "../validators/file-validator";
import { LoggedIn } from "../classes/logged-in";
var AddPhotoComponent = /** @class */ (function (_super) {
    __extends(AddPhotoComponent, _super);
    function AddPhotoComponent(fb, service) {
        var _this = _super.call(this) || this;
        _this.fb = fb;
        _this.service = service;
        _this._uploadWarning = "";
        _this.uploadForm = _this.fb.group({
            title: ["", [Validators.required, requiredTextValidator]],
            description: "",
            tags: "",
            category: "",
            file: ["", fileValidator]
        });
        return _this;
    }
    AddPhotoComponent.prototype.ngOnInit = function () {
        _super.prototype.ngOnInit.call(this);
    };
    AddPhotoComponent.prototype.onUpload = function (form) {
        if (form.status === "INVALID") {
            this._uploadWarning = "Title and file must be added.";
        }
        else {
            var newTags_1 = [];
            var tags = form.value.tags;
            if (tags !== [] && tags !== "") {
                // console.log(tags);
                tags.forEach(function (el) {
                    newTags_1.push(el.value);
                });
            }
            form.value.tags = newTags_1;
            // console.log(form.value);
            this.service.uploadImage(form.value.file, this._loggedId, this._loggedToken);
            // .subscribe(res => {
            //   console.log(res)
            // });
            this._uploadWarning = "";
        }
    };
    Object.defineProperty(AddPhotoComponent.prototype, "uploadWarning", {
        get: function () {
            return this._uploadWarning;
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        ViewChild("message"),
        __metadata("design:type", Object)
    ], AddPhotoComponent.prototype, "Message", void 0);
    __decorate([
        ViewChild("fileInput"),
        __metadata("design:type", Object)
    ], AddPhotoComponent.prototype, "fileInput", void 0);
    AddPhotoComponent = __decorate([
        Component({
            selector: "app-add-photo",
            templateUrl: "./add-photo.component.html",
            styleUrls: ["./add-photo.component.scss"]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof FormBuilder !== "undefined" && FormBuilder) === "function" && _a || Object, ImageService])
    ], AddPhotoComponent);
    return AddPhotoComponent;
    var _a;
}(LoggedIn));
export { AddPhotoComponent };
//# sourceMappingURL=add-photo.component.js.map