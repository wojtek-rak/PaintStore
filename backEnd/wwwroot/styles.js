(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["styles"],{

/***/ "./ClientApp/styles.scss":
/*!*******************************!*\
  !*** ./ClientApp/styles.scss ***!
  \*******************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {


var content = __webpack_require__(/*! !../node_modules/raw-loader!../node_modules/postcss-loader/lib??embedded!../node_modules/sass-loader/lib/loader.js??ref--15-3!./styles.scss */ "./node_modules/raw-loader/index.js!./node_modules/postcss-loader/lib/index.js?!./node_modules/sass-loader/lib/loader.js?!./ClientApp/styles.scss");

if(typeof content === 'string') content = [[module.i, content, '']];

var transform;
var insertInto;



var options = {"hmr":true}

options.transform = transform
options.insertInto = undefined;

var update = __webpack_require__(/*! ../node_modules/style-loader/lib/addStyles.js */ "./node_modules/style-loader/lib/addStyles.js")(content, options);

if(content.locals) module.exports = content.locals;

if(false) {}

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./node_modules/postcss-loader/lib/index.js?!./node_modules/sass-loader/lib/loader.js?!./ClientApp/styles.scss":
/*!*********************************************************************************************************************************************************!*\
  !*** ./node_modules/raw-loader!./node_modules/postcss-loader/lib??embedded!./node_modules/sass-loader/lib/loader.js??ref--15-3!./ClientApp/styles.scss ***!
  \*********************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "@import url(\"https://fonts.googleapis.com/css?family=Montserrat:300,400,600\");\n@import url(\"https://fonts.googleapis.com/css?family=Roboto:300,400,500\");\n@import url(\"https://fonts.googleapis.com/css?family=Roboto+Slab:400,700\");\nhtml, body {\n  padding: 0;\n  margin: 0;\n  background-color: #eee;\n  font-size: 16px; }\nul {\n  padding: 0;\n  margin: 0;\n  list-style-type: none; }\na {\n  color: #333;\n  text-decoration: none;\n  letter-spacing: 0.3px; }\nh1, h2, h3, h4, h5, h6, p {\n  margin: 0; }\nhtml,\nbody {\n  font-family: \"Roboto\", sans-serif; }\nh1,\nh2,\nh3,\nh4,\nh5,\nh6 {\n  font-family: \"Roboto\", sans-serif;\n  font-weight: 500; }\nh2 {\n  font-size: 25px; }\nh4 {\n  font-size: 18px; }\ntextarea {\n  resize: none; }\na {\n  color: #333; }\na:hover {\n    color: #494949; }\n.hidden {\n  display: none; }\ninput.invalid,\ninput:focus.invalid {\n  border-bottom: 2px solid #dd6a6a; }\n.content-secondary {\n  color: #787878;\n  font-size: 14px; }\n.content-secondary a {\n    display: inline-block; }\n.flex-wrapper {\n  display: flex; }\n.common-wrapper {\n  max-width: 1450px;\n  box-sizing: border-box;\n  margin: 0 auto; }\n.centered {\n  max-width: 1290px;\n  margin: 0 auto;\n  padding-top: 70px;\n  min-height: calc(100vh - 299px);\n  display: inline-block; }\n.button-colored {\n  margin-top: 12px;\n  cursor: pointer;\n  border: none;\n  background: #bb8866;\n  color: #fff;\n  text-transform: uppercase;\n  font-size: 16px;\n  font-family: \"Roboto\", sans-serif;\n  box-shadow: 0px 2px 4px 1px rgba(0, 0, 0, 0.2);\n  border-radius: 5px;\n  padding: 8px 16px; }\n.alert {\n  display: block;\n  padding: 12px 16px;\n  display: flex;\n  justify-content: space-between;\n  display: none; }\n.alert button {\n    background: none;\n    border: none;\n    font-weight: 600;\n    color: inherit;\n    cursor: pointer; }\n.alert-success {\n  background: #dff2bf;\n  color: #4f8a10; }\n.alert-warning {\n  background: #ffbaba;\n  color: #d8000c; }\n.avatar-container {\n  flex-grow: 0;\n  flex-shrink: 0; }\n.avatar-container a {\n    display: inline-block;\n    height: 100%;\n    width: 100%;\n    border-radius: 50%;\n    overflow: hidden; }\n.avatar-container img {\n    width: 100%;\n    height: 100%;\n    display: block;\n    -o-object-fit: cover;\n       object-fit: cover; }\n.image-wrapper {\n  display: -ms-grid;\n  display: grid;\n  -ms-grid-columns: 300px 300px 300px 300px;\n      grid-template-columns: 300px 300px 300px 300px;\n  margin: 0 auto;\n  grid-gap: 30px; }\n.image-element {\n  background: #fff;\n  box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.1);\n  border-radius: 3px; }\n.image-element .avatar-container {\n    width: 22px;\n    height: 22px;\n    margin-right: 8px; }\n.image-element .image-cropped {\n    width: 100%;\n    height: 250px; }\n.image-element .image-cropped img {\n      width: 100%;\n      height: 100%;\n      border-radius: 3px 3px 0 0;\n      -o-object-fit: cover;\n         object-fit: cover; }\n.image-element .image-cropped a {\n      width: 100%;\n      height: 100%;\n      display: inline-block; }\n.image-element .image-info {\n    font-weight: 400;\n    text-align: left;\n    padding: 10px 15px; }\n.image-element .image-info h3 {\n      font-weight: 400;\n      display: flex;\n      align-items: baseline; }\n.image-element .image-info h3 a {\n        flex-grow: 1; }\n.image-element .image-info h3 span {\n        flex-grow: 0;\n        flex-shrink: 0;\n        margin-left: 6px;\n        font-size: 13px;\n        color: #a2a0a0;\n        font-family: \"Roboto\", sans-serif; }\n.image-element .image-author {\n    margin-top: 4px;\n    font-size: 14px;\n    display: flex;\n    align-items: center; }\n.image-element .image-author a {\n      color: #707070; }\nform .warning {\n  margin-bottom: 3px;\n  margin-top: -18px;\n  font-family: \"Roboto\", sans-serif;\n  font-size: 12px;\n  color: #dd6a6a; }\ntextarea,\ninput,\nselect {\n  border: 0;\n  border-bottom: 2px solid #efefef;\n  box-sizing: border-box;\n  outline: 0; }\ntextarea {\n  border: 2px solid #efefef; }\n.label-wrapper {\n  display: block; }\n.label-wrapper label {\n    display: block; }\n.label-wrapper label.hidden {\n    display: none; }\ninput,\ntextarea,\nselect,\noption {\n  color: #444; }\n.input-description,\ninput,\ntextarea,\nselect,\nbutton,\noption {\n  font-family: \"Roboto\", sans-serif; }\ninput,\ntextarea {\n  padding: 5px 2px; }\ninput,\ntextarea,\nselect {\n  width: 100%;\n  margin-bottom: 18px;\n  border: 2px solid #efefef;\n  transition: 0.2s;\n  border-radius: 1px; }\ninput:focus,\n  textarea:focus,\n  select:focus {\n    border-bottom: 2px solid #2196f3; }\nselect {\n  width: 100%; }\n.input-description {\n  margin-bottom: 6px;\n  font-size: 13px;\n  color: #707070; }\nform .button-colored {\n  margin: 20px 0 0; }\n.button-colored {\n  padding: 10px 20px;\n  border-radius: 20px; }\n.file-label {\n  box-sizing: border-box;\n  width: 100%;\n  border: 2px dashed #efefef;\n  display: block;\n  cursor: pointer; }\n.file-label .label-wrapper {\n    position: relative;\n    display: block;\n    top: 50%;\n    -webkit-transform: translateY(-50%);\n            transform: translateY(-50%); }\n.label-content {\n  color: #747474;\n  text-align: center;\n  font-size: 16px; }\n.label-element {\n  display: block; }\n.message {\n  display: block;\n  margin-top: 5px; }\n.filename {\n  border: 1px solid #747474; }\n.stop-scrolling {\n  height: 100%;\n  overflow: hidden; }\n.upload-centered {\n  background: #fff;\n  max-width: 1000px;\n  border-radius: 3px;\n  box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.05);\n  padding: 30px 40px;\n  margin: 40px auto; }\n.upload-centered .svg-wrapper {\n    width: 99.5px;\n    display: block;\n    height: 61px;\n    position: relative;\n    margin: 0 auto; }\n.upload-centered .svg-wrapper svg {\n      position: absolute;\n      top: 0;\n      left: 0; }\n.upload-centered .file-label {\n    margin-top: 6px;\n    height: calc(100% - 22px);\n    transition: 0.2s;\n    word-break: break-all; }\n.upload-centered .file-label .warning {\n      text-align: center; }\n.upload-centered .file-label.is-dragover {\n    background: #ddd; }\n.upload-centered .file-label.is-dragover .svg-icon path,\n    .upload-centered .file-label.is-dragover .svg-icon line,\n    .upload-centered .file-label.is-dragover .svg-icon polyline {\n      stroke: #868686; }\n.upload-centered .svg-icon path,\n  .upload-centered .svg-icon line,\n  .upload-centered .svg-icon polyline {\n    transition: 0.2s;\n    stroke: #a3a3a3; }\n@-webkit-keyframes showAnimation {\n  0% {\n    stroke-dashoffset: -300; }\n  100% {\n    stroke-dashoffset: 0; } }\n@keyframes showAnimation {\n  0% {\n    stroke-dashoffset: -300; }\n  100% {\n    stroke-dashoffset: 0; } }\n@-webkit-keyframes showReverse {\n  0% {\n    stroke-dashoffset: 300; }\n  100% {\n    stroke-dashoffset: 0; } }\n@keyframes showReverse {\n  0% {\n    stroke-dashoffset: 300; }\n  100% {\n    stroke-dashoffset: 0; } }\n@-webkit-keyframes hideAnimation {\n  100% {\n    stroke-dashoffset: 0; }\n  100% {\n    stroke-dashoffset: 300; } }\n@keyframes hideAnimation {\n  100% {\n    stroke-dashoffset: 0; }\n  100% {\n    stroke-dashoffset: 300; } }\n.upload-centered .svg-icon path,\n  .upload-centered .svg-icon line,\n  .upload-centered .svg-icon polyline {\n    stroke-dashoffset: 0;\n    stroke-dasharray: 300;\n    -webkit-animation-duration: 0.6s;\n            animation-duration: 0.6s;\n    -webkit-animation-delay: 0s;\n            animation-delay: 0s;\n    -webkit-animation-fill-mode: forwards;\n            animation-fill-mode: forwards; }\n.upload-centered .hidden path,\n  .upload-centered .hidden line,\n  .upload-centered .hidden polyline {\n    stroke-dashoffset: 300; }\n.upload-centered .svg-fail.start-animation .line1 {\n    stroke-dashoffset: 300;\n    -webkit-animation-delay: 0.2s;\n            animation-delay: 0.2s; }\n.upload-centered .svg-fail.start-animation .line2 {\n    stroke-dashoffset: 300;\n    -webkit-animation-delay: 0.1s;\n            animation-delay: 0.1s; }\n.upload-centered .svg-fail.end-animation .line2 {\n    stroke-dashoffset: 0;\n    -webkit-animation-delay: 0.1s;\n            animation-delay: 0.1s; }\n.upload-centered .svg-success.start-animation .line2 {\n    stroke-dashoffset: 300;\n    -webkit-animation-delay: 0.2s;\n            animation-delay: 0.2s; }\n.upload-centered .svg-success.end-animation .line2 {\n    stroke-dashoffset: 0;\n    -webkit-animation-delay: 0.2s;\n            animation-delay: 0.2s; }\n.upload-centered .svg-upload.start-animation path,\n  .upload-centered .svg-upload.start-animation line,\n  .upload-centered .svg-upload.start-animation polyline {\n    -webkit-animation-duration: 1s;\n            animation-duration: 1s;\n    stroke-dashoffset: 300;\n    -webkit-animation-delay: 0.2s;\n            animation-delay: 0.2s; }\n.upload-centered .start-animation path,\n  .upload-centered .start-animation line,\n  .upload-centered .start-animation polyline {\n    -webkit-animation-name: showAnimation;\n            animation-name: showAnimation; }\n.upload-centered .end-animation path,\n  .upload-centered .end-animation line,\n  .upload-centered .end-animation polyline {\n    -webkit-animation-name: hideAnimation;\n            animation-name: hideAnimation; }\n.upload-centered h2 {\n    margin-bottom: 30px; }\n.upload-centered .image-file {\n    height: 100%; }\n.upload-centered .image-file .file-input {\n      display: none; }\n.upload-centered .flex-wrapper {\n    justify-content: space-between; }\n.upload-centered .image-description {\n    width: calc(50% - 15px); }\n.upload-centered .image-description input,\n  .upload-centered .image-description textarea,\n  .upload-centered .image-file input,\n  .upload-centered .image-file textarea {\n    display: block;\n    width: 100%; }\n.upload-centered .file-label:focus,\n  .upload-centered .outline:focus {\n    outline: 0; }\n.upload-centered .file-label:focus .outline {\n    border: 2px solid #2196f3; }\n.upload-centered .outline {\n    transition: 0.3s;\n    border: 2px solid transparent;\n    display: block;\n    width: calc(100% + 4px);\n    height: calc(100% + 4px);\n    padding: 0 20px;\n    box-sizing: border-box;\n    overflow: hidden;\n    margin: -2px 0 0 -2px;\n    display: block; }\n.upload-centered .button-colored {\n    transition: 0.2s; }\n.upload-centered .button-colored:hover {\n    outline: none;\n    background: #a17e67; }\n.loading img {\n  margin-top: -90px; }\ntag-input {\n  margin-bottom: 18px; }\n.warning.summary-warning {\n  margin-top: 0;\n  margin-bottom: -15px; }\n.centered {\n  display: inline-block;\n  margin: 0 auto; }\n.container {\n  text-align: center; }\n@media only screen and (max-width: 1449px) {\n  .image-wrapper {\n    -ms-grid-columns: 300px 300px 300px;\n        grid-template-columns: 300px 300px 300px; } }\n@media only screen and (max-width: 1039px) {\n  .image-wrapper {\n    -ms-grid-columns: 300px 300px;\n        grid-template-columns: 300px 300px; } }\n@media only screen and (max-width: 699px) {\n  .image-wrapper {\n    -ms-grid-columns: 300px;\n        grid-template-columns: 300px; } }\n.centered-block {\n  display: block; }\n.menu-list {\n  padding: 50px 0;\n  display: flex; }\n.menu-list li {\n  margin-right: 20px; }\n.menu-list a.active {\n  color: #bb8866;\n  font-weight: 600;\n  letter-spacing: 0.2px; }\n.message-container {\n  background: rgba(0, 0, 0, 0.6);\n  width: 100%;\n  height: 100vh;\n  position: fixed;\n  top: 0;\n  left: 0;\n  z-index: 999;\n  opacity: 0;\n  display: none;\n  transition: 0.2s; }\n.message-container .flex-wrapper {\n    justify-content: center; }\n.message-container .wrapper {\n    width: calc(100% - 200px);\n    max-width: 700px;\n    overflow: hidden;\n    background: white;\n    box-sizing: border-box;\n    border-radius: 3px;\n    box-shadow: 0 0 30px 5px rgba(0, 0, 0, 0.25);\n    position: relative;\n    top: 50%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%); }\n.message-container .header {\n    background: #eeeeee;\n    padding: 20px 20px 15px;\n    border-bottom: 1px solid #e9e9e9;\n    color: #757575;\n    justify-content: space-between;\n    display: flex; }\n.message-container .content {\n    padding: 20px;\n    max-height: calc(100vh - 200px);\n    overflow-y: scroll; }\n.message-container .close-button {\n    cursor: pointer;\n    transition: 0.2s; }\n.message-container .close-button:hover {\n    color: #a5a5a5; }\n.message-container.opacity {\n    opacity: 1; }\n.message-container.display {\n    display: block; }\n"

/***/ }),

/***/ "./node_modules/style-loader/lib/addStyles.js":
/*!****************************************************!*\
  !*** ./node_modules/style-loader/lib/addStyles.js ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

/*
	MIT License http://www.opensource.org/licenses/mit-license.php
	Author Tobias Koppers @sokra
*/

var stylesInDom = {};

var	memoize = function (fn) {
	var memo;

	return function () {
		if (typeof memo === "undefined") memo = fn.apply(this, arguments);
		return memo;
	};
};

var isOldIE = memoize(function () {
	// Test for IE <= 9 as proposed by Browserhacks
	// @see http://browserhacks.com/#hack-e71d8692f65334173fee715c222cb805
	// Tests for existence of standard globals is to allow style-loader
	// to operate correctly into non-standard environments
	// @see https://github.com/webpack-contrib/style-loader/issues/177
	return window && document && document.all && !window.atob;
});

var getTarget = function (target) {
  return document.querySelector(target);
};

var getElement = (function (fn) {
	var memo = {};

	return function(target) {
                // If passing function in options, then use it for resolve "head" element.
                // Useful for Shadow Root style i.e
                // {
                //   insertInto: function () { return document.querySelector("#foo").shadowRoot }
                // }
                if (typeof target === 'function') {
                        return target();
                }
                if (typeof memo[target] === "undefined") {
			var styleTarget = getTarget.call(this, target);
			// Special case to return head of iframe instead of iframe itself
			if (window.HTMLIFrameElement && styleTarget instanceof window.HTMLIFrameElement) {
				try {
					// This will throw an exception if access to iframe is blocked
					// due to cross-origin restrictions
					styleTarget = styleTarget.contentDocument.head;
				} catch(e) {
					styleTarget = null;
				}
			}
			memo[target] = styleTarget;
		}
		return memo[target]
	};
})();

var singleton = null;
var	singletonCounter = 0;
var	stylesInsertedAtTop = [];

var	fixUrls = __webpack_require__(/*! ./urls */ "./node_modules/style-loader/lib/urls.js");

module.exports = function(list, options) {
	if (typeof DEBUG !== "undefined" && DEBUG) {
		if (typeof document !== "object") throw new Error("The style-loader cannot be used in a non-browser environment");
	}

	options = options || {};

	options.attrs = typeof options.attrs === "object" ? options.attrs : {};

	// Force single-tag solution on IE6-9, which has a hard limit on the # of <style>
	// tags it will allow on a page
	if (!options.singleton && typeof options.singleton !== "boolean") options.singleton = isOldIE();

	// By default, add <style> tags to the <head> element
        if (!options.insertInto) options.insertInto = "head";

	// By default, add <style> tags to the bottom of the target
	if (!options.insertAt) options.insertAt = "bottom";

	var styles = listToStyles(list, options);

	addStylesToDom(styles, options);

	return function update (newList) {
		var mayRemove = [];

		for (var i = 0; i < styles.length; i++) {
			var item = styles[i];
			var domStyle = stylesInDom[item.id];

			domStyle.refs--;
			mayRemove.push(domStyle);
		}

		if(newList) {
			var newStyles = listToStyles(newList, options);
			addStylesToDom(newStyles, options);
		}

		for (var i = 0; i < mayRemove.length; i++) {
			var domStyle = mayRemove[i];

			if(domStyle.refs === 0) {
				for (var j = 0; j < domStyle.parts.length; j++) domStyle.parts[j]();

				delete stylesInDom[domStyle.id];
			}
		}
	};
};

function addStylesToDom (styles, options) {
	for (var i = 0; i < styles.length; i++) {
		var item = styles[i];
		var domStyle = stylesInDom[item.id];

		if(domStyle) {
			domStyle.refs++;

			for(var j = 0; j < domStyle.parts.length; j++) {
				domStyle.parts[j](item.parts[j]);
			}

			for(; j < item.parts.length; j++) {
				domStyle.parts.push(addStyle(item.parts[j], options));
			}
		} else {
			var parts = [];

			for(var j = 0; j < item.parts.length; j++) {
				parts.push(addStyle(item.parts[j], options));
			}

			stylesInDom[item.id] = {id: item.id, refs: 1, parts: parts};
		}
	}
}

function listToStyles (list, options) {
	var styles = [];
	var newStyles = {};

	for (var i = 0; i < list.length; i++) {
		var item = list[i];
		var id = options.base ? item[0] + options.base : item[0];
		var css = item[1];
		var media = item[2];
		var sourceMap = item[3];
		var part = {css: css, media: media, sourceMap: sourceMap};

		if(!newStyles[id]) styles.push(newStyles[id] = {id: id, parts: [part]});
		else newStyles[id].parts.push(part);
	}

	return styles;
}

function insertStyleElement (options, style) {
	var target = getElement(options.insertInto)

	if (!target) {
		throw new Error("Couldn't find a style target. This probably means that the value for the 'insertInto' parameter is invalid.");
	}

	var lastStyleElementInsertedAtTop = stylesInsertedAtTop[stylesInsertedAtTop.length - 1];

	if (options.insertAt === "top") {
		if (!lastStyleElementInsertedAtTop) {
			target.insertBefore(style, target.firstChild);
		} else if (lastStyleElementInsertedAtTop.nextSibling) {
			target.insertBefore(style, lastStyleElementInsertedAtTop.nextSibling);
		} else {
			target.appendChild(style);
		}
		stylesInsertedAtTop.push(style);
	} else if (options.insertAt === "bottom") {
		target.appendChild(style);
	} else if (typeof options.insertAt === "object" && options.insertAt.before) {
		var nextSibling = getElement(options.insertInto + " " + options.insertAt.before);
		target.insertBefore(style, nextSibling);
	} else {
		throw new Error("[Style Loader]\n\n Invalid value for parameter 'insertAt' ('options.insertAt') found.\n Must be 'top', 'bottom', or Object.\n (https://github.com/webpack-contrib/style-loader#insertat)\n");
	}
}

function removeStyleElement (style) {
	if (style.parentNode === null) return false;
	style.parentNode.removeChild(style);

	var idx = stylesInsertedAtTop.indexOf(style);
	if(idx >= 0) {
		stylesInsertedAtTop.splice(idx, 1);
	}
}

function createStyleElement (options) {
	var style = document.createElement("style");

	if(options.attrs.type === undefined) {
		options.attrs.type = "text/css";
	}

	addAttrs(style, options.attrs);
	insertStyleElement(options, style);

	return style;
}

function createLinkElement (options) {
	var link = document.createElement("link");

	if(options.attrs.type === undefined) {
		options.attrs.type = "text/css";
	}
	options.attrs.rel = "stylesheet";

	addAttrs(link, options.attrs);
	insertStyleElement(options, link);

	return link;
}

function addAttrs (el, attrs) {
	Object.keys(attrs).forEach(function (key) {
		el.setAttribute(key, attrs[key]);
	});
}

function addStyle (obj, options) {
	var style, update, remove, result;

	// If a transform function was defined, run it on the css
	if (options.transform && obj.css) {
	    result = options.transform(obj.css);

	    if (result) {
	    	// If transform returns a value, use that instead of the original css.
	    	// This allows running runtime transformations on the css.
	    	obj.css = result;
	    } else {
	    	// If the transform function returns a falsy value, don't add this css.
	    	// This allows conditional loading of css
	    	return function() {
	    		// noop
	    	};
	    }
	}

	if (options.singleton) {
		var styleIndex = singletonCounter++;

		style = singleton || (singleton = createStyleElement(options));

		update = applyToSingletonTag.bind(null, style, styleIndex, false);
		remove = applyToSingletonTag.bind(null, style, styleIndex, true);

	} else if (
		obj.sourceMap &&
		typeof URL === "function" &&
		typeof URL.createObjectURL === "function" &&
		typeof URL.revokeObjectURL === "function" &&
		typeof Blob === "function" &&
		typeof btoa === "function"
	) {
		style = createLinkElement(options);
		update = updateLink.bind(null, style, options);
		remove = function () {
			removeStyleElement(style);

			if(style.href) URL.revokeObjectURL(style.href);
		};
	} else {
		style = createStyleElement(options);
		update = applyToTag.bind(null, style);
		remove = function () {
			removeStyleElement(style);
		};
	}

	update(obj);

	return function updateStyle (newObj) {
		if (newObj) {
			if (
				newObj.css === obj.css &&
				newObj.media === obj.media &&
				newObj.sourceMap === obj.sourceMap
			) {
				return;
			}

			update(obj = newObj);
		} else {
			remove();
		}
	};
}

var replaceText = (function () {
	var textStore = [];

	return function (index, replacement) {
		textStore[index] = replacement;

		return textStore.filter(Boolean).join('\n');
	};
})();

function applyToSingletonTag (style, index, remove, obj) {
	var css = remove ? "" : obj.css;

	if (style.styleSheet) {
		style.styleSheet.cssText = replaceText(index, css);
	} else {
		var cssNode = document.createTextNode(css);
		var childNodes = style.childNodes;

		if (childNodes[index]) style.removeChild(childNodes[index]);

		if (childNodes.length) {
			style.insertBefore(cssNode, childNodes[index]);
		} else {
			style.appendChild(cssNode);
		}
	}
}

function applyToTag (style, obj) {
	var css = obj.css;
	var media = obj.media;

	if(media) {
		style.setAttribute("media", media)
	}

	if(style.styleSheet) {
		style.styleSheet.cssText = css;
	} else {
		while(style.firstChild) {
			style.removeChild(style.firstChild);
		}

		style.appendChild(document.createTextNode(css));
	}
}

function updateLink (link, options, obj) {
	var css = obj.css;
	var sourceMap = obj.sourceMap;

	/*
		If convertToAbsoluteUrls isn't defined, but sourcemaps are enabled
		and there is no publicPath defined then lets turn convertToAbsoluteUrls
		on by default.  Otherwise default to the convertToAbsoluteUrls option
		directly
	*/
	var autoFixUrls = options.convertToAbsoluteUrls === undefined && sourceMap;

	if (options.convertToAbsoluteUrls || autoFixUrls) {
		css = fixUrls(css);
	}

	if (sourceMap) {
		// http://stackoverflow.com/a/26603875
		css += "\n/*# sourceMappingURL=data:application/json;base64," + btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))) + " */";
	}

	var blob = new Blob([css], { type: "text/css" });

	var oldSrc = link.href;

	link.href = URL.createObjectURL(blob);

	if(oldSrc) URL.revokeObjectURL(oldSrc);
}


/***/ }),

/***/ "./node_modules/style-loader/lib/urls.js":
/*!***********************************************!*\
  !*** ./node_modules/style-loader/lib/urls.js ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {


/**
 * When source maps are enabled, `style-loader` uses a link element with a data-uri to
 * embed the css on the page. This breaks all relative urls because now they are relative to a
 * bundle instead of the current page.
 *
 * One solution is to only use full urls, but that may be impossible.
 *
 * Instead, this function "fixes" the relative urls to be absolute according to the current page location.
 *
 * A rudimentary test suite is located at `test/fixUrls.js` and can be run via the `npm test` command.
 *
 */

module.exports = function (css) {
  // get current location
  var location = typeof window !== "undefined" && window.location;

  if (!location) {
    throw new Error("fixUrls requires window.location");
  }

	// blank or null?
	if (!css || typeof css !== "string") {
	  return css;
  }

  var baseUrl = location.protocol + "//" + location.host;
  var currentDir = baseUrl + location.pathname.replace(/\/[^\/]*$/, "/");

	// convert each url(...)
	/*
	This regular expression is just a way to recursively match brackets within
	a string.

	 /url\s*\(  = Match on the word "url" with any whitespace after it and then a parens
	   (  = Start a capturing group
	     (?:  = Start a non-capturing group
	         [^)(]  = Match anything that isn't a parentheses
	         |  = OR
	         \(  = Match a start parentheses
	             (?:  = Start another non-capturing groups
	                 [^)(]+  = Match anything that isn't a parentheses
	                 |  = OR
	                 \(  = Match a start parentheses
	                     [^)(]*  = Match anything that isn't a parentheses
	                 \)  = Match a end parentheses
	             )  = End Group
              *\) = Match anything and then a close parens
          )  = Close non-capturing group
          *  = Match anything
       )  = Close capturing group
	 \)  = Match a close parens

	 /gi  = Get all matches, not the first.  Be case insensitive.
	 */
	var fixedCss = css.replace(/url\s*\(((?:[^)(]|\((?:[^)(]+|\([^)(]*\))*\))*)\)/gi, function(fullMatch, origUrl) {
		// strip quotes (if they exist)
		var unquotedOrigUrl = origUrl
			.trim()
			.replace(/^"(.*)"$/, function(o, $1){ return $1; })
			.replace(/^'(.*)'$/, function(o, $1){ return $1; });

		// already a full url? no change
		if (/^(#|data:|http:\/\/|https:\/\/|file:\/\/\/|\s*$)/i.test(unquotedOrigUrl)) {
		  return fullMatch;
		}

		// convert the url to a full url
		var newUrl;

		if (unquotedOrigUrl.indexOf("//") === 0) {
		  	//TODO: should we add protocol?
			newUrl = unquotedOrigUrl;
		} else if (unquotedOrigUrl.indexOf("/") === 0) {
			// path should be relative to the base url
			newUrl = baseUrl + unquotedOrigUrl; // already starts with '/'
		} else {
			// path should be relative to current directory
			newUrl = currentDir + unquotedOrigUrl.replace(/^\.\//, ""); // Strip leading './'
		}

		// send back the fixed url(...)
		return "url(" + JSON.stringify(newUrl) + ")";
	});

	// send back the fixed css
	return fixedCss;
};


/***/ }),

/***/ 2:
/*!*************************************!*\
  !*** multi ./ClientApp/styles.scss ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\Wolix\Documents\.Projects\c-sharp-projects\paintStore\backEnd\backEnd\ClientApp\styles.scss */"./ClientApp/styles.scss");


/***/ })

},[[2,"runtime"]]]);
//# sourceMappingURL=styles.js.map