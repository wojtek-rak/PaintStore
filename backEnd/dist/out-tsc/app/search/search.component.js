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
let SearchComponent = class SearchComponent {
    constructor(service) {
        this.service = service;
        this.res = []; // TODO
        this.loading = false;
    }
    ngOnInit() {
        document.addEventListener("click", e => {
            // console.log(e);
            if (e.target !== this.SearchResult.nativeElement &&
                !this.SearchResult.nativeElement.contains(e.target) &&
                (e.target !== this.SearchField.nativeElement &&
                    !this.SearchField.nativeElement.contains(e.target))) {
                this.SearchResult.nativeElement.classList.remove("display");
            }
        });
    }
    search(value) {
        this.loading = true;
        if (value !== null && value !== "") {
            this.service.search(value).subscribe(res => {
                if (JSON.stringify(res) !== "[]") {
                    this.res = res;
                    console.log(this.res);
                    this.SearchResult.nativeElement.classList.add("display");
                }
                else {
                    this.res = []; // TODO
                    this.SearchResult.nativeElement.classList.remove("display");
                }
                this.loading = false;
            }, error => {
                console.log("error!", error);
            });
        }
        else {
            this.SearchResult.nativeElement.classList.remove("display");
            this.res = []; // TODO
            this.loading = false;
        }
    }
};
__decorate([
    ViewChild("input"),
    __metadata("design:type", Object)
], SearchComponent.prototype, "Input", void 0);
__decorate([
    ViewChild("button"),
    __metadata("design:type", Object)
], SearchComponent.prototype, "Button", void 0);
__decorate([
    ViewChild("searchResult"),
    __metadata("design:type", Object)
], SearchComponent.prototype, "SearchResult", void 0);
__decorate([
    ViewChild("searchField"),
    __metadata("design:type", Object)
], SearchComponent.prototype, "SearchField", void 0);
SearchComponent = __decorate([
    Component({
        selector: "app-search",
        templateUrl: "./search.component.html",
        styleUrls: ["./search.component.scss"]
    }),
    __metadata("design:paramtypes", [ImageService])
], SearchComponent);
export { SearchComponent };
//# sourceMappingURL=search.component.js.map