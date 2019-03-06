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
var ImagesComponent = /** @class */ (function () {
    // private id = this.route.parent.snapshot.paramMap.get("id");
    // private path = this.route.snapshot.routeConfig.path;
    function ImagesComponent(imageService, route) {
        this.imageService = imageService;
        this.route = route;
        this.selectedRoutes = {
            recent: "recent",
            trending: ""
            // followed: "followed"
        };
        this.loading = false;
        this._images = [];
    }
    ImagesComponent.prototype.ngOnInit = function () {
        this.getData();
    };
    ImagesComponent.prototype.getData = function () {
        var _this = this;
        if (this.route.snapshot.routeConfig === null)
            return;
        if (this.route.parent === null)
            return;
        var path = this.route.snapshot.routeConfig.path;
        var id = this.route.parent.snapshot.paramMap.get("id");
        if (id === null)
            return;
        this.loading = true;
        if (path === this.selectedRoutes.recent) {
            this.imageService.selectUserTrendingImages(id).subscribe(function (res) {
                _this._images = res;
                _this.loading = false;
            });
        }
        else {
            this.imageService.selectUserRecentImages(id).subscribe(function (res) {
                _this._images = res;
                _this.loading = false;
            });
        }
    };
    Object.defineProperty(ImagesComponent.prototype, "images", {
        get: function () {
            return this._images;
        },
        enumerable: true,
        configurable: true
    });
    ImagesComponent = __decorate([
        Component({
            selector: "app-images",
            templateUrl: "./images.component.html",
            styleUrls: ["./images.component.scss"]
        }),
        __metadata("design:paramtypes", [ImageService,
            ActivatedRoute])
    ], ImagesComponent);
    return ImagesComponent;
}());
export { ImagesComponent };
//# sourceMappingURL=images.component.js.map