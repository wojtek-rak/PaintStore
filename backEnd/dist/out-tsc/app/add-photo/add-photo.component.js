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
let AddPhotoComponent = class AddPhotoComponent extends LoggedIn {
    constructor(fb, service) {
        super();
        this.fb = fb;
        this.service = service;
        this._uploadWarning = "";
        this.uploadForm = this.fb.group({
            title: ["", [Validators.required, requiredTextValidator]],
            description: "",
            tags: "",
            category: "",
            file: ["", fileValidator]
        });
    }
    ngOnInit() {
        super.ngOnInit();
    }
    onUpload(form) {
        if (form.status === "INVALID") {
            this._uploadWarning = "Title and file must be added.";
        }
        else {
            let newTags = [];
            let tags = form.value.tags;
            if (tags !== [] && tags !== "") {
                // console.log(tags);
                tags.forEach((el) => {
                    newTags.push(el.value);
                });
            }
            form.value.tags = newTags;
            // console.log(form.value);
            this.service.uploadImage(form.value.file, this._loggedId, this._loggedToken);
            // .subscribe(res => {
            //   console.log(res)
            // });
            this._uploadWarning = "";
        }
    }
    get uploadWarning() {
        return this._uploadWarning;
    }
};
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
    __metadata("design:paramtypes", [FormBuilder, ImageService])
], AddPhotoComponent);
export { AddPhotoComponent };
//# sourceMappingURL=add-photo.component.js.map