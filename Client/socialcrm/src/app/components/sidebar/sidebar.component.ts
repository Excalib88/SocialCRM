import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Аналитика',  icon: 'dashboard', class: '' },
    { path: '/leads', title: 'Клиенты', icon: 'people', class: ''},
    { path: '/orders', title: 'Заказы', icon: 'shopping_cart', class: ''},
    { path: '/user-profile', title: 'Профиль',  icon:'person', class: '' },
    { path: '/notifications', title: 'Уведомления',  icon:'notifications', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
