import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Image } from "../classes/image";
import { ImageService } from "../services/image.service";

@Component({
  selector: "app-tags",
  templateUrl: "./tags.component.html",
  styleUrls: ["./tags.component.scss"]
})
export class TagsComponent implements OnInit {
  private _tagname = "";
  private _images: Image[] = [];
  private _loading = false;

  constructor(private route: ActivatedRoute, private service: ImageService) {}

  ngOnInit() {
    this._tagname = this.route.snapshot.params.id;
    this.getImages();
  }

  getImages() {
    this._loading = true;
    this.service.imagesByTag(this._tagname).subscribe(res => {
      console.log(res);
      this._images = <Image[]>res;
      this._loading = false;
    });
  }

  get tagname(): string {
    return this._tagname;
  }

  get images(): Image[] {
    return this._images;
  }

  get loading(): boolean {
    return this._loading;
  }
}
