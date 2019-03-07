var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from "@angular/core";
import { ImageService } from "../services/image.service";
import { LoggedIn } from "../classes/logged-in";
let FollowButtonComponent = class FollowButtonComponent extends LoggedIn {
    constructor(service) {
        super();
        this.service = service;
        // @Input() loggedUser: IsUserLoggedIn;
        this.idDestinateUser = 0; // TODO CHANGE FROM NULL
        this.followed = false; // TODO CHANGE FROM NULL
        // @Output() emitter: EventEmitter<any> = new EventEmitter();
        this.class = "";
    }
    ngOnInit() {
        super.ngOnInit();
        // if logged user already follows this user
        // to do
    }
    follow() {
        let data = {
            followedUserId: this.idDestinateUser,
            followingUserId: this._loggedId
        };
        this.service
            .follow(data, this._loggedId, this._loggedToken)
            .subscribe(res => {
            // console.log(res);
            // this.emitter.emit(this);
            this.followed = true;
            console.log(this.followed);
        });
    }
    unFollow() {
        let data = {
            followedUserId: this.idDestinateUser,
            followingUserId: this._loggedId
        };
        this.service
            .unfollow(data, this._loggedId, this._loggedToken)
            .subscribe(res => {
            // console.log(res);
            // this.emitter.emit(this);
            this.followed = false;
            console.log(this.followed);
        });
    }
};
__decorate([
    Input(),
    __metadata("design:type", Number)
], FollowButtonComponent.prototype, "idDestinateUser", void 0);
__decorate([
    Input(),
    __metadata("design:type", Boolean)
], FollowButtonComponent.prototype, "followed", void 0);
FollowButtonComponent = __decorate([
    Component({
        selector: "app-follow-button",
        templateUrl: "./follow-button.component.html",
        styleUrls: ["./follow-button.component.scss"]
    }),
    __metadata("design:paramtypes", [ImageService])
], FollowButtonComponent);
export { FollowButtonComponent };
//# sourceMappingURL=follow-button.component.js.map