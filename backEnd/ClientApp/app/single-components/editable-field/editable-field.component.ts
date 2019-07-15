import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { NgForm, FormGroup, FormBuilder, Validators } from "@angular/forms";
import { requiredTextValidator } from "../../logic/validators/text-validator";

@Component({
  selector: "app-editable-field",
  templateUrl: "./editable-field.component.html",
  styleUrls: ["./editable-field.component.scss"]
})
export class EditableFieldComponent implements OnInit {
  @Input() data: any;
  private fieldEditing: boolean;
  private fieldForm: FormGroup;
  @Output() emitter: EventEmitter<any> = new EventEmitter();

  constructor(private fb: FormBuilder) {
    this.fieldEditing = false;
    console.log(this.data);
  }

  ngOnInit() {
    this.fieldForm = this.fb.group({
      [this.data.name]: [
        this.data.value,
        [Validators.required, requiredTextValidator]
      ]
    });

    console.log(this.data);
  }

  editField() {
    this.fieldEditing = true;
  }

  discardEditField() {
    console.log("discarded");
    this.fieldEditing = false;
  }

  submitEditField(form: NgForm) {
    if (form.status === "VALID") {
      console.log(form.value.title);
      this.fieldEditing = false;

      this.emitter.emit({
        id: this.data.id,
        action: "change",
        value: form.value
      });
    }
  }

  removeElement() {
    this.emitter.emit({
      action: "delete",
      value: this.data.id
    });
    // pokazanie sie informacji czy na pewno
  }
}
