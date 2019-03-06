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
import { Component, Input } from "@angular/core";
import { ImageService } from "../services/image.service";
import { LoggedIn } from "../classes/logged-in";
var FollowButtonComponent = /** @class */ (function (_super) {
    __extends(FollowButtonComponent, _super);
    function FollowButtonComponent(service) {
        var _this = _super.call(this) || this;
        _this.service = service;
        // @Input() loggedUser: IsUserLoggedIn;
        _this.idDestinateUser = 0; // TODO CHANGE FROM NULL
        _this.followed = false; // TODO CHANGE FROM NULL
        // @Output() emitter: EventEmitter<any> = new EventEmitter();
        _this.class = "";
        return _this;
    }
    FollowButtonComponent.prototype.ngOnInit = function () {
        _super.prototype.ngOnInit.call(this);
        // if logged user already follows this user
        // to do
    };
    FollowButtonComponent.prototype.follow = function () {
        var _this = this;
        var data = {
            followedUserId: this.idDestinateUser,
            followingUserId: this._loggedId
        };
        this.service
            .follow(data, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            // console.log(res);
            // this.emitter.emit(this);
            _this.followed = true;
            console.log(_this.followed);
        });
    };
    FollowButtonComponent.prototype.unFollow = function () {
        var _this = this;
        var data = {
            followedUserId: this.idDestinateUser,
            followingUserId: this._loggedId
        };
        this.service
            .unfollow(data, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            // console.log(res);
            // this.emitter.emit(this);
            _this.followed = false;
            console.log(_this.followed);
        });
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
    return FollowButtonComponent;
}(LoggedIn));
export { FollowButtonComponent };
//# sourceMappingURL=follow-button.component.js.map