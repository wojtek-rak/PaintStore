import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-likes",
  templateUrl: "./likes.component.html",
  styleUrls: ["./likes.component.scss"]
})
export class LikesComponent implements OnInit {
  @Input() data: any;
  @Output() emitter: EventEmitter<any> = new EventEmitter();
  constructor() {}

  ngOnInit() {
    console.log(this.data);
  }

  commentLike() {
    this.emitter.emit({
      type: "comment",
      like: true,
      unlike: false,
      show: false,
      comment: this.data.comment
    });
  }
  commentUnlike() {
    this.emitter.emit({
      type: "comment",
      like: false,
      unlike: true,
      show: false,
      comment: this.data.comment
    });
  }

  commentShowLiked() {
    this.emitter.emit({
      type: "comment",
      like: false,
      unlike: false,
      show: true,
      comment: this.data.comment
    });
  }
}
