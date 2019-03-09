import { Component, OnInit } from "@angular/core";
import { ImageService } from "../services/image.service";
import * as $ from "jquery";
import { ActivatedRoute, Router } from "@angular/router";
import { LoggedIn } from "../classes/logged-in";

@Component({
  selector: "app-homepage",
  templateUrl: "./homepage.component.html",
  styleUrls: ["./homepage.component.scss"]
})
export class HomepageComponent extends LoggedIn implements OnInit {
  private _images: Image[] = [];
  loading: boolean = false;

  constructor(
    private imgService: ImageService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
    if (this._loggedIn) {
      if (this.router.url === "/") {
        this.followedImages();
      } else if (this.router.url === "/trending") {
        this.popularImages();
      } else {
        this.recentImages();
      }
    } else {
      if (this.router.url === "/") {
        this.popularImages();
      } else {
        this.recentImages();
      }
    }
  }

  recentImages() {
    this.loading = true;
    this.imgService.selectRecentImages().subscribe(res => {
      this.loading = false;
      this._images = <Image[]>res;
    });
  }

  popularImages() {
    this.loading = true;
    this.imgService.selectPopularImages().subscribe(res => {
      this.loading = false;
      this._images = <Image[]>res;
      console.log(this._images);
    });
  }

  followedImages() {
    this.loading = true;
    this.imgService.selectFollowedImages(this._loggedId).subscribe(res => {
      this.loading = false;
      this._images = <Image[]>res;
    });
  }

  get images(): Array<Image> {
    return this._images;
  }
}

interface Image {
  id: number;
  userId: number;
  userOwnerName: string;
  userOwnerImgLink: string;
  title: string;
  imgLink: string;
  likeCount: number;
  viewCount: number;
  commentsCount: number;
}
