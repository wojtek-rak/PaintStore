export class ValidateFileForm {
  private _title: string;
  private _file: string;
  private _category: string;
  constructor() {
    this._title = "";
    this._category = "";
    this._file = "";
  }

  get title(): string {
    return this._title;
  }

  set title(title: string) {
    this._title = title;
  }

  get file(): string {
    return this._file;
  }

  set file(file: string) {
    this._file = file;
  }

  get category(): string {
    return this._category;
  }

  set category(category: string) {
    this._category = category;
  }
}
