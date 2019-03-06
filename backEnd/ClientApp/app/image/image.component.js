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
import { LoginManager } from "../classes/login-manager";
var ImageComponent = /** @class */ (function (_super) {
    __extends(ImageComponent, _super);
    function ImageComponent(service, route) {
        var _this = _super.call(this) || this;
        _this.service = service;
        _this.route = route;
        _this._image = {
            commentsCount: 0,
            creationDate: "",
            description: "",
            id: 0,
            imgLink: "",
            likeCount: 0,
            tagsList: [],
            title: "",
            userId: 0,
            userOwnerImgLink: "",
            userOwnerName: "",
            liked: false
        };
        _this.formValid = true;
        _this._loading = false;
        _this.commentIdToRemove = null;
        return _this;
    }
    ImageComponent.prototype.ngOnInit = function () {
        _super.prototype.ngOnInit.call(this);
        console.log(this.loggedIn, LoginManager.userLoggedIn());
        this.getCommentsData();
        this.getImageData();
    };
    ImageComponent.prototype.getImageData = function () {
        var _this = this;
        this.service
            .ImageByPath(this._loggedId.toString(), this.route.snapshot.params.id)
            .subscribe(function (res) {
            _this._image = res;
            // console.log(res);
        });
    };
    ImageComponent.prototype.getCommentsData = function () {
        var _this = this;
        this.service
            .CommentsByImgPath(this._loggedId.toString(), this.route.snapshot.params.id)
            .subscribe(function (res) {
            _this._comments = res;
            _this._comments.forEach(function (comm) {
                comm.isEditing = false;
                comm.editValid = true;
            });
            // console.log(this._comments);
        });
    };
    ImageComponent.prototype.isCommentValid = function (text) {
        if (text === null)
            return false;
        if (typeof text === undefined)
            return false;
        if (text === "")
            return false;
        if (typeof text.length === undefined || text.length < 5)
            return false;
        return true;
    };
    ImageComponent.prototype.onCommentUpload = function (form) {
        var _this = this;
        if (!this.isCommentValid(form.value.text)) {
            // if comment is null
            this.formValid = false;
        }
        else {
            this._loading = true;
            var comment = {
                PostId: this.route.snapshot.params.id,
                UserId: this._loggedId,
                Content: form.value.text,
                LikeCount: 0
            };
            // send message
            this.service
                .uploadComment(comment, this._loggedId, this._loggedToken)
                .subscribe(function (res) {
                _this.Message.show("Comment uploaded succesfully.");
                _this.formValid = true;
                _this._loading = false;
                _this.getCommentsData();
            });
            form.resetForm();
        }
    };
    ImageComponent.prototype.confirm = function () {
        var _this = this;
        this.service
            .removeComment(this.commentIdToRemove, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            _this.getCommentsData();
            _this.Message.show("Comment deleted succesfully.");
        });
    };
    ImageComponent.prototype.photoLike = function () {
        this._image.likeCount += 1;
        this._image.liked = true;
        this.service
            .likePost({
            userId: this._loggedId,
            postId: this.route.snapshot.params.id
        }, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            // console.log(res);
        });
    };
    ImageComponent.prototype.photoUnlike = function () {
        this._image.likeCount -= 1;
        this._image.liked = false;
        this.service
            .unlikePost(this._loggedId.toString(), this.route.snapshot.params.id, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            // console.log(res);
        });
    };
    ImageComponent.prototype.showLiking = function () {
        var _this = this;
        var informationToSend;
        this.service
            .getPostLikes(this._loggedId.toString(), this.route.snapshot.params.id)
            .subscribe(function (res) {
            console.log("polubili ten post:\n", res);
            informationToSend = res;
            _this.label.show(informationToSend, "Liked this image");
        });
    };
    ImageComponent.prototype.commentShowLiked = function (id) {
        var _this = this;
        var informationToSend;
        this.service
            .getCommentLikes(this._loggedId.toString(), id.toString())
            .subscribe(function (res) {
            informationToSend = res;
            _this.label.show(informationToSend, "Liked this comment");
        });
    };
    ImageComponent.prototype.commentLike = function (comment) {
        comment.liked = true;
        comment.likeCount += 1;
        this.service
            .likeComment({
            userId: this._loggedId,
            commentId: comment.id
        }, this._loggedId, this._loggedToken)
            .subscribe(function (res) {
            // console.log(res);
        });
    };
    ImageComponent.prototype.commentUnlike = function (comment) {
        comment.liked = false;
        comment.likeCount -= 1;
        this.service
            .unlikeComment(this._loggedId, comment.id, this._loggedToken)
            .subscribe(function (res) {
            // console.log(res);
        });
    };
    ImageComponent.prototype.removeComment = function (id) {
        this.commentIdToRemove = id;
        this.confirmLabel.show();
    };
    ImageComponent.prototype.editComment = function (comment) {
        comment.isEditing = true;
    };
    ImageComponent.prototype.sendEditComment = function (form, comment) {
        var _this = this;
        var text = form.form.value.value;
        if (this.isCommentValid(text)) {
            comment.editValid = true;
            var data = {
                id: comment.id,
                content: text
            };
            this.service
                .editComment(data, this._loggedId, this._loggedToken)
                .subscribe(function (res) {
                _this.Message.show("Comment edited succesfully.", res);
                comment.isEditing = false;
                comment.edited = true;
                comment.content = text;
            });
        }
        else {
            comment.editValid = false;
        }
    };
    ImageComponent.prototype.discard = function (comment) {
        comment.isEditing = false;
        comment.editValid = true;
    };
    Object.defineProperty(ImageComponent.prototype, "image", {
        get: function () {
            return this._image;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ImageComponent.prototype, "comments", {
        get: function () {
            return this._comments;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ImageComponent.prototype, "loading", {
        get: function () {
            return this._loading;
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        ViewChild("msg"),
        __metadata("design:type", Object)
    ], ImageComponent.prototype, "Message", void 0);
    __decorate([
        ViewChild("msgDelete"),
        __metadata("design:type", Object)
    ], ImageComponent.prototype, "msgDelete", void 0);
    __decorate([
        ViewChild("confirmLabel"),
        __metadata("design:type", Object)
    ], ImageComponent.prototype, "confirmLabel", void 0);
    __decorate([
        ViewChild("label"),
        __metadata("design:type", Object)
    ], ImageComponent.prototype, "label", void 0);
    ImageComponent = __decorate([
        Component({
            selector: "app-image",
            templateUrl: "./image.component.html",
            styleUrls: ["./image.component.scss"]
        }),
        __metadata("design:paramtypes", [ImageService, typeof (_a = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" && _a || Object])
    ], ImageComponent);
    return ImageComponent;
    var _a;
}(LoggedIn));
export { ImageComponent };
//# sourceMappingURL=image.component.js.map