import { Component, OnInit, ViewChild } from "@angular/core";
import { ImageService } from "../services/image.service";
import { ActivatedRoute } from "@angular/router";
import { ShortUserInfo } from "../classes/short-user-info";
import { IsUserLoggedIn } from "../classes/is-user-logged-in";
import { LoggedIn } from "../classes/logged-in";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.scss"]
})
export class ProfileComponent extends LoggedIn implements OnInit {
  @ViewChild("label") label;
  private user: User = {
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
  private url = this.route.snapshot.params.id;
  // private _loggedUser: IsUserLoggedIn = {
  //   isLoggedIn: true,
  //   userId: 1
  // };

  constructor(
    private imageService: ImageService,
    private route: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
    this.getUserData();
  }

  getUserData() {
    this.imageService
      .selectUserById(this._loggedId.toString(), this.url)
      .subscribe(res => {
        this.user = <User>res;
        console.log(this.user);
      });
  }

  showFollowed() {
    let informationToSend: ShortUserInfo[];
    this.imageService
      .getFollowed(this._loggedId.toString(), this.url)
      .subscribe(res => {
        informationToSend = <ShortUserInfo[]>res;
        this.label.show(informationToSend, "Followed by this user");
      });
  }

  showFollowing() {
    let informationToSend: ShortUserInfo[];
    this.imageService
      .getFollowing(this._loggedId.toString(), this.url)
      .subscribe(res => {
        informationToSend = <ShortUserInfo[]>res;
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
}

interface User {
  about: string;
  accountId: number;
  avatarImgLink: string;
  backgroundImgLink: string;
  followedCount: number;
  followingCount: number;
  id: number;
  link: string;
  mostUsedCategoryToolName: string;
  name: string;
  postsCount: number;
}
