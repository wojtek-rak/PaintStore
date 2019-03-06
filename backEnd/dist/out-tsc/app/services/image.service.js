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
let ImageService = class ImageService {
    constructor(_http) {
        this._http = _http;
        this.host = "http://paintstorerest.azurewebsites.net/";
    }
    selectRecentImages() {
        return this._http.get(this.host + "api/Posts/AllPosts/the_newest");
    }
    selectPopularImages() {
        return this._http.get(this.host + "api/Posts/AllPosts/most_popular");
    }
    selectFollowedImages(id) {
        return this._http.get(this.host + "api/Posts/" + id + "/GetFollowingPosts");
    }
    ImageByPath(userId, postId) {
        return this._http.get(this.host + "api/Posts/" + userId + "/" + postId);
    }
    CommentsByImgPath(userId, postId) {
        return this._http.get(this.host + "api/Comments/" + userId + "/" + postId);
    }
    uploadComment(comment, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Comments/AddPostComment", comment, {
            headers: headers
        });
    }
    removeComment(id, idToken, token) {
        let headers = this.getHeaders(id, token);
        return this._http.delete(this.host + "api/Comments/DeletePostComment/" + id, { headers: headers });
    }
    selectUserById(loggedUserId, userId) {
        return this._http.get(this.host + "api/Users/" + loggedUserId + "/" + userId);
    }
    selectUserRecentImages(id) {
        return this._http.get(this.host + "api/Users/" + id + "/GetPosts/the_newest");
    }
    selectUserTrendingImages(id) {
        return this._http.get(this.host + "api/Users/" + id + "/GetPosts/most_popular");
    }
    getFollowed(loggedUserId, userId) {
        return this._http.get(this.host + "api/Followers/GetFollowed/" + loggedUserId + "/" + userId);
    }
    getFollowing(loggedUserId, userId) {
        return this._http.get(this.host + "api/Followers/GetFollowing/" + loggedUserId + "/" + userId);
    }
    getPostLikes(userId, postId) {
        return this._http.get(this.host + "api/Likes/Post/" + userId + "/" + postId);
    }
    getHeaders(id, token) {
        let headers = new HttpHeaders();
        headers = headers.append("Authorization", "Basic " + btoa("" + id + ":" + token));
        headers = headers.append("Content-Type", "application/json");
        return headers;
    }
    unlikePost(userId, postId, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.delete(this.host + "api/Likes/Post/RemoveLike/" + userId + "/" + postId, {
            headers: headers
        });
    }
    likePost(data, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Likes/Post/AddLike", data, {
            headers: headers
        });
    }
    getCommentLikes(userId, commentId) {
        return this._http.get(this.host + "api/Likes/Comment/" + userId + "/" + commentId);
    }
    likeComment(data, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Likes/Comment/AddLike", data, {
            headers: headers
        });
    }
    unlikeComment(userId, postId, token) {
        let headers = this.getHeaders(userId, token);
        // console.log(postId);
        return this._http.delete(this.host + "api/Likes/Comment/RemoveLike/" + userId + "/" + postId, {
            headers: headers
        });
    }
    editComment(data, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.put(this.host + "api/Comments/EditPostComment", data, {
            headers: headers
        });
    }
    // followedUserId, followingUserId
    follow(data, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.post(this.host + "api/Followers/AddFollower", data, {
            headers: headers
        });
    }
    // followedUserId, followingUserId
    unfollow(data, id, token) {
        let headers = this.getHeaders(id, token);
        return this._http.delete(this.host +
            "api/Followers/DeleteFollower" +
            "/" +
            data.followingUserId +
            "/" +
            data.followedUserId, { headers: headers });
    }
    search(searchWord) {
        return this._http.get(this.host + "api/Search/" + searchWord);
    }
    imagesByTag(tag) {
        return this._http.get(this.host + "api/Posts/AllPostsByTag/" + tag);
    }
    uploadImage(data, id, token) {
        let headers = new HttpHeaders(), fileRes = null; // TODO GRUBO
        headers = headers.append("Authorization", "Basic " + btoa("" + id + ":" + token));
        let fd = new FormData();
        fd.append("file", data);
        this._http.post(this.host + "api/UploadImage", fd, {
            headers: headers
        }).subscribe(res => {
            fileRes = res;
            console.log(fileRes);
        });
    }
};
ImageService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [HttpClient])
], ImageService);
export { ImageService };
//# sourceMappingURL=image.service.js.map