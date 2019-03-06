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
let MenuLeftComponent = class MenuLeftComponent {
    constructor(renderer, router, route) {
        this.renderer = renderer;
        this.router = router;
        this.route = route;
        this.categoryList = ['cat1', 'cat2', 'cat3', 'cat4'];
        this.categories = [];
        this.classList = {
            selected: 'selected'
        };
    }
    ngAfterViewInit() {
        // bind events to menuLeft
        if (this.menuLeft === undefined)
            return;
        this.renderer.listen(this.menuLeft.nativeElement, 'mouseenter', () => {
            if (this.menuLeft === undefined)
                return;
            this.renderer.addClass(this.menuLeft.nativeElement, 'opened');
        });
        if (this.menuLeft === undefined)
            return;
        this.renderer.listen(this.menuLeft.nativeElement, 'mouseleave', () => {
            if (this.menuLeft === undefined)
                return;
            this.renderer.removeClass(this.menuLeft.nativeElement, 'opened');
        });
        if (this.li === undefined)
            return;
        this.li.forEach((li, index) => {
            this.renderer.listen(li.nativeElement, 'click', () => {
                // add or remove category from category list
                let listElement = this.categoryList[index];
                if (this.categories.includes(listElement)) {
                    // remove element from an array
                    let indexInCategories = this.categories.indexOf(listElement);
                    if (indexInCategories !== -1)
                        this.categories.splice(indexInCategories, 1);
                }
                else {
                    // add element to an array
                    this.categories.push(listElement);
                }
            });
        });
        if (this.close === undefined)
            return;
        this.renderer.listen(this.close.nativeElement, 'click', () => {
            this.categories = [];
        });
    }
    ngOnInit() {
        // set li elements active if change path
        //...
    }
};
__decorate([
    ViewChild('menuLeft'),
    __metadata("design:type", ElementRef)
], MenuLeftComponent.prototype, "menuLeft", void 0);
__decorate([
    ViewChild('close'),
    __metadata("design:type", ElementRef)
], MenuLeftComponent.prototype, "close", void 0);
__decorate([
    ViewChildren('li'),
    __metadata("design:type", QueryList)
], MenuLeftComponent.prototype, "li", void 0);
MenuLeftComponent = __decorate([
    Component({
        selector: 'app-menu-left',
        templateUrl: './menu-left.component.html',
        styleUrls: ['./menu-left.component.scss']
    }),
    __metadata("design:paramtypes", [Renderer2, Router, ActivatedRoute])
], MenuLeftComponent);
export { MenuLeftComponent };
//# sourceMappingURL=menu-left.component.js.map