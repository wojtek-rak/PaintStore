var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
var ImageService = /** @class */ (function () {
    function ImageService(_http) {
        this._http = _http;
        this.host = "http://paintstorerest.azurewebsites.net/";
    }
    ImageService.prototype.selectRecentImages = function () {
        return this._http.get(this.host + "api/Posts/AllPosts/the_newest");
    };
    ImageService.prototype.selectPopularImages = function () {
        return this._http.get(this.host + "api/Posts/AllPosts/most_popular");
    };
    ImageService.prototype.selectFollowedImages = function (id) {
        return this._http.get(this.host + "api/Posts/" + id + "/GetFollowingPosts");
    };
    ImageService.prototype.ImageByPath = function (userId, postId) {
        return this._http.get(this.host + "api/Posts/" + userId + "/" + postId);
    };
    ImageService.prototype.CommentsByImgPath = function (userId, postId) {
        return this._http.get(this.host + "api/Comments/" + userId + "/" + postId);
    };
    ImageService.prototype.uploadComment = function (comment, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Comments/AddPostComment", comment, {
            headers: headers
        });
    };
    ImageService.prototype.removeComment = function (id, idToken, token) {
        var headers = this.getHeaders(id, token);
        return this._http.delete(this.host + "api/Comments/DeletePostComment/" + id, { headers: headers });
    };
    ImageService.prototype.selectUserById = function (loggedUserId, userId) {
        return this._http.get(this.host + "api/Users/" + loggedUserId + "/" + userId);
    };
    ImageService.prototype.selectUserRecentImages = function (id) {
        return this._http.get(this.host + "api/Users/" + id + "/GetPosts/the_newest");
    };
    ImageService.prototype.selectUserTrendingImages = function (id) {
        return this._http.get(this.host + "api/Users/" + id + "/GetPosts/most_popular");
    };
    ImageService.prototype.getFollowed = function (loggedUserId, userId) {
        return this._http.get(this.host + "api/Followers/GetFollowed/" + loggedUserId + "/" + userId);
    };
    ImageService.prototype.getFollowing = function (loggedUserId, userId) {
        return this._http.get(this.host + "api/Followers/GetFollowing/" + loggedUserId + "/" + userId);
    };
    ImageService.prototype.getPostLikes = function (userId, postId) {
        return this._http.get(this.host + "api/Likes/Post/" + userId + "/" + postId);
    };
    ImageService.prototype.getHeaders = function (id, token) {
        var headers = new HttpHeaders();
        headers = headers.append("Authorization", "Basic " + btoa("" + id + ":" + token));
        headers = headers.append("Content-Type", "application/json");
        return headers;
    };
    ImageService.prototype.unlikePost = function (userId, postId, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.delete(this.host + "api/Likes/Post/RemoveLike/" + userId + "/" + postId, {
            headers: headers
        });
    };
    ImageService.prototype.likePost = function (data, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Likes/Post/AddLike", data, {
            headers: headers
        });
    };
    ImageService.prototype.getCommentLikes = function (userId, commentId) {
        return this._http.get(this.host + "api/Likes/Comment/" + userId + "/" + commentId);
    };
    ImageService.prototype.likeComment = function (data, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Likes/Comment/AddLike", data, {
            headers: headers
        });
    };
    ImageService.prototype.unlikeComment = function (userId, postId, token) {
        var headers = this.getHeaders(userId, token);
        // console.log(postId);
        return this._http.delete(this.host + "api/Likes/Comment/RemoveLike/" + userId + "/" + postId, {
            headers: headers
        });
    };
    ImageService.prototype.editComment = function (data, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.put(this.host + "api/Comments/EditPostComment", data, {
            headers: headers
        });
    };
    // followedUserId, followingUserId
    ImageService.prototype.follow = function (data, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Followers/AddFollower", data, {
            headers: headers
        });
    };
    // followedUserId, followingUserId
    ImageService.prototype.unfollow = function (data, id, token) {
        var headers = this.getHeaders(id, token);
        return this._http.delete(this.host +
            "api/Followers/DeleteFollower" +
            "/" +
            data.followingUserId +
            "/" +
            data.followedUserId, { headers: headers });
    };
    ImageService.prototype.search = function (searchWord) {
        return this._http.get(this.host + "api/Search/" + searchWord);
    };
    ImageService.prototype.imagesByTag = function (tag) {
        return this._http.get(this.host + "api/Posts/AllPostsByTag/" + tag);
    };
    ImageService.prototype.uploadImage = function (data, id, token) {
        var headers = new HttpHeaders(), fileRes = null;
        headers = headers.append("Authorization", "Basic " + btoa("" + id + ":" + token));
        var fd = new FormData();
        fd.append("file", data);
        this._http.post(this.host + "api/UploadImage", fd, {
            headers: headers
        }).subscribe(function (res) {
            fileRes = res;
            console.log(fileRes);
        });
    };
    ImageService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], ImageService);
    return ImageService;
}());
export { ImageService };
//# sourceMappingURL=image.service.js.map