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
let ImageComponent = class ImageComponent extends LoggedIn {
    constructor(service, route) {
        super();
        this.service = service;
        this.route = route;
        this._image = {
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
        this._comments = [];
        this.formValid = true;
        this._loading = false;
        this.commentIdToRemove = 0; // TODO sprawdz czy sie nie wyjebalo
    }
    ngOnInit() {
        super.ngOnInit();
        console.log(this.loggedIn, LoginManager.userLoggedIn());
        this.getCommentsData();
        this.getImageData();
    }
    getImageData() {
        this.service
            .ImageByPath(this._loggedId.toString(), this.route.snapshot.params.id)
            .subscribe(res => {
            this._image = res;
            // console.log(res);
        });
    }
    getCommentsData() {
        this.service
            .CommentsByImgPath(this._loggedId.toString(), this.route.snapshot.params.id)
            .subscribe(res => {
            this._comments = res;
            this._comments.forEach(comm => {
                comm.isEditing = false;
                comm.editValid = true;
            });
            // console.log(this._comments);
        });
    }
    isCommentValid(text) {
        if (text === null)
            return false;
        if (typeof text === undefined)
            return false;
        if (text === "")
            return false;
        if (typeof text.length === undefined || text.length < 5)
            return false;
        return true;
    }
    onCommentUpload(form) {
        if (!this.isCommentValid(form.value.text)) {
            // if comment is null
            this.formValid = false;
        }
        else {
            this._loading = true;
            const comment = {
                PostId: this.route.snapshot.params.id,
                UserId: this._loggedId,
                Content: form.value.text,
                LikeCount: 0
            };
            // send message
            this.service
                .uploadComment(comment, this._loggedId, this._loggedToken)
                .subscribe(res => {
                this.Message.show("Comment uploaded succesfully.");
                this.formValid = true;
                this._loading = false;
                this.getCommentsData();
            });
            form.resetForm();
        }
    }
    confirm() {
        this.service
            .removeComment(this.commentIdToRemove, this._loggedId, this._loggedToken)
            .subscribe((res) => {
            this.getCommentsData();
            this.Message.show("Comment deleted succesfully.");
        });
    }
    photoLike() {
        this._image.likeCount += 1;
        this._image.liked = true;
        this.service
            .likePost({
            userId: this._loggedId,
            postId: this.route.snapshot.params.id
        }, this._loggedId, this._loggedToken)
            .subscribe(res => {
            // console.log(res);
        });
    }
    photoUnlike() {
        this._image.likeCount -= 1;
        this._image.liked = false;
        this.service
            .unlikePost(this._loggedId.toString(), this.route.snapshot.params.id, this._loggedId, this._loggedToken)
            .subscribe(res => {
            // console.log(res);
        });
    }
    showLiking() {
        let informationToSend;
        this.service
            .getPostLikes(this._loggedId.toString(), this.route.snapshot.params.id)
            .subscribe(res => {
            console.log("polubili ten post:\n", res);
            informationToSend = res;
            this.label.show(informationToSend, "Liked this image");
        });
    }
    commentShowLiked(id) {
        let informationToSend;
        this.service
            .getCommentLikes(this._loggedId.toString(), id.toString())
            .subscribe(res => {
            informationToSend = res;
            this.label.show(informationToSend, "Liked this comment");
        });
    }
    commentLike(comment) {
        comment.liked = true;
        comment.likeCount += 1;
        this.service
            .likeComment({
            userId: this._loggedId,
            commentId: comment.id
        }, this._loggedId, this._loggedToken)
            .subscribe(res => {
            // console.log(res);
        });
    }
    commentUnlike(comment) {
        comment.liked = false;
        comment.likeCount -= 1;
        this.service
            .unlikeComment(this._loggedId, comment.id, this._loggedToken)
            .subscribe(res => {
            // console.log(res);
        });
    }
    removeComment(id) {
        this.commentIdToRemove = id;
        this.confirmLabel.show();
    }
    editComment(comment) {
        comment.isEditing = true;
    }
    sendEditComment(form, comment) {
        let text = form.form.value.value;
        if (this.isCommentValid(text)) {
            comment.editValid = true;
            let data = {
                id: comment.id,
                content: text
            };
            this.service
                .editComment(data, this._loggedId, this._loggedToken)
                .subscribe(res => {
                this.Message.show("Comment edited succesfully.", res);
                comment.isEditing = false;
                comment.edited = true;
                comment.content = text;
            });
        }
        else {
            comment.editValid = false;
        }
    }
    discard(comment) {
        comment.isEditing = false;
        comment.editValid = true;
    }
    get image() {
        return this._image;
    }
    get comments() {
        return this._comments;
    }
    get loading() {
        return this._loading;
    }
};
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
    __metadata("design:paramtypes", [ImageService, ActivatedRoute])
], ImageComponent);
export { ImageComponent };
//# sourceMappingURL=image.component.js.map