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
import * as $ from "jquery";
import { forwardRef, Component } from "@angular/core";
import { NG_VALUE_ACCESSOR, NG_VALIDATORS } from "@angular/forms";
import { InputField } from "../input-field";
// import { textValidator } from "../../validators/text-validator";
import { fileValidator } from "../../validators/file-validator";
var InputFileComponent = /** @class */ (function (_super) {
    __extends(InputFileComponent, _super);
    function InputFileComponent() {
        var _this = _super.call(this) || this;
        _this._information = "Drop a file here";
        _this.elements = [];
        _this.iconsToAnimate = ["svg-upload", "svg-success", "svg-fail"];
        _this.first = true;
        return _this;
    }
    InputFileComponent_1 = InputFileComponent;
    InputFileComponent.prototype.validate = function (c) {
        console.log("validate");
        var checkUndefinded = this.data;
        if (checkUndefinded === undefined)
            return;
        var validator = fileValidator(c, checkUndefinded.label);
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
            _super.prototype.setMessage.call(this, validator);
        }
        return validator;
    };
    InputFileComponent.prototype.ngOnInit = function () {
        var _this = this;
        // for animating svg icons
        //this.iconsToAnimate.forEach(icon => {
        //  this.elements.push(document.getElementsByClassName(icon)[0]); TODO 
        //});
        // add listeners to label
        var $fileLabel = $(".file-label");
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
            .on("drop", function (e) {
            var checkUndefinded = _this.Input;
            if (checkUndefinded === undefined)
                return;
            checkUndefinded.nativeElement.files = e.originalEvent.dataTransfer.files;
            // this.file = e.originalEvent.dataTransfer.files[0];
            _this.dropped();
        });
        // if label is clicked
        var $fileInput = $(".file-input");
        $fileInput.on("change", function () {
            // this.file = $fileInput.prop("files")[0];
            _this.dropped();
        });
        $fileLabel.on("keyup", function (e) {
            if (e.keyCode == 13) {
                $fileInput.trigger("click");
            }
        });
    };
    Object.defineProperty(InputFileComponent.prototype, "information", {
        get: function () {
            return this._information;
        },
        enumerable: true,
        configurable: true
    });
    InputFileComponent.prototype.animateIcon = function (icon) {
        this.elements.forEach(function (element) {
            if (element.classList.contains("start-animation")) {
                if (element.classList.contains(icon))
                    return;
                element.classList.remove("start-animation");
                element.classList.add("end-animation");
            }
        });
        setTimeout(function () {
            var el = document.getElementsByClassName(icon)[0];
            el.classList.remove("end-animation", "hidden");
            el.classList.add("start-animation");
        }, 300);
    };
    InputFileComponent.prototype.dropped = function () {
        var checkUndefinded = this.Input;
        if (checkUndefinded === undefined)
            return;
        console.log(checkUndefinded.nativeElement.files[0]);
        _super.prototype.change.call(this, checkUndefinded.nativeElement.files[0]);
    };
    InputFileComponent.prototype.clear = function () {
        $(".file-input")[0].value = "";
        this.animateIcon("svg-upload");
        this._information = "Drop a file here";
    };
    InputFileComponent.prototype.getFile = function () {
        var checkUndefinded = this.Input;
        if (checkUndefinded === undefined)
            return;
        return checkUndefinded.nativeElement.files[0];
    };
    InputFileComponent = InputFileComponent_1 = __decorate([
        Component({
            selector: "input-file",
            templateUrl: "./input-file.component.html",
            styleUrls: ["./input-file.component.scss"],
            providers: [
                {
                    provide: NG_VALUE_ACCESSOR,
                    useExisting: forwardRef(function () { return InputFileComponent_1; }),
                    multi: true
                },
                {
                    provide: NG_VALIDATORS,
                    useExisting: forwardRef(function () { return InputFileComponent_1; }),
                    multi: true
                }
            ]
        }),
        __metadata("design:paramtypes", [])
    ], InputFileComponent);
    return InputFileComponent;
    var InputFileComponent_1;
}(InputField));
export { InputFileComponent };
//# sourceMappingURL=input-file.component.js.map