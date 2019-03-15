import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, Validators, NgForm } from "@angular/forms";
import {
  requiredTextValidator,
  shortTextValidator,
  passwordValidator
} from "ClientApp/app/validators/text-validator";
import { emailValidator } from "ClientApp/app/validators/email-validator";
import { passwordsValidator } from "ClientApp/app/validators/passwords-validator";
import { fileValidator } from "ClientApp/app/validators/file-validator";
import { ImageService } from "ClientApp/app/services/image.service";
import { LoggedIn } from "ClientApp/app/classes/logged-in";
import { User } from "ClientApp/app/classes/user";
import { UserService } from "ClientApp/app/services/user.service";

@Component({
  selector: "app-informations",
  templateUrl: "./informations.component.html",
  styleUrls: ["./informations.component.scss"]
})
export class InformationsComponent extends LoggedIn implements OnInit {
  private _user = new User();
  private form: any; // By�o FRORM GROUP TODO GRUBIEJ
  private _informationsWarning = "";
  private _loading = false;
  @ViewChild("file") file;
  @ViewChild("msg") msg;

  constructor(
    private fb: FormBuilder,
    private service: ImageService,
    private userService: UserService
  ) {
    super();
  }

  initializeForm() {
    this.form = this.fb.group({
      userName: [this._user.name, [Validators.required, requiredTextValidator]],
      shortInformation: [this._user.link, shortTextValidator],
      description: [this._user.about],
      file: [null, fileValidator]
    });
  }

  informationAboutUser() {
    this.service
      .selectUserById(this._loggedId.toString(), this._loggedId.toString())
      .subscribe((res: User) => {
        this._user = res;
        this.initializeForm();
      });
  }

  ngOnInit() {
    super.ngOnInit();
    this.informationAboutUser();
  }

  // this causes error 200
  editUser(link: string, value: any) {
    this.service
      .editUser(
        {
          id: this._loggedId,
          name: value.userName,
          avatarImgLink: link,
          about: value.description
        },
        this._loggedId,
        this._loggedToken
      )
      .subscribe(
        res => {
          this._loading = false;
          this.msg.show("Profile updated successfully.");
          this.file.clear();
          this._informationsWarning = "";
        },
        err => {
          if (err.status === 403)
            this._informationsWarning = "Name arleady exists.";
        }
      );
  }

  onFormUpload(form: NgForm) {
    if (form.status === "VALID") {
      this._loading = true;
      if (this.file.validateMessage !== "") {
        form.value.file = null;
        this.file.clear();
      }

      if (form.value.file === null) {
        this.editUser(null, form.value);
      } else {
        console.log("nienull");
        this.service
          .uploadImage(form.value.file, this._loggedId, this._loggedToken)
          .subscribe(res => {
            const linkToImg = res[0].url;
            this.editUser(linkToImg, form.value);
          });
      }
    } else {
      this._informationsWarning = "All fields must be valid.";
    }
  }

  get user() {
    return this._user;
  }

  get informationsWarning() {
    return this._informationsWarning;
  }

  get loading() {
    return this._loading;
  }
}
