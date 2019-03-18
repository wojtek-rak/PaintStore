import { Component, OnInit, Input, ElementRef, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
// import { Image } from "../classes/image";

@Component({
  selector: "app-images-common",
  templateUrl: "./images-common.component.html",
  styleUrls: ["./images-common.component.scss"]
})
export class ImagesCommonComponent implements OnInit {
  @Input("images") Images: Image[] = [];
  @Input("classes") classes: string = "";
  @ViewChild("msg") msg: any;
  private _loading: boolean = false;
  private _fail: boolean = false;
  private _howMany = 0;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {}

  // show loading icon
  showLoadingMsg() {
    this._loading = true;
  }

  // error occured
  showErrorMsg() {
    this._loading = false;
    this._fail = true;
  }

  delete($event) {
    const elToRemove = this.Images.find(x => x.id === $event);
    this.Images.splice(this.Images.indexOf(elToRemove), 1);
    this.msg.show("Image deleted successfully.");
  }

  // there is no images yet
  // showEmptyMsg() {
  //   this._loading = false;
  // }

  // stop loading icon
  // there is no images or there are images
  hideLoadingMsg() {
    this._loading = false;
  }

  set images(images: Image[]) {
    this.Images = images;
  }

  get images(): Array<Image> {
    return this.Images;
  }

  get loading(): boolean {
    return this._loading;
  }

  get fail(): boolean {
    return this._fail;
  }

  get howMany() {
    return this._howMany;
  }

  getUrl() {
    // console.log(this.route);
    return this.route.snapshot.params.id;
  }
}
