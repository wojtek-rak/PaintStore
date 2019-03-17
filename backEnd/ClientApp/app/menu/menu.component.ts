import {
  Component,
  OnInit,
  Input,
  Output,
  ViewChild,
  ElementRef
} from "@angular/core";
import * as $ from "jquery";
import * as ScrollMagic from "ScrollMagic";
import { EventEmitter } from "@angular/core";
import { Router } from "@angular/router";
import { LoginManager } from "../classes/login-manager";
import { IsUserLoggedIn } from "../classes/is-user-logged-in";
import { LoggedIn } from "../classes/logged-in";
import { NgForm } from "@angular/forms";
import { AccountService } from "../services/account.service";
import { ImageService } from "../services/image.service";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.scss"]
})
export class MenuComponent extends LoggedIn implements OnInit {
  @ViewChild("menu") menu: any;
  @ViewChild("menuToggled") menuToggled: any;
  @ViewChild("menuUl") menuUl: any;
  @ViewChild("button") button: any; // TODO
  @ViewChild("input") input: any; // TODO
  @ViewChild("input2") input2: any;

  private host = "http://localhost:4200/";
  private loginPage = "http://localhost:4200/homepage";
  private _imgLink: string = "";

  constructor(
    private router: Router,
    private _accountService: AccountService,
    private service: ImageService
  ) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();

    // menu on homepage looks differently
    if (this._loggedIn === false) {
      $("menu").addClass("logged-out");
    }
    if (
      !this.menu.nativeElement.classList.contains("static") &&
      window.location.pathname === "/homepage"
    ) {
      this.menu.nativeElement.classList.add("static");
    }

    // hide toggled menu when clicked somewhere on page
    document.addEventListener("click", e => {
      if (
        e.target !== this.menuToggled.nativeElement &&
        !this.menuToggled.nativeElement.contains(e.target) &&
        (e.target !== this.button.nativeElement &&
          !this.button.nativeElement.contains(e.target))
      ) {
        this.menuToggled.nativeElement.classList.remove("visible");
      }
    });

    // scroll menu
    for (let i = 1; i <= 6; i++) {
      let controller = new ScrollMagic.Controller();

      let scene = new ScrollMagic.Scene({
        triggerElement: ".scrollmagic-toggle",
        triggerHook: 0,
        offset: 40
      })
        .setClassToggle(".container-menu", "scrolled")
        .addTo(controller);
    }

    if (this._loggedIn === true) this.getProfileImage();
  }

  getProfileImage() {
    this.service
      .selectUserById(this._loggedId.toString(), this._loggedId.toString())
      .subscribe((res: any) => {
        this._imgLink = res.avatarImgLink;
      });
  }

  toggleMenu() {
    this.menuToggled.nativeElement.classList.toggle("visible");
  }

  toggleClass() {
    console.log("click");
    this.menuUl.nativeElement.classList.toggle("hidden");
  }

  onLogin(form: NgForm) {
    this._accountService
      .getUserToken({
        email: form.form.value.email,
        password: form.form.value.password
      })
      .subscribe(
        res => {
          LoginManager.loginUser(res);
          if (location.href.replace(/.*\/\/[^\/]*/, "") === "/homepage")
            window.location.replace("");
          else document.location.reload();
        },
        err => {
          this.input.nativeElement.classList.add("invalid");
          this.input2.nativeElement.classList.add("invalid");
        }
      );
  }

  onKeyup() {
    this.input.nativeElement.classList.remove("invalid");
    this.input2.nativeElement.classList.remove("invalid");
  }

  logout() {
    this._accountService
      .logoutUser({ id: this.loggedId }, this._loggedId, this._loggedToken)
      .subscribe(res => {
        LoginManager.logoutUser();
        window.location.replace("homepage");
      });
  }

  get imgLink() {
    return this._imgLink;
  }
}
