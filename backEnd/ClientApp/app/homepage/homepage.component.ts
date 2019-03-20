import { Component, OnInit, ViewChild } from "@angular/core";
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
  @ViewChild("imagesComponent") imgComp;

  constructor(
    private imgService: ImageService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    console.log("change");
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
    this.imgComp.showLoadingMsg();
    this.imgService.selectRecentImages().subscribe(
      res => {
        this.imgComp.hideLoadingMsg();
        this._images = <Image[]>res;
        this.imgComp.images = this._images;
      },
      err => {
        this.imgComp.showErrorMsg();
      }
    );
  }

  popularImages() {
    this.imgComp.showLoadingMsg();
    this.imgService.selectPopularImages().subscribe(
      res => {
        this.imgComp.hideLoadingMsg();
        this._images = <Image[]>res;
        this.imgComp.images = this._images;
      },
      err => {
        this.imgComp.showErrorMsg();
      }
    );
  }

  followedImages() {
    this.imgComp.showLoadingMsg();
    this.imgService.selectFollowedImages(this._loggedId).subscribe(
      res => {
        this.imgComp.hideLoadingMsg();
        this._images = <Image[]>res;
        this.imgComp.images = this._images;
      },
      err => {
        this.imgComp.showErrorMsg();
      }
    );
  }

  get images(): Array<Image> {
    return this._images;
  }
}
