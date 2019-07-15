import { Component, OnInit, ViewChild } from "@angular/core";
import { ImageService } from "../../services/image.service";
import { LoggedIn } from "../../logic/classes/logged-in";
import { GlobalVariables } from "../../logic/classes/global-variables";
import { NgForm } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-comments-logic",
  templateUrl: "./comments-logic.component.html",
  styleUrls: ["./comments-logic.component.scss"]
})
export class CommentsLogicComponent extends LoggedIn implements OnInit {
  @ViewChild("commentWrapper") commentWrapper: any;
  private _comments: Comment[] = [];
  private commentIdToRemove = 0;
  private _loading = false;
  // private formValid = true;
  @ViewChild("msg") Message: any;
  @ViewChild("confirmLabel") confirmLabel: any;
  constructor(private service: ImageService, private route: ActivatedRoute) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
    this.getCommentsData();
  }

  getCommentsData() {
    this.service
      .CommentsByImgPath(
        this._loggedId.toString(),
        this.route.snapshot.params.id
      )
      .subscribe((res: any) => {
        res.forEach(comm => {
          comm.userOwnerImgLink = GlobalVariables.parseImageLink(
            40,
            40,
            comm.userOwnerImgLink
          );
          comm.isEditing = false;
          comm.editValid = true;
        });
        this._comments = <Comment[]>res;
      });
  }

  changeComment(data: any) {
    if (data.action === "delete") {
      this.removeComment(data.value);
    } else {
      this.service
        .editComment(
          {
            id: data.id,
            content: data.value.comment
          },
          this._loggedId,
          this._loggedToken
        )
        .subscribe(res => {
          this.Message.show("Comment edited succesfully.", res);
          this.commentWrapper.updateCommentAfterServerConnection(data);
        });
    }
  }

  removeComment(id: number) {
    this.commentIdToRemove = id;
    this.confirmLabel.show();
  }

  onCommentUpload(value: any) {
    this._loading = true;
    const comment = {
      PostId: this.route.snapshot.params.id,
      UserId: this._loggedId,
      Content: value,
      LikeCount: 0
    };
    console.log(comment);
    // send message
    this.service
      .uploadComment(comment, this._loggedId, this._loggedToken)
      .subscribe(res => {
        this.Message.show("Comment uploaded succesfully.");
        this._loading = false;
        this.getCommentsData();
      });
  }

  isCommentValid(text: string): boolean {
    if (text === null) {
      return false;
    }
    if (typeof text === undefined) {
      return false;
    }
    if (text === "") {
      return false;
    }
    if (typeof text.length === undefined || text.length < 2) {
      return false;
    }
    return true;
  }

  confirm() {
    this.service
      .removeComment(this.commentIdToRemove, this._loggedId, this._loggedToken)
      .subscribe((res: any) => {
        this.getCommentsData();
        this.Message.show("Comment deleted succesfully.");
      });
  }

  get comments(): Comment[] {
    return this._comments;
  }

  get loading(): boolean {
    return this._loading;
  }
}
