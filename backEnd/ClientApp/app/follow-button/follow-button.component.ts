import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { IsUserLoggedIn } from "../classes/is-user-logged-in";
import { FollowingData } from "../classes/following-data";
import { ImageService } from "../services/image.service";
import { LoggedIn } from "../classes/logged-in";

@Component({
  selector: "app-follow-button",
  templateUrl: "./follow-button.component.html",
  styleUrls: ["./follow-button.component.scss"]
})
export class FollowButtonComponent extends LoggedIn implements OnInit {
  // @Input() loggedUser: IsUserLoggedIn;
    @Input() idDestinateUser: number = 0;// TODO CHANGE FROM NULL
    @Input() followed: boolean = false; // TODO CHANGE FROM NULL
  // @Output() emitter: EventEmitter<any> = new EventEmitter();
  public class = "";
  constructor(private service: ImageService) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
    // if logged user already follows this user
    // to do
  }

  follow() {
    let data: FollowingData = {
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
    let data: FollowingData = {
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
}
