import { Component, OnInit, ViewChild } from "@angular/core";
import { ImageService } from "../../services/image.service";
import { Photo } from "./photo";
import { NgForm, FormGroup, FormBuilder, Validators } from "@angular/forms";
import { requiredTextValidator } from "../../logic/validators/text-validator";
import { fileValidator } from "../../logic/validators/file-validator";
import { LoggedIn } from "../../logic/classes/logged-in";
import { GlobalVariables } from "../../logic/classes/global-variables";
import { Router } from "@angular/router";

@Component({
  selector: "app-add-photo",
  templateUrl: "./add-photo.component.html",
  styleUrls: ["./add-photo.component.scss"]
})
export class AddPhotoComponent extends LoggedIn implements OnInit {
  @ViewChild("message") Message: any;
  @ViewChild("fileInput") fileInput: any;

  private _uploadWarning = "";
  public uploadForm: any;
  private _loading = false;

  constructor(
    private fb: FormBuilder,
    private service: ImageService,
    private router: Router
  ) {
    super();
    this.uploadForm = this.fb.group({
      title: ["", [Validators.required, requiredTextValidator]],
      description: "",
      tags: "",
      category: "",
      file: ["", [fileValidator, Validators.required]]
    });
  }

  ngOnInit() {
    super.ngOnInit();
    if (this._loggedIn === false) {
      this.router.navigateByUrl("/not-found");
    }
  }

  showErrorMsg() {
    this._uploadWarning = "There was an error, please try again.";
  }

  private sendMoreInfo(data, tags, form: NgForm) {
    this.service
      .addAdditionalImageInfo(data, this._loggedId, this._loggedToken)
      .subscribe(
        res => {
          const response = <ImageResponse>res;
          const id = response.id;

          // after image, send tags
          this.service
            .addTagsToImage(
              {
                tagsList: tags,
                postId: id
              },
              this._loggedId,
              this._loggedToken
            )
            .subscribe(
              () => {
                this.Message.show("File uploaded successfully!");
                form.reset();
                this._loading = false;
              },
              () => {
                this.showErrorMsg();
              }
            );
        },
        err => {
          this.showErrorMsg();
        }
      );
  }

  public onUpload(form: NgForm) {
    if (form.status === "INVALID") {
      this._uploadWarning = "Title and file must be added.";
    } else {
      this._loading = true;
      let linkToImg = "";
      this.service
        .uploadImage(form.value.file, this._loggedId, this._loggedToken)
        .subscribe(
          res => {
            linkToImg = res[0].url;
            this.sendMoreInfo(
              {
                userId: this._loggedId,
                title: form.value.title,
                description: form.value.description,
                imgLink: linkToImg,
                userOwnerName: ""
              },
              GlobalVariables.parseTags(form.value.tags),
              form
            );
          },
          err => {
            this.showErrorMsg();
          }
        );
      this._uploadWarning = "";
    }
  }

  get uploadWarning(): string {
    return this._uploadWarning;
  }

  get loading() {
    return this._loading;
  }
}
