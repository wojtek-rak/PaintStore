import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-comment-wrapper",
  templateUrl: "./comment-wrapper.component.html",
  styleUrls: ["./comment-wrapper.component.scss"]
})
export class CommentWrapperComponent implements OnInit {
  @Input() data: any;
  @Output() emitter: EventEmitter<any> = new EventEmitter(); // emitter for comments
  @Output() emitter2: EventEmitter<any> = new EventEmitter(); // emitter for likes
  constructor() {}

  ngOnInit() {}

  likeManager(data: any) {
    this.emitter2.emit(data);
  }

  changeComment(data: any) {
    this.emitter.emit(data);
  }

  updateCommentAfterServerConnection(data: any) {
    console.log("updating", data);
    this.data.comments.find(comment => {
      return comment.id === data.id;
    }).content = data.value.comment;
  }

  commentValue(comment: any): string {
    let data = `<h4 class="author">
                <a href="/user/${comment.userId}">
                  ${comment.userName}</a>
                </h4>
                <p class="content-secondary header-info">
                  ${comment.creationDate}
                </p>`;

    if (comment.edited) {
      data += '<span class="header-info">(edited)</span>';
    }

    return data;
  }
}
