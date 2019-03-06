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
import { ImageService } from "../services/image.service";
import { ActivatedRoute, Router } from "@angular/router";
import { LoggedIn } from "../classes/logged-in";
let HomepageComponent = class HomepageComponent extends LoggedIn {
    constructor(imgService, activatedRoute, router) {
        super();
        this.imgService = imgService;
        this.activatedRoute = activatedRoute;
        this.router = router;
        this._images = [];
        this.loading = false;
    }
    ngOnInit() {
        super.ngOnInit();
        if (this._loggedIn) {
            if (this.router.url === "/") {
                this.followedImages();
            }
            else if (this.router.url === "/trending") {
                this.popularImages();
            }
            else {
                this.recentImages();
            }
        }
        else {
            if (this.router.url === "/") {
                this.popularImages();
            }
            else {
                this.recentImages();
            }
        }
    }
    recentImages() {
        this.loading = true;
        this.imgService.selectRecentImages().subscribe(res => {
            this.loading = false;
            this._images = res;
        });
    }
    popularImages() {
        this.loading = true;
        this.imgService.selectPopularImages().subscribe(res => {
            this.loading = false;
            this._images = res;
            console.log(this._images);
        });
    }
    followedImages() {
        this.loading = true;
        this.imgService.selectFollowedImages(this._loggedId).subscribe(res => {
            this.loading = false;
            this._images = res;
        });
    }
    get images() {
        return this._images;
    }
};
HomepageComponent = __decorate([
    Component({
        selector: "app-homepage",
        templateUrl: "./homepage.component.html",
        styleUrls: ["./homepage.component.scss"]
    }),
    __metadata("design:paramtypes", [ImageService,
        ActivatedRoute,
        Router])
], HomepageComponent);
export { HomepageComponent };
//# sourceMappingURL=homepage.component.js.map