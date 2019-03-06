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
let ProfileComponent = class ProfileComponent extends LoggedIn {
    // private _loggedUser: IsUserLoggedIn = {
    //   isLoggedIn: true,
    //   userId: 1
    // };
    constructor(imageService, route) {
        super();
        this.imageService = imageService;
        this.route = route;
        this.user = {
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
        this.url = this.route.snapshot.params.id;
    }
    ngOnInit() {
        super.ngOnInit();
        this.getUserData();
    }
    getUserData() {
        this.imageService
            .selectUserById(this._loggedId.toString(), this.url)
            .subscribe(res => {
            this.user = res;
            console.log(this.user);
        });
    }
    showFollowed() {
        let informationToSend;
        this.imageService
            .getFollowed(this._loggedId.toString(), this.url)
            .subscribe(res => {
            informationToSend = res;
            this.label.show(informationToSend, "Followed by this user");
        });
    }
    showFollowing() {
        let informationToSend;
        this.imageService
            .getFollowing(this._loggedId.toString(), this.url)
            .subscribe(res => {
            informationToSend = res;
            this.label.show(informationToSend, "Following by this user");
        });
    }
    getUser() {
        return this.user;
    }
    get loggedUser() {
        return this._loggedId;
    }
    getUrl() {
        return this.url;
    }
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
    __metadata("design:paramtypes", [ImageService,
        ActivatedRoute])
], ProfileComponent);
export { ProfileComponent };
//# sourceMappingURL=profile.component.js.map