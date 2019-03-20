import { Component, OnInit, Input, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ImageService } from "../services/image.service";

@Component({
  selector: "app-images",
  templateUrl: "./images.component.html",
  styleUrls: ["./images.component.scss"]
})
export class ImagesComponent implements OnInit {
  @ViewChild("imagesComponent") imgComp;
  private selectedRoutes = {
    recent: "recent",
    trending: ""
    // followed: "followed"
  };

  private _images: Image[] = [];
  private wasAlreadyChanged = false; // says if route was changed and getData called

  constructor(
    private imageService: ImageService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.getData();

    this.route.params.subscribe(() => {
      this.getData();
    });
  }

  getData() {
    if (this.route.snapshot.routeConfig === null) {
      return;
    }
    if (this.route.parent === null) {
      return;
    }

    const path = this.route.snapshot.routeConfig.path;
    const id = this.route.parent.snapshot.paramMap.get("id");

    if (id === null) {
      return;
    }

    const el = document.getElementsByClassName("firstLink")[0];

    if (
      path === this.selectedRoutes.trending &&
      !el.classList.contains("activeLi")
    ) {
      el.classList.add("activeLi");
    } else if (
      path !== this.selectedRoutes.trending &&
      el.classList.contains("activeLi")
    ) {
      el.classList.remove("activeLi");
    }

    this.imgComp.showLoadingMsg();
    if (path === this.selectedRoutes.recent) {
      this.imageService.selectUserTrendingImages(id).subscribe(
        res => {
          this._images = <Image[]>res;
          this.imgComp.hideLoadingMsg();
          this.imgComp.images = this._images;
        },
        err => {
          this.imgComp.showErrorMsg();
        }
      );
    } else {
      this.imageService.selectUserRecentImages(id).subscribe(
        res => {
          this._images = <Image[]>res;
          this.imgComp.hideLoadingMsg();
          this.imgComp.images = this._images;
        },
        err => {
          this.imgComp.showErrorMsg();
        }
      );
    }
  }

  get images() {
    return this._images;
  }

  getUrl() {
    return this.route.snapshot.params.id;
  }
}

interface Image {
  categoryToolId: number;
  categoryTypeId: number;
  commentsCount: number;
  creationDate: string;
  description: string;
  id: number;
  imgLink: string;
  likeCount: number;
  mixedActivity: number;
  newestActivity: number;
  popularActivity: number;
  title: string;
  userId: number;
  userOwnerName: string;
  viewCount: number;
}
