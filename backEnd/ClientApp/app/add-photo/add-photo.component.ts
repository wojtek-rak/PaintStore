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

@Component({
  selector: "app-add-photo",
  templateUrl: "./add-photo.component.html",
  styleUrls: ["./add-photo.component.scss"]
})
export class AddPhotoComponent extends LoggedIn implements OnInit {
  @ViewChild("message") Message : any;
  @ViewChild("fileInput") fileInput : any;
    
  private _uploadWarning = "";
  private uploadForm: FormGroup;

  constructor(private fb: FormBuilder, private service: ImageService) {
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
  }

  public onUpload(form: NgForm) {
    if (form.status === "INVALID") {
      this._uploadWarning = "Title and file must be added.";
    } else {
      let newTags : any[] = [];
      let tags = form.value.tags;

      if (tags !== [] && tags !== "") {
        // console.log(tags);
        tags.forEach((el: any)  => {
          newTags.push(el.value);
        });
      }
      form.value.tags = newTags;
      // console.log(form.value);
      this.service.uploadImage(
        form.value.file,
        this._loggedId,
        this._loggedToken
      )
      // .subscribe(res => {
      //   console.log(res)
      // });
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
