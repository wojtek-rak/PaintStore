import { Component, OnInit, Input, ElementRef, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
// import { Image } from "../classes/image";

@Component({
  selector: "app-images-common",
  templateUrl: "./images-common.component.html",
  styleUrls: ["./images-common.component.scss"]
})
export class ImagesCommonComponent implements OnInit {
  // @Input("images") Images: Image[] = [];
  @Input("classes") classes: string = "";
  @ViewChild("msg") msg: any;
  private _loading: boolean = false;
  private _fail: boolean = false;
  private _howMany = 0;
  private _resizeReady = false;
  private _images: Image[] = [];

  private valueToAdd = 24;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this._howMany = this.valueToAdd;
    this._images.forEach(el => {
      console.log(el);
    });
  }

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
    const elToRemove = this._images.find(x => x.id === $event);
    this._images.splice(this._images.indexOf(elToRemove), 1);
    this.msg.show("Image deleted successfully.");
  }

  loadMore() {
    this._howMany += this.valueToAdd;
  }

  // stop loading icon
  // there is no images or there are images
  hideLoadingMsg() {
    this._loading = false;
  }

  resizeLinks(w: number, h: number) {
    const insertAfter = "http://res.cloudinary.com/dvjarj3xz/image/upload/";
    let toInsert;
    this._images.forEach(el => {
      toInsert = "w_300,h_250,c_fill/q_auto:low/";
      el.imgLink = [
        el.imgLink.slice(0, insertAfter.length),
        toInsert,
        el.imgLink.slice(insertAfter.length)
      ].join("");

      if (el.userOwnerImgLink !== null && el.userOwnerImgLink !== "") {
        toInsert = "w_22,h_22,c_fill/q_auto:low/";
        el.userOwnerImgLink = [
          el.userOwnerImgLink.slice(0, insertAfter.length),
          toInsert,
          el.userOwnerImgLink.slice(insertAfter.length)
        ].join("");
      }
    });
  }

  set images(images: Image[]) {
    this._resizeReady = false;

    this._images = images;
    this.resizeLinks(300, 250);

    this._resizeReady = true;
  }

  get images(): Array<Image> {
    return this._images;
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

  get resizeReady() {
    return this._resizeReady;
  }

  getUrl() {
    return this.route.snapshot.params.id;
  }
}
