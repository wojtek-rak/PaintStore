import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { UserComment } from "../image/comment";
import { FollowingData } from "../classes/following-data";

@Injectable()
export class ImageService {
  private host = "http://paintstorerest.azurewebsites.net/";
  constructor(private _http: HttpClient) { }

  public selectRecentImages() {
    return this._http.get(this.host + "api/Posts/AllPosts/the_newest");
  }

  public selectPopularImages() {
    return this._http.get(this.host + "api/Posts/AllPosts/most_popular");
  }

  public selectFollowedImages(id: number) {
    return this._http.get(this.host + "api/Posts/" + id + "/GetFollowingPosts");
  }

  public ImageByPath(userId: string, postId: string) {
    return this._http.get(this.host + "api/Posts/" + userId + "/" + postId);
  }

  public CommentsByImgPath(userId: string, postId: string) {
    return this._http.get(this.host + "api/Comments/" + userId + "/" + postId);
  }

  public uploadComment(comment: any, id: number, token: string) {
    let headers = this.getHeaders(id, token);
    return this._http.post(this.host + "api/Comments/AddPostComment", comment, {
      headers: headers
    });
  }

  public removeComment(id: number, idToken: number, token: string) {
    let headers = this.getHeaders(id, token);

    return this._http.delete(
      this.host + "api/Comments/DeletePostComment/" + id,
      { headers: headers }
    );
  }

  public selectUserById(loggedUserId: string, userId: string) {
    return this._http.get(
      this.host + "api/Users/" + loggedUserId + "/" + userId
    );
  }

  public selectUserRecentImages(id: string) {
    return this._http.get(
      this.host + "api/Users/" + id + "/GetPosts/the_newest"
    );
  }

  public selectUserTrendingImages(id: string) {
    return this._http.get(
      this.host + "api/Users/" + id + "/GetPosts/most_popular"
    );
  }

  public getFollowed(loggedUserId: string, userId: string) {
    return this._http.get(
      this.host + "api/Followers/GetFollowed/" + loggedUserId + "/" + userId
    );
  }

  public getFollowing(loggedUserId: string, userId: string) {
    return this._http.get(
      this.host + "api/Followers/GetFollowing/" + loggedUserId + "/" + userId
    );
  }

  public getPostLikes(userId: string, postId: string) {
    return this._http.get(
      this.host + "api/Likes/Post/" + userId + "/" + postId
    );
  }

  private getHeaders(id: number, token: string): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.append(
      "Authorization",
      "Basic " + btoa("" + id + ":" + token)
    );
    headers = headers.append("Content-Type", "application/json");

    return headers;
  }

  public unlikePost(userId: string, postId: string, id: number, token: string) {
    let headers = this.getHeaders(id, token);

    return this._http.delete(
      this.host + "api/Likes/Post/RemoveLike/" + userId + "/" + postId,
      {
        headers: headers
      }
    );
  }

  public likePost(data: any, id: number, token: string) {
    let headers = this.getHeaders(id, token);
    return this._http.post(this.host + "api/Likes/Post/AddLike", data, {
      headers: headers
    });
  }

  public getCommentLikes(userId: string, commentId: string) {
    return this._http.get(
      this.host + "api/Likes/Comment/" + userId + "/" + commentId
    );
  }

  public likeComment(data: any, id: number, token: string) {
    let headers = this.getHeaders(id, token);

    return this._http.post(this.host + "api/Likes/Comment/AddLike", data, {
      headers: headers
    });
  }

  public unlikeComment(userId: number, postId: string, token: string) {
    let headers = this.getHeaders(userId, token);
    // console.log(postId);
    return this._http.delete(
      this.host + "api/Likes/Comment/RemoveLike/" + userId + "/" + postId,
      {
        headers: headers
      }
    );
  }

  public editComment(data: any, id: number, token: string) {
    let headers = this.getHeaders(id, token);
    return this._http.put(this.host + "api/Comments/EditPostComment", data, {
      headers: headers
    });
  }

  // followedUserId, followingUserId
  public follow(data: FollowingData, id: number, token: string) {
    let headers = this.getHeaders(id, token);

    return this._http.post(this.host + "api/Followers/AddFollower", data, {
      headers: headers
    });
  }

  // followedUserId, followingUserId
  public unfollow(data: FollowingData, id: number, token: string) {
    let headers = this.getHeaders(id, token);

    return this._http.delete(
      this.host +
      "api/Followers/DeleteFollower" +
      "/" +
      data.followingUserId +
      "/" +
      data.followedUserId,
      { headers: headers }
    );
  }

  public search(searchWord: string) {
    return this._http.get(this.host + "api/Search/" + searchWord);
  }

  public imagesByTag(tag: string) {
    return this._http.get(this.host + "api/Posts/AllPostsByTag/" + tag);
  }

  public uploadImage(data, id: number, token: string) {
    let headers = new HttpHeaders(), fileRes: FileRes = null;
    headers = headers.append(
      "Authorization",
      "Basic " + btoa("" + id + ":" + token)
    );

    let fd = new FormData();
    fd.append("file", data);

    this._http.post(this.host + "api/UploadImage", fd, {
      headers: headers
    }).subscribe(res => {
      fileRes = <FileRes>res;
      console.log(fileRes);
    });
  }

}

interface FileRes {
  caption: string
  format: string
  publicId: string
  url: string
}
