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
var TagsComponent = /** @class */ (function () {
    function TagsComponent(route, service) {
        this.route = route;
        this.service = service;
        this._tagname = "";
        this._images = [];
        this._loading = false;
    }
    TagsComponent.prototype.ngOnInit = function () {
        this._tagname = this.route.snapshot.params.id;
        this.getImages();
    };
    TagsComponent.prototype.getImages = function () {
        var _this = this;
        this._loading = true;
        this.service.imagesByTag(this._tagname).subscribe(function (res) {
            console.log(res);
            _this._images = res;
            _this._loading = false;
        });
    };
    Object.defineProperty(TagsComponent.prototype, "tagname", {
        get: function () {
            return this._tagname;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TagsComponent.prototype, "images", {
        get: function () {
            return this._images;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TagsComponent.prototype, "loading", {
        get: function () {
            return this._loading;
        },
        enumerable: true,
        configurable: true
    });
    TagsComponent = __decorate([
        Component({
            selector: "app-tags",
            templateUrl: "./tags.component.html",
            styleUrls: ["./tags.component.scss"]
        }),
        __metadata("design:paramtypes", [ActivatedRoute, ImageService])
    ], TagsComponent);
    return TagsComponent;
}());
export { TagsComponent };
//# sourceMappingURL=tags.component.js.map