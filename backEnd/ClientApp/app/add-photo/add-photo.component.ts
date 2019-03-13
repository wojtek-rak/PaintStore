import { Component, OnInit, ViewChild, ElementRef, Input } from "@angular/core";
import { ImageService } from "../services/image.service";
import { Photo } from "./photo";
import { NgForm, FormGroup, FormBuilder, Validators } from "@angular/forms";
import {
  UploadEvent,
  UploadFile,
  FileSystemFileEntry,
  FileSystemDirectoryEntry
} from "ngx-file-drop";

import { ValidateFileForm } from "../validate-file-form";
import { Message } from "@angular/compiler/src/i18n/i18n_ast";
import { requiredTextValidator } from "../validators/text-validator";
import { fileValidator } from "../validators/file-validator";
import { LoggedIn } from "../classes/logged-in";
import { HttpClient } from "@angular/common/http";
import { GlobalVariables } from "../classes/global-variables";
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
  private uploadForm: FormGroup;

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
      file: ["", fileValidator]
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

  private sendMoreInfo(data, tags) {
    this.service
      .addAdditionalImageInfo(data, this._loggedId, this._loggedToken)
      .subscribe(
        res => {
          let response = <ImageResponse>res;
          let id = response.id;

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
              res => {
                this.Message.show("File uploaded successfully!");
              },
              err => {
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
      // let newTags = [];
      // let tags = form.value.tags;

      // if (tags !== [] && tags !== "") {
      //   tags.forEach(el => {
      //     newTags.push(el.value);
      //   });
      // }
      // form.value.tags = newTags;

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
              GlobalVariables.parseTags(form.value.tags)
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

  // newUpload() {
  //   // console.log(this.file.nativeElement.files[0]);
  //   // this.service
  //   //   .uploadImage(
  //   //     this.file.nativeElement.files[0],
  //   //     this._loggedId,
  //   //     this._loggedToken
  //   //   )
  //   //   .subscribe(res => {
  //   //     console.log(res);
  //   //   });

  //   let fi = this.fileInput.nativeElement;

  //   if (fi.files && fi.files[0]) {
  //     let fileToUpload = fi.files[0];
  //     console.log(fileToUpload);
  //     this.service
  //       .upload(fileToUpload, this._loggedId, this._loggedToken) // 5000 for macc
  //       .subscribe(response => console.log(response));
  //   }
  // }
}
