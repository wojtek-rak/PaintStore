import { Component, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ImageService } from "../../services/image.service";

@Component({
  selector: "app-tags",
  templateUrl: "./tags.component.html",
  styleUrls: ["./tags.component.scss"]
})
export class TagsComponent implements OnInit {
  @ViewChild("imgComp") imgComp: any;
  private _tagname = "";
  private _images: Image[] = [];

  constructor(private route: ActivatedRoute, private service: ImageService) {}

  ngOnInit() {
    this._tagname = this.route.snapshot.params.id;
    this.getImages();
  }

  getImages() {
    this.imgComp.showLoadingMsg();
    this.service.imagesByTag(this._tagname).subscribe(
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

  get tagname(): string {
    return this._tagname;
  }

  get images(): Image[] {
    return this._images;
  }
}
