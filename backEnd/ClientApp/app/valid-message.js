var ValidMessage = /** @class */ (function () {
    function ValidMessage() {
        this._valid = true;
        this._message = "";
    }
    ValidMessage.prototype.setProperties = function (valid, message) {
        this._valid = valid;
        this._message = message;
    };
    Object.defineProperty(ValidMessage.prototype, "valid", {
        get: function () {
            return this._valid;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ValidMessage.prototype, "message", {
        get: function () {
            return this._message;
        },
        enumerable: true,
        configurable: true
    });
    return ValidMessage;
}());
export { ValidMessage };
//# sourceMappingURL=valid-message.js.map