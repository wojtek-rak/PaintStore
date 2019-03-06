export class ValidMessage {
    constructor() {
        this._valid = true;
        this._message = "";
    }
    setProperties(valid, message) {
        this._valid = valid;
        this._message = message;
    }
    get valid() {
        return this._valid;
    }
    get message() {
        return this._message;
    }
}
//# sourceMappingURL=valid-message.js.map