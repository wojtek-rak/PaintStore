import * as $ from "jquery";
import {
  forwardRef,
  Component,
  OnInit,
  AfterContentChecked
} from "@angular/core";
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  NG_VALIDATORS,
  FormControl
} from "@angular/forms";
import { InputField } from "../input-field";
// import { textValidator } from "src/app/validators/text-validator";
import { fileValidator } from "../../validators/file-validator";

@Component({
  selector: "input-file",
  templateUrl: "./input-file.component.html",
  styleUrls: ["./input-file.component.scss"],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputFileComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => InputFileComponent),
      multi: true
    }
  ]
})
export class InputFileComponent extends InputField implements OnInit {
  private _information = "Drop a file here";
  private elements = [];
  private iconsToAnimate = ["svg-upload", "svg-success", "svg-fail"];
  private first: boolean = true;

  constructor() {
    super();
  }

  validate(c: FormControl) {
    // console.log("validate");
    let validator = fileValidator(c, this.data.label);
    console.log(c);

    if (c.value === "" || c.value === null || c.value.file === null) {
      // if file is empty, animate upload icon
      this.animateIcon("svg-upload");
    } else if (validator === null) {
      // if there is no errors, animate succes icon
      // if (!this.first) {
      this.animateIcon("svg-success");
      // } else this.first = false;
    } else if (validator.error !== "") {
      // if there is error, animate error icon
      this.animateIcon("svg-fail");
    }

    // if (!this.first) {
    super.setMessage(validator);
    // }

    return validator;
  }

  ngOnInit() {
    // for animating svg icons
    this.iconsToAnimate.forEach(icon => {
      this.elements.push(document.getElementsByClassName(icon)[0]);
    });
    // add listeners to label
    let $fileLabel = $(".file-label");
    $fileLabel
      .on("drag dragstart dragend dragover dragenter dragleave drop", function(
        e
      ) {
        e.preventDefault();
      })
      .on("dragover dragenter", function() {
        $fileLabel.addClass("is-dragover");
      })
      .on("dragleave dragend drop", function() {
        $fileLabel.removeClass("is-dragover");
      })
      .on("drop", (e: any) => {
        this.Input.nativeElement.files = e.originalEvent.dataTransfer.files;
        // this.file = e.originalEvent.dataTransfer.files[0];
        this.dropped();
      });

    // if label is clicked
    let $fileInput = $(".file-input");
    $fileInput.on("change", () => {
      // this.file = $fileInput.prop("files")[0];
      this.dropped();
    });

    $fileLabel.on("keyup", function(e) {
      if (e.keyCode == 13) {
        $fileInput.trigger("click");
      }
    });
  }

  get information() {
    return this._information;
  }

  private animateIcon(icon: string) {
    this.elements.forEach(element => {
      // ele.classList.remove("end-animation", "hidden");
      if (element.classList.contains("start-animation")) {
        // if (element.classList.contains(icon)) return;
        element.classList.remove("start-animation");
        element.classList.add("end-animation");
      }
    });

    setTimeout(() => {
      let el = document.getElementsByClassName(icon)[0];
      el.classList.remove("end-animation", "hidden");
      el.classList.add("start-animation");
    }, 300);
  }

  private dropped() {
    // console.log(this.Input.nativeElement.files[0]);
    this._information = this.Input.nativeElement.files[0].name;
    super.change(this.Input.nativeElement.files[0]);
  }

  private clear() {
    // this.animateIcon("svg-upload");
    this._information = "Drop a file here";
    this.Input.nativeElement.value = "";
    this._validateMessage = "";
    console.log(this.Input.nativeElement.files[0]);
    super.change(null);
  }

  public getFile() {
    return this.Input.nativeElement.files[0];
  }
}
