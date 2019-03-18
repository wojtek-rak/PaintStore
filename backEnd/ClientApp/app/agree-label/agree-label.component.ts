import {
  Component,
  OnInit,
  Input,
  ViewChild,
  EventEmitter,
  Output
} from "@angular/core";
import { Message } from "@angular/compiler/src/i18n/i18n_ast";

@Component({
  selector: "app-agree-label",
  templateUrl: "./agree-label.component.html",
  styleUrls: ["./agree-label.component.scss"]
})
export class AgreeLabelComponent implements OnInit {
  @Input() message: any;
  @Output() emitter: EventEmitter<any> = new EventEmitter();
  @ViewChild("wrapper") wrapper: any;
  constructor() {}

  ngOnInit() {
    document.addEventListener("click", e => {
      if ((<any>e).path[0].classList.contains("message-container")) {
        this.close();
      }
    });
  }

  confirm() {
    this.close();
    this.emitter.emit();
  }

  show() {
    const nullCheck = document.querySelector("body");
    if (nullCheck === null) return;
    nullCheck.classList.add("stop-scrolling");
    const el = this.wrapper.nativeElement;
    el.classList.add("display");
    setTimeout(() => {
      el.classList.add("opacity");
    }, 0);
  }

  close() {
    const nullCheck = document.querySelector("body");
    if (nullCheck === null) return;
    nullCheck.classList.remove("stop-scrolling");
    const el = this.wrapper.nativeElement;
    el.classList.remove("opacity");
    setTimeout(() => {
      el.classList.remove("display");
    }, 200);
  }
}
