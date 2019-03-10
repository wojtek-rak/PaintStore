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
  // private id = this.route.parent.snapshot.paramMap.get("id");
  // private path = this.route.snapshot.routeConfig.path;

  constructor(
    private imageService: ImageService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    if (this.route.snapshot.routeConfig === null) return;
    if (this.route.parent === null) return;

    let path = this.route.snapshot.routeConfig.path;
    let id = this.route.parent.snapshot.paramMap.get("id");

    if (id === null) return;
    this.imgComp.showLoadingMsg();
    if (path === this.selectedRoutes.recent) {
      this.imageService.selectUserTrendingImages(id).subscribe(
        res => {
          this._images = <Image[]>res;
          this.imgComp.hideLoadingMsg();
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
