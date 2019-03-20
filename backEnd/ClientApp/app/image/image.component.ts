import { Component, OnInit, ViewChild } from "@angular/core";
import { ImageService } from "../services/image.service";
import { ActivatedRoute } from "@angular/router";
import { NgForm, FormGroup, Validators, FormBuilder } from "@angular/forms";
import { ShortUserInfo } from "../classes/short-user-info";
import { LoggedIn } from "../classes/logged-in";
import { requiredTextValidator } from "../validators/text-validator";
import { GlobalVariables } from "../classes/global-variables";

@Component({
  selector: "app-image",
  templateUrl: "./image.component.html",
  styleUrls: ["./image.component.scss"]
})
export class ImageComponent extends LoggedIn implements OnInit {
  @ViewChild("msg") Message: any;
  @ViewChild("msgDelete") msgDelete: any;
  @ViewChild("confirmLabel") confirmLabel: any;
  @ViewChild("label") label: any;
  private _image: ImageExact = {
    commentsCount: 0,
    creationDate: "",
    description: "",
    id: 0,
    imgLink: "",
    likeCount: 0,
    tagsList: [],
    title: "",
    userId: 0,
    userOwnerImgLink: "",
    userOwnerName: "",
    liked: false
  };

  private _titleEditing = false;
  private _descriptionEditing = false;
  private _tagsEditing = false;

  private _comments: Comment[] = [];
  private formValid = true;
  private _loading = false;
  private commentIdToRemove = 0; // TODO sprawdz czy sie nie wyjebalo
  private titleForm: FormGroup;
  private descriptionForm: FormGroup;
  private tagsForm: FormGroup;
  private _imgLink = "";

  constructor(
    private service: ImageService,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    super();
  }

  getProfileImage() {
    if (this._loggedIn === true) {
      this.service
        .selectUserById(this._loggedId.toString(), this._loggedId.toString())
        .subscribe((res: any) => {
          this._imgLink = GlobalVariables.parseImageLink(
            40,
            40,
            res.avatarImgLink
          );
        });
    }
  }

  initializeForms() {
    this.titleForm = this.fb.group({
      title: [this._image.title, [Validators.required, requiredTextValidator]]
    });

    this.descriptionForm = this.fb.group({
      description: this._image.description
    });

    this.tagsForm = this.fb.group({
      tags: this._image.tagsList
    });
  }

  ngOnInit() {
    super.ngOnInit();
    this.getCommentsData();
    this.getImageData();
    this.getProfileImage();
  }

  getImageData() {
    this.service
      .ImageByPath(this._loggedId.toString(), this.route.snapshot.params.id)
      .subscribe((res: any) => {
        res.imgLink = GlobalVariables.parseImageLink(
          1290,
          700,
          res.imgLink,
          "c_fit",
          "good"
        );
        this._image = <ImageExact>res;
        this.initializeForms();
      });
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
    if (typeof text.length === undefined || text.length < 5) {
      return false;
    }
    return true;
  }

  onCommentUpload(form: NgForm) {
    if (!this.isCommentValid(form.value.text)) {
      // if comment is null
      this.formValid = false;
    } else {
      this._loading = true;
      const comment = {
        PostId: this.route.snapshot.params.id,
        UserId: this._loggedId,
        Content: form.value.text,
        LikeCount: 0
      };
      // send message
      this.service
        .uploadComment(comment, this._loggedId, this._loggedToken)
        .subscribe(res => {
          this.Message.show("Comment uploaded succesfully.");
          this.formValid = true;
          this._loading = false;
          this.getCommentsData();
        });

      form.resetForm();
    }
  }

  confirm() {
    this.service
      .removeComment(this.commentIdToRemove, this._loggedId, this._loggedToken)
      .subscribe((res: any) => {
        this.getCommentsData();
        this.Message.show("Comment deleted succesfully.");
      });
  }

  photoLike() {
    this._image.likeCount += 1;
    this._image.liked = true;
    this.service
      .likePost(
        {
          userId: this._loggedId,
          postId: this.route.snapshot.params.id
        },
        this._loggedId,
        this._loggedToken
      )
      .subscribe(res => {});
  }

  photoUnlike() {
    this._image.likeCount -= 1;
    this._image.liked = false;
    this.service
      .unlikePost(
        this._loggedId.toString(),
        this.route.snapshot.params.id,
        this._loggedId,
        this._loggedToken
      )
      .subscribe(res => {});
  }

  showLiking() {
    let informationToSend: ShortUserInfo[];
    this.service
      .getPostLikes(this._loggedId.toString(), this.route.snapshot.params.id)
      .subscribe(res => {
        informationToSend = <ShortUserInfo[]>res;
        this.label.show(informationToSend, "Liked this image");
      });
  }

  commentShowLiked(id: number) {
    let informationToSend: ShortUserInfo[];
    this.service
      .getCommentLikes(this._loggedId.toString(), id.toString())
      .subscribe(res => {
        informationToSend = <ShortUserInfo[]>res;
        this.label.show(informationToSend, "Liked this comment");
      });
  }

  commentLike(comment: any) {
    comment.liked = true;
    comment.likeCount += 1;
    this.service
      .likeComment(
        {
          userId: this._loggedId,
          commentId: comment.id
        },
        this._loggedId,
        this._loggedToken
      )
      .subscribe(res => {});
  }

  commentUnlike(comment: any) {
    comment.liked = false;
    comment.likeCount -= 1;
    this.service
      .unlikeComment(this._loggedId, comment.id, this._loggedToken)
      .subscribe(res => {});
  }

  removeComment(id: number) {
    this.commentIdToRemove = id;
    this.confirmLabel.show();
  }

  editComment(comment: any) {
    comment.isEditing = true;
  }

  sendEditComment(form: NgForm, comment: Comment) {
    const text = form.form.value.value;
    if (this.isCommentValid(text)) {
      comment.editValid = true;
      const data = {
        id: comment.id,
        content: text
      };
      this.service
        .editComment(data, this._loggedId, this._loggedToken)
        .subscribe(res => {
          this.Message.show("Comment edited succesfully.", res);
          comment.isEditing = false;
          comment.edited = true;
          comment.content = text;
        });
    } else {
      comment.editValid = false;
    }
  }

  discard(comment: any) {
    comment.isEditing = false;
    comment.editValid = true;
  }

  editTitle() {
    this._titleEditing = true;
  }

  discardTitle() {
    this._titleEditing = false;
  }

  approveTitle(form: NgForm) {
    this.editRequest(
      {
        id: this._image.id,
        title: form.value.title,
        description: this.image.description
      },
      "Title edited successfully."
    );
  }

  editDescription() {
    this._descriptionEditing = true;
  }

  discardDescription() {
    this._descriptionEditing = false;
  }

  // sends requests when editing both the thescription and the title
  private editRequest(data: any, successMessage: string) {
    this.service
      .editImage(data, this._loggedId, this._loggedToken)
      .subscribe(res => {
        this._descriptionEditing = false;
        this._titleEditing = false;
        this.Message.show(successMessage);
        this._image.title = data.title;
        this._image.description = data.description;
      });
  }

  approveDescription(form: NgForm) {
    this.editRequest(
      {
        id: this._image.id,
        title: this._image.title,
        description: form.value.description
      },
      "Description updated successfully."
    );
  }

  editTags() {
    this._tagsEditing = true;
  }

  discardTags() {
    this._tagsEditing = false;
  }

  approveTags(form: NgForm) {
    const parsedTags = GlobalVariables.parseTags(form.value.tags);
    this._tagsEditing = false;

    this.service
      .addTagsToImage(
        {
          tagsList: parsedTags,
          postId: this._image.id
        },
        this._loggedId,
        this._loggedToken
      )
      .subscribe(res => {
        this._image.tagsList = parsedTags;
        this.Message.show("Tags updated successfully.");
      });
  }

  get image(): ImageExact {
    return this._image;
  }

  get comments(): Comment[] {
    return this._comments;
  }

  get loading(): boolean {
    return this._loading;
  }

  get titleEditing(): boolean {
    return this._titleEditing;
  }

  get descriptionEditing(): boolean {
    return this._descriptionEditing;
  }

  get tagsEditing(): boolean {
    return this._tagsEditing;
  }

  get imgLink() {
    return this._imgLink;
  }
}

interface ImageExact {
  commentsCount: number;
  creationDate: string;
  description: string;
  id: number;
  imgLink: string;
  likeCount: number;
  tagsList: string[];
  title: string;
  userId: number;
  userOwnerImgLink: string;
  userOwnerName: string;
  liked: boolean;
}

interface Comment {
  content: string;
  creationDate: string;
  edited: boolean;
  id: number;
  likeCount: number;
  liked: boolean;
  userId: number;
  userName: string;
  userOwnerImgLink: string;
  isEditing: boolean;
  editValid: boolean;
}
