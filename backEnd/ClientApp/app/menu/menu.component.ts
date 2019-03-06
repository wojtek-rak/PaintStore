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

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.scss"]
})
export class MenuComponent extends LoggedIn implements OnInit {
  @ViewChild("menu") menu: ElementRef;
  @ViewChild("menuToggled") menuToggled: ElementRef;
  @ViewChild("button") button: ElementRef;
  @ViewChild("input") input: ElementRef;
  @ViewChild("input2") input2: ElementRef;

  private host = "http://localhost:4200/";
  private loginPage = "http://localhost:4200/homepage";

  constructor(private router: Router, private _accountService: AccountService) {
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
  }

  toggleMenu() {
    this.menuToggled.nativeElement.classList.toggle("visible");
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
          window.location.replace(this.host);
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
        window.location.replace(this.loginPage);
      });
  }
}
