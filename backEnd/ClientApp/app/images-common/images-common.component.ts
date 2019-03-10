import { Component, OnInit, Input } from "@angular/core";
import { Image } from "../classes/image";

@Component({
  selector: "app-images-common",
  templateUrl: "./images-common.component.html",
  styleUrls: ["./images-common.component.scss"]
})
export class ImagesCommonComponent implements OnInit {
  @Input("images") Images: Image[] = [];
  @Input("classes") classes: string = "";
  private _loading: boolean = false;
  private _fail: boolean = false;

  constructor() {}

  ngOnInit() {}

  // show loading icon
  showLoadingMsg() {
    console.log("loading");
    this._loading = true;
  }

  // error occured
  showErrorMsg() {
    this._loading = false;
    this._fail = true;
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

  get images(): Array<Image> {
    return this.Images;
  }

  get loading(): boolean {
    return this._loading;
  }

  get fail(): boolean {
    return this._fail;
  }
}
