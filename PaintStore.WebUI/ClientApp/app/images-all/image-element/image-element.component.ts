import {
  Component,
  OnInit,
  Input,
  ViewChild,
  ElementRef,
  Output,
  EventEmitter
} from "@angular/core";
import { ImageService } from "../../services/image.service";
import { LoggedIn } from "../../logic/classes/logged-in";

@Component({
  selector: "app-image-element",
  templateUrl: "./image-element.component.html",
  styleUrls: ["./image-element.component.scss"]
})
export class ImageElementComponent extends LoggedIn {
  @Input() image: Image;
  @ViewChild("confirmLabel") confirmLabel: any;
  @ViewChild("container") container: ElementRef;
  @Output() emitter: EventEmitter<any> = new EventEmitter();

  constructor(private service: ImageService) {
    super();
  }

  confirm() {
    this.service
      .deleteImage(this.image.id, this._loggedId, this._loggedToken)
      .subscribe(res => {
        this.emitter.emit(this.image.id);
      });
  }

  deleteImg() {
    this.confirmLabel.show();
  }
}
