import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { FormGroup, Validators, FormBuilder, NgForm } from "@angular/forms";
import {
  requiredTextValidator,
  requiredTextareaValidator
} from "../../logic/validators/text-validator";

@Component({
  selector: "app-add-comment",
  templateUrl: "./add-comment.component.html",
  styleUrls: ["./add-comment.component.scss"]
})
export class AddCommentComponent implements OnInit {
  @Input() data: any;
  private _message = "";
  private uploadForm: FormGroup;
  private formValid = true;
  @Output() emitter: EventEmitter<any> = new EventEmitter();
  constructor(private fb: FormBuilder) {
    this.uploadForm = this.fb.group({
      title: ["", [Validators.required, requiredTextareaValidator]]
    });
  }

  ngOnInit() {}

  public onUpload(form: NgForm) {
    if (form.status === "INVALID") {
      this._message = "Data is invalid.";
    } else {
      this.emitter.emit(form.value.text);
      this.formValid = true;
      form.resetForm();
    }
  }

  get message(): string {
    return this._message;
  }
}
