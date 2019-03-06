var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ImageService } from "../services/image.service";
let TagsComponent = class TagsComponent {
    constructor(route, service) {
        this.route = route;
        this.service = service;
        this._tagname = "";
        this._images = [];
        this._loading = false;
    }
    ngOnInit() {
        this._tagname = this.route.snapshot.params.id;
        this.getImages();
    }
    getImages() {
        this._loading = true;
        this.service.imagesByTag(this._tagname).subscribe(res => {
            console.log(res);
            this._images = res;
            this._loading = false;
        });
    }
    get tagname() {
        return this._tagname;
    }
    get images() {
        return this._images;
    }
    get loading() {
        return this._loading;
    }
};
TagsComponent = __decorate([
    Component({
        selector: "app-tags",
        templateUrl: "./tags.component.html",
        styleUrls: ["./tags.component.scss"]
    }),
    __metadata("design:paramtypes", [ActivatedRoute, ImageService])
], TagsComponent);
export { TagsComponent };
//# sourceMappingURL=tags.component.js.map