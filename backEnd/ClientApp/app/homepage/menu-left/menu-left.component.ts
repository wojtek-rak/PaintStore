import { Component, OnInit, ViewChild, ViewChildren, Renderer2, ElementRef, AfterViewInit, QueryList } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-menu-left',
  templateUrl: './menu-left.component.html',
  styleUrls: ['./menu-left.component.scss']
})
export class MenuLeftComponent implements OnInit, AfterViewInit {

  @ViewChild('menuLeft') menuLeft?: ElementRef;
  @ViewChild('close') close?: ElementRef;
  @ViewChildren('li') li?: QueryList<ElementRef>;

  private categoryList = ['cat1', 'cat2', 'cat3', 'cat4'];
  private categories : any = [];
  private classList = {
    selected: 'selected'
  };

  constructor(private renderer: Renderer2, private router: Router, private route: ActivatedRoute) { }

  ngAfterViewInit() {
    // bind events to menuLeft
      if (this.menuLeft === undefined) return;
      this.renderer.listen(this.menuLeft.nativeElement, 'mouseenter', () => {
          if (this.menuLeft === undefined) return;

      this.renderer.addClass(this.menuLeft.nativeElement, 'opened');
      });
      if (this.menuLeft === undefined) return;

      this.renderer.listen(this.menuLeft.nativeElement, 'mouseleave', () => {
          if (this.menuLeft === undefined) return;

      this.renderer.removeClass(this.menuLeft.nativeElement, 'opened');
    });
      if (this.li === undefined) return;

    this.li.forEach((li, index) => {
      this.renderer.listen(li.nativeElement, 'click', () => {

        // add or remove category from category list
          let listElement = this.categoryList[index];

        if(this.categories.includes(listElement)) {
          // remove element from an array
          let indexInCategories = this.categories.indexOf(listElement);
          if (indexInCategories !== -1) this.categories.splice(indexInCategories, 1);
        } else {
          // add element to an array
          this.categories.push(listElement);
        }

      });
    });
      if (this.close === undefined) return;

    this.renderer.listen(this.close.nativeElement, 'click', () => {
      this.categories = [];
    });

  }

  ngOnInit() {
    // set li elements active if change path
    //...
  }


}
