var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import * as $ from "jquery";
import { forwardRef, Component } from "@angular/core";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { InputField } from "../input-field";
// import { textValidator } from "../../validators/text-validator";
import { fileValidator } from "../../validators/file-validator";
let InputFileComponent = InputFileComponent_1 = class InputFileComponent extends InputField {
    constructor() {
        super();
        this._information = "Drop a file here";
        this.elements = [];
        this.iconsToAnimate = ["svg-upload", "svg-success", "svg-fail"];
        this.first = true;
    }
    validate(c) {
        console.log("validate");
        const checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        let validator = fileValidator(c, checkUndefinded.label);
        if (validator === null) {
            // if there is no errors, animate succes icon
            if (!this.first) {
                this.animateIcon("svg-success");
            }
            else
                this.first = false;
        }
        else {
            // animate error icon
            this.animateIcon("svg-fail");
        }
        if (!this.first) {
            super.setMessage(validator);
        }
        return validator;
    }
    ngOnInit() {
        // for animating svg icons
        //this.iconsToAnimate.forEach(icon => {
        //  this.elements.push(document.getElementsByClassName(icon)[0]); TODO 
        //});
        // add listeners to label
        let $fileLabel = $(".file-label");
        $fileLabel
            .on("drag dragstart dragend dragover dragenter dragleave drop", function (e) {
            e.preventDefault();
        })
            .on("dragover dragenter", function () {
            $fileLabel.addClass("is-dragover");
        })
            .on("dragleave dragend drop", function () {
            $fileLabel.removeClass("is-dragover");
        })
            .on("drop", (e) => {
            const checkUndefinded = this.Input;
            if (checkUndefinded === undefined)
                return;
            checkUndefinded.nativeElement.files = e.originalEvent.dataTransfer.files;
            // this.file = e.originalEvent.dataTransfer.files[0];
            this.dropped();
        });
        // if label is clicked
        let $fileInput = $(".file-input");
        $fileInput.on("change", () => {
            // this.file = $fileInput.prop("files")[0];
            this.dropped();
        });
        $fileLabel.on("keyup", function (e) {
            if (e.keyCode == 13) {
                $fileInput.trigger("click");
            }
        });
    }
    get information() {
        return this._information;
    }
    animateIcon(icon) {
        this.elements.forEach((element) => {
            if (element.classList.contains("start-animation")) {
                if (element.classList.contains(icon))
                    return;
                element.classList.remove("start-animation");
                element.classList.add("end-animation");
            }
        });
        setTimeout(() => {
            let el = document.getElementsByClassName(icon)[0];
            el.classList.remove("end-animation", "hidden");
            el.classList.add("start-animation");
        }, 300);
    }
    dropped() {
        const checkUndefinded = this.Input;
        if (checkUndefinded === undefined)
            return;
        console.log(checkUndefinded.nativeElement.files[0]);
        super.change(checkUndefinded.nativeElement.files[0]);
    }
    clear() {
        //$(".file-input")[0].value = ""; TODO
        this.animateIcon("svg-upload");
        this._information = "Drop a file here";
    }
    getFile() {
        const checkUndefinded = this.Input;
        if (checkUndefinded === undefined)
            return;
        return checkUndefinded.nativeElement.files[0];
    }
};
InputFileComponent = InputFileComponent_1 = __decorate([
    Component({
        selector: "input-file",
        templateUrl: "./input-file.component.html",
        styleUrls: ["./input-file.component.scss"],
        providers: [
            {
                provide: NG_VALUE_ACCESSOR,
                useExisting: forwardRef(() => InputFileComponent_1),
                multi: true
            },
            {
                provide: NG_VALIDATORS,
                useExisting: forwardRef(() => InputFileComponent_1),
                multi: true
            }
        ]
    }),
    __metadata("design:paramtypes", [])
], InputFileComponent);
export { InputFileComponent };
var InputFileComponent_1;
//# sourceMappingURL=input-file.component.js.map