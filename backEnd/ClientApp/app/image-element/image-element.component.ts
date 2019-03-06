import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-image-element",
  templateUrl: "./image-element.component.html",
  styleUrls: ["./image-element.component.scss"]
})
export class ImageElementComponent implements OnInit {
  @Input() image : any;
  constructor() {}

  ngOnInit() {}
}
