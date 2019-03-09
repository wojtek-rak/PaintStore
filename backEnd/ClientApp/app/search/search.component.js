var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ElementRef, ViewChild } from "@angular/core";
import { ImageService } from "../services/image.service";
var SearchComponent = /** @class */ (function () {
    function SearchComponent(service) {
        this.service = service;
        this.res = null;
        this.loading = false;
    }
    SearchComponent.prototype.ngOnInit = function () {
        var _this = this;
        document.addEventListener("click", function (e) {
            // console.log(e);
            if (e.target !== _this.SearchResult.nativeElement &&
                !_this.SearchResult.nativeElement.contains(e.target) &&
                (e.target !== _this.SearchField.nativeElement &&
                    !_this.SearchField.nativeElement.contains(e.target))) {
                _this.SearchResult.nativeElement.classList.remove("display");
            }
        });
    };
    SearchComponent.prototype.search = function (value) {
        var _this = this;
        this.loading = true;
        if (value !== null && value !== "") {
            this.service.search(value).subscribe(function (res) {
                if (JSON.stringify(res) !== "[]") {
                    _this.res = res;
                    console.log(_this.res);
                    _this.SearchResult.nativeElement.classList.add("display");
                }
                else {
                    _this.res = null;
                    _this.SearchResult.nativeElement.classList.remove("display");
                }
                _this.loading = false;
            }, function (error) {
                console.log("error!", error);
            });
        }
        else {
            this.SearchResult.nativeElement.classList.remove("display");
            this.res = null;
            this.loading = false;
        }
    };
    __decorate([
        ViewChild("input"),
        __metadata("design:type", typeof (_a = typeof ElementRef !== "undefined" && ElementRef) === "function" && _a || Object)
    ], SearchComponent.prototype, "Input", void 0);
    __decorate([
        ViewChild("button"),
        __metadata("design:type", typeof (_b = typeof ElementRef !== "undefined" && ElementRef) === "function" && _b || Object)
    ], SearchComponent.prototype, "Button", void 0);
    __decorate([
        ViewChild("searchResult"),
        __metadata("design:type", typeof (_c = typeof ElementRef !== "undefined" && ElementRef) === "function" && _c || Object)
    ], SearchComponent.prototype, "SearchResult", void 0);
    __decorate([
        ViewChild("searchField"),
        __metadata("design:type", typeof (_d = typeof ElementRef !== "undefined" && ElementRef) === "function" && _d || Object)
    ], SearchComponent.prototype, "SearchField", void 0);
    SearchComponent = __decorate([
        Component({
            selector: "app-search",
            templateUrl: "./search.component.html",
            styleUrls: ["./search.component.scss"]
        }),
        __metadata("design:paramtypes", [ImageService])
    ], SearchComponent);
    return SearchComponent;
    var _a, _b, _c, _d;
}());
export { SearchComponent };
//# sourceMappingURL=search.component.js.map