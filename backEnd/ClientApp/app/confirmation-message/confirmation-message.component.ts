import { Component, Input, ViewChild } from "@angular/core";
import { Message } from "@angular/compiler/src/i18n/i18n_ast";

@Component({
  selector: "app-confirmation-message",
  templateUrl: "./confirmation-message.component.html",
  styleUrls: ["./confirmation-message.component.scss"]
})
export class ConfirmationMessageComponent {
  @ViewChild("msg") msgElement: any;
  private message = "";
  constructor() {}

  show(message: string) {
    this.message = message;
    // show confirmation message
    const el = this.msgElement.nativeElement;
    el.classList.add("visible");

    // remove message after 8 seconds
    setTimeout(() => {
      if (el.classList.contains("visible")) {
        el.classList.add("hidden");
        setTimeout(() => {
          el.classList.remove("hidden");
          el.classList.remove("visible");
        }, 300);
      }
    }, 4000);
  }

  public closeMessage(id: number) {
    const el = this.msgElement.nativeElement;
    el.classList.add("hidden");

    setTimeout(() => {
      el.classList.remove("hidden");
      el.classList.remove("visible");
    }, 300);
  }
}
