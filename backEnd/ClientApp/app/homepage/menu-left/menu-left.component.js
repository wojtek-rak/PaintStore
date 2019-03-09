var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild, ViewChildren, Renderer2, ElementRef, QueryList } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
var MenuLeftComponent = /** @class */ (function () {
    function MenuLeftComponent(renderer, router, route) {
        this.renderer = renderer;
        this.router = router;
        this.route = route;
        this.categoryList = ['cat1', 'cat2', 'cat3', 'cat4'];
        this.categories = [];
        this.classList = {
            selected: 'selected'
        };
    }
    MenuLeftComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        // bind events to menuLeft
        this.renderer.listen(this.menuLeft.nativeElement, 'mouseenter', function () {
            _this.renderer.addClass(_this.menuLeft.nativeElement, 'opened');
        });
        this.renderer.listen(this.menuLeft.nativeElement, 'mouseleave', function () {
            _this.renderer.removeClass(_this.menuLeft.nativeElement, 'opened');
        });
        this.li.forEach(function (li, index) {
            _this.renderer.listen(li.nativeElement, 'click', function () {
                // add or remove category from category list
                var listElement = _this.categoryList[index];
                if (_this.categories.includes(listElement)) {
                    // remove element from an array
                    var indexInCategories = _this.categories.indexOf(listElement);
                    if (indexInCategories !== -1)
                        _this.categories.splice(indexInCategories, 1);
                }
                else {
                    // add element to an array
                    _this.categories.push(listElement);
                }
            });
        });
        this.renderer.listen(this.close.nativeElement, 'click', function () {
            _this.categories = [];
        });
    };
    MenuLeftComponent.prototype.ngOnInit = function () {
        // set li elements active if change path
        //...
    };
    __decorate([
        ViewChild('menuLeft'),
        __metadata("design:type", typeof (_a = typeof ElementRef !== "undefined" && ElementRef) === "function" && _a || Object)
    ], MenuLeftComponent.prototype, "menuLeft", void 0);
    __decorate([
        ViewChild('close'),
        __metadata("design:type", typeof (_b = typeof ElementRef !== "undefined" && ElementRef) === "function" && _b || Object)
    ], MenuLeftComponent.prototype, "close", void 0);
    __decorate([
        ViewChildren('li'),
        __metadata("design:type", typeof (_c = typeof QueryList !== "undefined" && QueryList) === "function" && _c || Object)
    ], MenuLeftComponent.prototype, "li", void 0);
    MenuLeftComponent = __decorate([
        Component({
            selector: 'app-menu-left',
            templateUrl: './menu-left.component.html',
            styleUrls: ['./menu-left.component.scss']
        }),
        __metadata("design:paramtypes", [typeof (_d = typeof Renderer2 !== "undefined" && Renderer2) === "function" && _d || Object, typeof (_e = typeof Router !== "undefined" && Router) === "function" && _e || Object, typeof (_f = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" && _f || Object])
    ], MenuLeftComponent);
    return MenuLeftComponent;
    var _a, _b, _c, _d, _e, _f;
}());
export { MenuLeftComponent };
//# sourceMappingURL=menu-left.component.js.map