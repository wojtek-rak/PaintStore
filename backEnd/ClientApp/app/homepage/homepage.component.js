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
import { Component } from "@angular/core";
import { ImageService } from "../services/image.service";
import { ActivatedRoute, Router } from "@angular/router";
import { LoggedIn } from "../classes/logged-in";
var HomepageComponent = /** @class */ (function (_super) {
    __extends(HomepageComponent, _super);
    function HomepageComponent(imgService, activatedRoute, router) {
        var _this = _super.call(this) || this;
        _this.imgService = imgService;
        _this.activatedRoute = activatedRoute;
        _this.router = router;
        _this.loading = false;
        return _this;
    }
    HomepageComponent.prototype.ngOnInit = function () {
        _super.prototype.ngOnInit.call(this);
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
    };
    HomepageComponent.prototype.recentImages = function () {
        var _this = this;
        this.loading = true;
        this.imgService.selectRecentImages().subscribe(function (res) {
            _this.loading = false;
            _this._images = res;
        });
    };
    HomepageComponent.prototype.popularImages = function () {
        var _this = this;
        this.loading = true;
        this.imgService.selectPopularImages().subscribe(function (res) {
            _this.loading = false;
            _this._images = res;
            console.log(_this._images);
        });
    };
    HomepageComponent.prototype.followedImages = function () {
        var _this = this;
        this.loading = true;
        this.imgService.selectFollowedImages(this._loggedId).subscribe(function (res) {
            _this.loading = false;
            _this._images = res;
        });
    };
    Object.defineProperty(HomepageComponent.prototype, "images", {
        get: function () {
            return this._images;
        },
        enumerable: true,
        configurable: true
    });
    HomepageComponent = __decorate([
        Component({
            selector: "app-homepage",
            templateUrl: "./homepage.component.html",
            styleUrls: ["./homepage.component.scss"]
        }),
        __metadata("design:paramtypes", [ImageService, typeof (_a = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" && _a || Object, typeof (_b = typeof Router !== "undefined" && Router) === "function" && _b || Object])
    ], HomepageComponent);
    return HomepageComponent;
    var _a, _b;
}(LoggedIn));
export { HomepageComponent };
//# sourceMappingURL=homepage.component.js.map