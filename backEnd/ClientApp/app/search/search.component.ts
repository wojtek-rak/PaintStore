import { Component, OnInit, ElementRef, ViewChild, Input } from "@angular/core";
import { ImageService } from "../services/image.service";

@Component({
  selector: "app-search",
  templateUrl: "./search.component.html",
  styleUrls: ["./search.component.scss"]
})
export class SearchComponent implements OnInit {
  private res: SearchRes[] = [];// TODO
    @ViewChild("input") Input: any;// TODO
    @ViewChild("button") Button: any;// TODO
    @ViewChild("searchResult") SearchResult: any;// TODO
    @ViewChild("searchField") SearchField: any;// TODO

  public loading = false;

  constructor(private service: ImageService) {}

  ngOnInit() {
    document.addEventListener("click", e => {
      // console.log(e);
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

  search(value : any) {
    this.loading = true;
    if (value !== null && value !== "") {
      this.service.search(value).subscribe(
        res => {
          if (JSON.stringify(res) !== "[]") {
            this.res = <SearchRes[]>res;
            console.log(this.res);
            this.SearchResult.nativeElement.classList.add("display");
          } else {
            this.res = []; // TODO
            this.SearchResult.nativeElement.classList.remove("display");
          }
          this.loading = false;
        },
        error => {
          console.log("error!", error);
        }
      );
    } else {
      this.SearchResult.nativeElement.classList.remove("display");
      this.res = []; // TODO
      this.loading = false;
    }
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
