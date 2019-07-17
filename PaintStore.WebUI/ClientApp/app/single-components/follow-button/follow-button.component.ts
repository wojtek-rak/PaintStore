import { Component, Input } from "@angular/core";
import { FollowingData } from "../../logic/classes/following-data";
import { ImageService } from "../../services/image.service";
import { LoggedIn } from "../../logic/classes/logged-in";

@Component({
  selector: "app-follow-button",
  templateUrl: "./follow-button.component.html",
  styleUrls: ["./follow-button.component.scss"]
})
export class FollowButtonComponent extends LoggedIn {
  @Input() idDestinateUser = 0;
  @Input() followed = false;
  public class = "";
  constructor(private service: ImageService) {
    super();
  }

  follow() {
    const data: FollowingData = {
      followedUserId: this.idDestinateUser,
      followingUserId: this._loggedId
    };
    this.service
      .follow(data, this._loggedId, this._loggedToken)
      .subscribe(res => {
        this.followed = true;
      });
  }

  unFollow() {
    const data: FollowingData = {
      followedUserId: this.idDestinateUser,
      followingUserId: this._loggedId
    };

    this.service
      .unfollow(data, this._loggedId, this._loggedToken)
      .subscribe(res => {
        this.followed = false;
      });
  }
}
