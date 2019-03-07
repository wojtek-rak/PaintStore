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
let ImagesComponent = class ImagesComponent {
    // private id = this.route.parent.snapshot.paramMap.get("id");
    // private path = this.route.snapshot.routeConfig.path;
    constructor(imageService, route) {
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
    ngOnInit() {
        this.getData();
    }
    getData() {
        if (this.route.snapshot.routeConfig === null)
            return;
        if (this.route.parent === null)
            return;
        let path = this.route.snapshot.routeConfig.path;
        let id = this.route.parent.snapshot.paramMap.get("id");
        if (id === null)
            return;
        this.loading = true;
        if (path === this.selectedRoutes.recent) {
            this.imageService.selectUserTrendingImages(id).subscribe(res => {
                this._images = res;
                this.loading = false;
            });
        }
        else {
            this.imageService.selectUserRecentImages(id).subscribe(res => {
                this._images = res;
                this.loading = false;
            });
        }
    }
    get images() {
        return this._images;
    }
};
ImagesComponent = __decorate([
    Component({
        selector: "app-images",
        templateUrl: "./images.component.html",
        styleUrls: ["./images.component.scss"]
    }),
    __metadata("design:paramtypes", [ImageService,
        ActivatedRoute])
], ImagesComponent);
export { ImagesComponent };
//# sourceMappingURL=images.component.js.map