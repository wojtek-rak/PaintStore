import { Component, OnInit, ElementRef, ViewChild, Input } from "@angular/core";
import { ImageService } from "../services/image.service";

@Component({
  selector: "app-search",
  templateUrl: "./search.component.html",
  styleUrls: ["./search.component.scss"]
})
export class SearchComponent implements OnInit {
  private _res: SearchRes[] = [];
  @ViewChild("input") Input: ElementRef;
  @ViewChild("button") Button: ElementRef;
  @ViewChild("searchResult") SearchResult: ElementRef;
  @ViewChild("searchField") SearchField: ElementRef;

  public loading = false;

  constructor(private service: ImageService) {}

  ngOnInit() {
    document.addEventListener("click", e => {
      if (
        e.target !== this.SearchResult.nativeElement &&
        !this.SearchResult.nativeElement.contains(e.target) &&
        (e.target !== this.SearchField.nativeElement &&
          !this.SearchField.nativeElement.contains(e.target))
      ) {
        this.SearchResult.nativeElement.classList.remove("display");
      }
    });
  }

  search(value: any) {
    this.loading = true;
    if (value !== null && value !== "") {
      this.service.search(value).subscribe(
        res => {
          if (JSON.stringify(res) !== "[]") {
            this._res = <SearchRes[]>res;
            this.SearchResult.nativeElement.classList.add("display");
          } else {
            this._res = [];
            this.SearchResult.nativeElement.classList.remove("display");
          }
          this.loading = false;
        },
        error => {}
      );
    } else {
      this.SearchResult.nativeElement.classList.remove("display");
      this._res = [];
      this.loading = false;
    }
  }

  get res() {
    return this._res;
  }
}

interface SearchRes {
  avatarImgLink: string;
  count: number;
  followedCount: number;
  id: number;
  name: string;
  tagName: string;
}
