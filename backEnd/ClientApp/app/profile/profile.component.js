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
import { Component, ViewChild } from "@angular/core";
import { ImageService } from "../services/image.service";
import { ActivatedRoute } from "@angular/router";
import { LoggedIn } from "../classes/logged-in";
var ProfileComponent = /** @class */ (function (_super) {
    __extends(ProfileComponent, _super);
    // private _loggedUser: IsUserLoggedIn = {
    //   isLoggedIn: true,
    //   userId: 1
    // };
    function ProfileComponent(imageService, route) {
        var _this = _super.call(this) || this;
        _this.imageService = imageService;
        _this.route = route;
        _this.user = {
            about: "",
            accountId: 0,
            avatarImgLink: "",
            backgroundImgLink: "",
            followedCount: 0,
            followingCount: 0,
            id: 0,
            link: "",
            mostUsedCategoryToolName: "",
            name: "",
            postsCount: 0
        };
        _this.url = _this.route.snapshot.params.id;
        return _this;
    }
    ProfileComponent.prototype.ngOnInit = function () {
        _super.prototype.ngOnInit.call(this);
        this.getUserData();
    };
    ProfileComponent.prototype.getUserData = function () {
        var _this = this;
        this.imageService
            .selectUserById(this._loggedId.toString(), this.url)
            .subscribe(function (res) {
            _this.user = res;
            console.log(_this.user);
        });
    };
    ProfileComponent.prototype.showFollowed = function () {
        var _this = this;
        var informationToSend;
        this.imageService
            .getFollowed(this._loggedId.toString(), this.url)
            .subscribe(function (res) {
            informationToSend = res;
            _this.label.show(informationToSend, "Followed by this user");
        });
    };
    ProfileComponent.prototype.showFollowing = function () {
        var _this = this;
        var informationToSend;
        this.imageService
            .getFollowing(this._loggedId.toString(), this.url)
            .subscribe(function (res) {
            informationToSend = res;
            _this.label.show(informationToSend, "Following by this user");
        });
    };
    ProfileComponent.prototype.getUser = function () {
        return this.user;
    };
    Object.defineProperty(ProfileComponent.prototype, "loggedUser", {
        get: function () {
            return this._loggedId;
        },
        enumerable: true,
        configurable: true
    });
    ProfileComponent.prototype.getUrl = function () {
        return this.url;
    };
    __decorate([
        ViewChild("label"),
        __metadata("design:type", Object)
    ], ProfileComponent.prototype, "label", void 0);
    ProfileComponent = __decorate([
        Component({
            selector: "app-profile",
            templateUrl: "./profile.component.html",
            styleUrls: ["./profile.component.scss"]
        }),
        __metadata("design:paramtypes", [ImageService, typeof (_a = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" && _a || Object])
    ], ProfileComponent);
    return ProfileComponent;
    var _a;
}(LoggedIn));
export { ProfileComponent };
//# sourceMappingURL=profile.component.js.map