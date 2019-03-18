import { Component, OnInit, ViewChild } from "@angular/core";
import { ImageService } from "../services/image.service";
import { ActivatedRoute } from "@angular/router";
import { ShortUserInfo } from "../classes/short-user-info";
import { IsUserLoggedIn } from "../classes/is-user-logged-in";
import { LoggedIn } from "../classes/logged-in";
import { User } from "../classes/user";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.scss"]
})
export class ProfileComponent extends LoggedIn implements OnInit {
  @ViewChild("label") label: any;
  @ViewChild("link") link: any;
  private user = new User();

  private url: string = this.route.snapshot.params.id;
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

    this.route.params.subscribe(params => {
      this.getUserData();
      this.link.nativeElement.classList.add("activeLi");
      console.log(this.link.nativeElement.classList);
    });
  }

  getUserData() {
    this.imageService
      .selectUserById(this._loggedId.toString(), this.route.snapshot.params.id)
      .subscribe(res => {
        this.user = <User>res;
        console.log(this.user);
      });
  }

  showFollowed() {
    let informationToSend: ShortUserInfo[];
    this.imageService
      .getFollowed(this._loggedId.toString(), this.route.snapshot.params.id)
      .subscribe(res => {
        informationToSend = <ShortUserInfo[]>res;
        this.label.show(informationToSend, "Followed by this user");
      });
  }

  showFollowing() {
    let informationToSend: ShortUserInfo[];
    this.imageService
      .getFollowing(this._loggedId.toString(), this.route.snapshot.params.id)
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
    return this.route.snapshot.params.id;
  }
}
